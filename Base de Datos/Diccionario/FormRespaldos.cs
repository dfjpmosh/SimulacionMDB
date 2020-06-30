using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Diccionario
{
    public partial class FormRespaldos : Form
    {
        private string fIni;
        private string fFin;
        private DateTime fInicial;
        private DateTime fFinal;
        private CArchivo arch;
        private CArchivo nuevo;
        private CBloque bloque;
        private int tam;
        private List<CAtributo> LA;
        private List<CEntidad> LE;
        private long cab;
        private string nomsec;
        private string nuevonom;

        public FormRespaldos(string nom)
        {
            InitializeComponent();
            nomsec = nom;
            cab=-1;
            nuevo = new CArchivo();
            arch = new CArchivo();
            LE = new List<CEntidad>();
            LE = arch.abrirArchivo(nomsec, cab);
            LA = new List<CAtributo>();
        }

        private void calculaTam()
        {
            tam = 0;
            foreach (CAtributo corre in LA)
            {
                switch (corre.TipoDato)
                {
                    case "int": tam += 4; break;
                    case "float": tam += 8; break;
                    case "string": tam += (corre.Tamaño * 2); break;
                    case "char": tam += 2; break;
                    case "boolean": tam += 1; break;
                }
            }
            tam += 8;
        }

        private int calculaDes()
        {
            int des=0;
            des = tam - 80;
            return des;
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            DNombre fn = new DNombre();

            fn.Text = "Archivo de Respaldo";
            if (fn.ShowDialog() == DialogResult.OK)
            {
                capturaFecha();
                crearArchivo(fn.tbNom.Text);
                Respalda();
            }
        }

        private void capturaFecha()
        {
            /*fIni = fechaInicial.SelectionRange.Start.ToShortDateString();
            fFin = fechaFinal.SelectionRange.Start.ToShortDateString()+" 11:59:59 p.m.";*/
            fIni = fechaIni.Value.ToShortDateString();// + " " //+ fechaFin.Value.ToShortTimeString();
            fFin = fechaFin.Value.ToShortDateString() + " 11:59:59 p.m."; //+ fechaFin.Value.ToLongTimeString();

            fInicial = Convert.ToDateTime(fIni);
            fFinal = Convert.ToDateTime(fFin);
        }

        private void crearArchivo(string nom)
        {
            nuevo.Nombre = nuevonom = nom + ".sec";
            
            if (!File.Exists(nuevo.Nombre))
            {
                File.Copy(nomsec.Substring(0, nomsec.Length - 4) + ".usr", nom + ".usr");
                nuevo.Crear_Archivo(LE[0].Direccion);
                foreach (CEntidad e in LE)
                {
                    e.AptDatos = -1;
                    nuevo.EscribeEntidad(e);
                    LA = arch.abrirArchivoAtributo(nomsec, e);
                    foreach (CAtributo a in LA)
                    {
                        nuevo.EscribeAtributo(a);
                    }
                }
            }
            else
                MessageBox.Show("No se puedo crear El Nombre ya existe");
        }

        public void Respalda()
        {
            int i;
            List<CEntidad> leAux = new List<CEntidad>();

            leAux = arch.abrirArchivo(nomsec, cab);
            LE = nuevo.abrirArchivo(nuevonom, cab);

            for (i = 0; i < leAux.Count; i++)
            {
                if (leAux[i].AptDatos != -1)
                {
                    LA = arch.abrirArchivoAtributo(nomsec, LE[i]);
                    calculaTam();
                    bloque = new CBloque(tam);
                    bloque.Bloque = arch.LeeBloque(nomsec, tam, leAux[i].AptDatos);
                    bloque.Dir = leAux[i].AptDatos;
                    bloque.Des = calculaDes();
                    comparaFechas(i);
                    //Saco las fechas y compara si cumplen lo guardo en la LE
                    bloque.sacaSiguiente();
                    while (bloque.Siguiente != -1)
                    {
                        bloque.Bloque = arch.LeeBloque(nomsec, tam, bloque.Siguiente);
                        bloque.Dir = bloque.Siguiente;
                        bloque.Des = calculaDes();
                        comparaFechas(i);
                        //Saco las fechas y compara si cumplen lo guardo en la LE
                        bloque.sacaSiguiente();
                    }
                }
            }
        }

        private void comparaFechas(int ind)
        {
            DateTime fAlta = new DateTime(0001, 01, 01, 12, 00, 00);
            DateTime fBaja = new DateTime(0001, 01, 01, 12, 00, 00); 
            DateTime fMod = new DateTime(0001, 01, 01, 12, 00, 00);
            string fA, fB, fM;
            int uA, uB, uM;
            
            fA = bloque.sacaString(10);
            uA = bloque.sacaInt(4);
            fB = bloque.sacaString(10);
            uB = bloque.sacaInt(4);
            fM = bloque.sacaString(10);
            uM = bloque.sacaInt(4);

            if (fA.Length > 0)
                fAlta = Convert.ToDateTime(fA);
            if (fB.Length > 0)
                fBaja = Convert.ToDateTime(fB);
            if (fM.Length > 0)
                fMod = Convert.ToDateTime(fM);

            if ((DateTime.Compare(fAlta, fInicial) >= 0 && DateTime.Compare(fAlta, fFinal) <= 0) ||
                (DateTime.Compare(fBaja, fInicial) >= 0 && DateTime.Compare(fBaja, fFinal) <= 0) ||
                (DateTime.Compare(fMod, fInicial) >= 0 && DateTime.Compare(fMod, fFinal) <= 0) )
            {
                //guardar el bloque en la entidad de la LE se le manda el indice
                guardarBloque(ind);
            }
        }

        private void guardarBloque(int ind)
        {
            CBloque aux = new CBloque(tam);
            bloque.sacaSiguiente();
            long sig = bloque.Siguiente;
            bloque.empaquetaSig(-1);

            if (LE[ind].AptDatos == -1)
            {
                LE[ind].AptDatos = bloque.Dir;
                nuevo.EscribeEntidad(LE[ind]);
            }
            else
            {
                aux.Bloque = nuevo.LeeBloque(nuevonom, tam, LE[ind].AptDatos);
                aux.Dir = LE[ind].AptDatos;
                aux.sacaSiguiente();
                while (aux.Siguiente != -1)
                {
                    aux.Bloque = nuevo.LeeBloque(nuevonom, tam, aux.Siguiente);
                    aux.Dir = aux.Siguiente;
                    aux.sacaSiguiente();
                }
                aux.empaquetaSig(bloque.Dir);
                nuevo.EscribeBloque(aux);
            }

            nuevo.EscribeBloque(bloque);
            bloque.empaquetaSig(sig);
        }
    }
}

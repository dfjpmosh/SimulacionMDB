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
    /* Esta clase es la encargada de capturar
     * los datos empaquetarlos y escibir el bloque
     * en el archivo. Este metod es parte de la organizacion
     * secuencial
     */
    public partial class CIngreDat : Form
    {
        private CArchivo arch;
        private CBloque bloque;
        private int tam, indE;
        private List<CAtributo> LA;
        private List<CAtributo> laux;
        private List<CEntidad> LE;
        private long cab;
        private string nomsec;
        private bool enc = false, existe=false;
        private bool cerrar = true;
        private string fecha;
        public int idUs;
        
        public CIngreDat()
        {
            InitializeComponent();

        }
        
        /* Este metodo inicializa las varibles
         * y carga las listas de entidades y atributos
         * que seran utilizadas.
         */
        private void CIngreDat_Load(object sender, EventArgs e)
        {
            arch = new CArchivo();
            bloque = new CBloque(tam);
            LE = new List<CEntidad>();
            LE = arch.abrirArchivo(nomsec, cab);
            LA = new List<CAtributo>();
            laux = new List<CAtributo>();
            if (indE < LE.Count)
                LA = arch.abrirArchivoAtributo(nomsec, LE[indE]);
        }
        
        /* Este metodo es el encargado de empaquetar los datos capturados
         * checa que el bloque no se repita en el archivo
         * y los escribe en el archivo modificando los apuntadores 
         * de los demas bloques
         */
        private void bGuardar_Click(object sender, EventArgs e)
        {
            bool guardar = true;
            int i, indA = 0, des;
            existe = false;
            cab = -1;
            CBloque aux = new CBloque(tam);
            CBloque ant = new CBloque(tam);
            bloque = new CBloque(tam);

            if (lleno())
            {
                for (i = 0; i < LA.Count() - 6; i++)//el -6 es para no tomar en cuenta los ultimos atributos
                {
                    if (LA[i].AptEntidad != -1)
                        if (datoEntExt(LA[i], dgvIngreDat[i, 0].Value.ToString()) == false)
                        {
                            guardar = false;
                            cerrar = false;
                            MessageBox.Show("El valor " + dgvIngreDat[i, 0].Value.ToString() + "De la Columna " + LA[i].Nombre +
                                            "\nNo Existe en la Entidad Relacionada");
                            break;
                        }
                }

                if (guardar)
                {
                    for (i = 0; i < LA.Count() - 6; i++)//el -6 es para no tomar en cuenta los ultimos atributos
                    {
                        bloque.empaqueta(dgvIngreDat[i, 0].Value.ToString(), LA[i].TipoDato, LA[i].Tamaño);
                    }
                    fecha = DateTime.Today.ToString("d");
                    bloque.empaqueta(fecha, "string", 10);
                    bloque.empaqueta(idUs.ToString(), "int", 4);
                    bloque.Dir = bloque.Direccion(nomsec);
                    
                    if (LE[indE].AptDatos == -1)
                    {
                        LE[indE].AptDatos = bloque.Dir;
                        arch.EscribeEntidad(LE[indE]);
                    }
                    else
                    {
                        aux.Bloque = arch.LeeBloque(nomsec, tam, LE[indE].AptDatos);
                        aux.Dir = LE[indE].AptDatos;
                        aux.Des = 0;
                        foreach (CAtributo ca in LA)
                        {
                            if (ca.TipoClave == 1)
                                break;
                            switch (ca.TipoDato)
                            {
                                case "int":
                                    aux.Des += 4;
                                    break;
                                case "float":
                                    aux.Des += 8;
                                    break;
                                case "char":
                                    aux.Des += 2;
                                    break;
                                case "boolean":
                                    aux.Des += 1;
                                    break;
                                case "string":
                                    aux.Des += (ca.Tamaño * 2);
                                    break;
                            }
                            indA++;
                        }

                        des = bloque.Des = aux.Des;
                        if (aux.comparaTo(bloque, LA[indA].TipoDato) == 1)  //1 si aux>bloque  0 si aux==bloque -1 aux<bloque
                        {
                            bloque.Siguiente = LE[indE].AptDatos;
                            bloque.empaquetaSig(bloque.Siguiente);
                            arch.EscribeBloque(bloque);
                            LE[indE].AptDatos = bloque.Dir;
                            arch.EscribeEntidad(LE[indE]);
                        }
                        else
                        {
                            bloque.Des = aux.Des = des;
                            if (aux.comparaTo(bloque, LA[indA].TipoDato) == 0)
                            {
                                existe = true; //Encontro a un numero igual
                                MessageBox.Show("La Clave ya Existe");
                            }
                            aux.sacaSiguiente();
                            while (aux.Siguiente != -1 && !enc)
                            {
                                ant.Bloque = aux.Bloque;
                                ant.Dir = aux.Dir;
                                ant.sacaSiguiente();
                                aux.Bloque = arch.LeeBloque(nomsec, tam, ant.Siguiente);
                                aux.Dir = ant.Siguiente;
                                bloque.Des = aux.Des = des;
                                switch (aux.comparaTo(bloque, LA[indA].TipoDato))
                                {
                                    case 0:
                                        existe = true; //Encontro a un numero igual
                                        MessageBox.Show("La Clave ya Existe");
                                        break;
                                    case 1:
                                        enc = true; //Encontro a un numero mañor que el
                                        break;
                                }
                                if (existe)
                                    break;
                                if (enc && !existe)
                                {
                                    bloque.Siguiente = aux.Dir;
                                    bloque.empaquetaSig(bloque.Siguiente);
                                    ant.Siguiente = bloque.Dir;
                                    ant.empaquetaSig(ant.Siguiente);
                                    arch.EscribeBloque(ant);
                                }
                                aux.sacaSiguiente();
                            }
                            if (!enc && !existe)
                            {
                                aux.Siguiente = bloque.Dir;
                                aux.empaquetaSig(aux.Siguiente);
                                arch.EscribeBloque(aux);
                            }
                        }
                    }
                    if (!existe)
                    {
                        arch.EscribeBloque(bloque);
                        cerrar = true;
                    }
                    else
                        cerrar = false;
                }
            }
        }

        /* Este metodo retorna y captura el tamaño */
        public int Tam
        {
            get { return tam; }
            set { tam = value; }
        }

        /* Este metodo retorna y captura el indice de la entidad seleccionada*/
        public int IndEnt
        {
            get { return indE; }
            set { indE = value; }
        }

        /* Este metodo retorna y captura el nombre del archivo con que se va a trabajar */
        public string NomSec
        {
            get { return nomsec; }
            set { nomsec = value; }
        }

        /* Este metodo valida que todas las celdas este rellenadas
         * de ser así habilita el boton de guardar,
         * de lo contrario lo mantiene deshabilitado
         */
        private void dgvIngreDat_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            bool b=true;
            
            for (i = 0; i < LA.Count-6; i++)//el -6 es para que no tome en cuenta los ultimos atributos
            {
                if (dgvIngreDat[i, 0].Value == null)
                        b = false;
            }

            if (b)
                bGuardar.Enabled = true;
        }


        private bool datoEntExt(CAtributo a, string dato)
        {
            List<string> LVEE = new List<string>();
            CBloque bl;
            int t = 0, des = 0, datI, ts = 0;
            string tipo = "";
            double datD;
            char datC;
            string dS;
            bool b, bandF = true;

            foreach (CEntidad ce in LE)
            {
                if (ce.Direccion == a.AptEntidad)
                {
                    if (ce.AptDatos != -1)
                    {
                        laux = new List<CAtributo>();
                        laux = arch.abrirArchivoAtributo(nomsec, ce);
                        foreach (CAtributo ca in laux)
                        {
                            if (ca.TipoClave == 1)
                            {
                                des = t;
                                tipo = ca.TipoDato;
                                ts = ca.Tamaño;
                            }
                            switch (ca.TipoDato)
                            {
                                case "int": t += 4; break;
                                case "float": t += 8; break;
                                case "char": t += 2; break;
                                case "string": t += ca.Tamaño * 2; break;
                                case "boolean": t += 1; break;
                            }
                        }
                        t += 8;
                        bl = new CBloque(t);
                        bl.Bloque = arch.LeeBloque(nomsec, t, ce.AptDatos);
                        bl.Dir = ce.AptDatos;
                        while (bandF)
                        {
                            bl.Des = des;
                            switch (tipo)
                            {
                                case "int":
                                    datI = bl.sacaInt(4);
                                    LVEE.Add(Convert.ToString(datI));
                                    break;
                                case "float":
                                    datD = bl.sacaFloat(8);
                                    LVEE.Add(Convert.ToString(datD));
                                    break;
                                case "char":
                                    datC = bl.sacaChar(2);
                                    LVEE.Add(Convert.ToString(datC));
                                    break;
                                case "string":
                                    dS = bl.sacaString(ts);
                                    LVEE.Add(dS);
                                    break;
                                case "boolean":
                                    b = bl.sacaBool(1);
                                    break;
                            }

                            bl.sacaSiguiente();

                            if (bl.Siguiente == -1)
                            {
                                bandF = false;
                            }
                            else
                            {
                                bl.Bloque = arch.LeeBloque(nomsec, t, bl.Siguiente);
                                bloque.Dir = bl.Siguiente;
                            }
                        }

                    }
                    break;
                }
            }

            foreach (string s in LVEE)
            {
                if (s == dato)
                {
                    if (estaEliminado(a, dato, LVEE) == false)
                        return true;
                    else
                        return false;
                }
            }

            return false;
        }

        private bool estaEliminado(CAtributo a, string dato, List<string> lista)
        {
            List<string> LVEE = new List<string>();
            CBloque bl;
            int i;
            int t = 0, des = 0, datI, ts = 0;
            string tipo = "";
            double datD;
            char datC;
            string dS;
            bool b, bandF = true;

            foreach (CEntidad ce in LE)
            {
                if (ce.Direccion == a.AptEntidad)
                {
                    if (ce.AptDatos != -1)
                    {
                        laux = new List<CAtributo>();
                        laux = arch.abrirArchivoAtributo(nomsec, ce);
                        foreach (CAtributo ca in laux)
                        {
                            if (ca.Nombre == "Fecha_Baja")
                            {
                                des = t;
                                tipo = ca.TipoDato;
                                ts = ca.Tamaño;
                            }
                            switch (ca.TipoDato)
                            {
                                case "int": t += 4; break;
                                case "float": t += 8; break;
                                case "char": t += 2; break;
                                case "string": t += ca.Tamaño * 2; break;
                                case "boolean": t += 1; break;
                            }
                        }
                        t += 8;
                        bl = new CBloque(t);
                        bl.Bloque = arch.LeeBloque(nomsec, t, ce.AptDatos);
                        bl.Dir = ce.AptDatos;
                        while (bandF)
                        {
                            bl.Des = des;
                            switch (tipo)
                            {
                                case "int":
                                    datI = bl.sacaInt(4);
                                    LVEE.Add(Convert.ToString(datI));
                                    break;
                                case "float":
                                    datD = bl.sacaFloat(8);
                                    LVEE.Add(Convert.ToString(datD));
                                    break;
                                case "char":
                                    datC = bl.sacaChar(2);
                                    LVEE.Add(Convert.ToString(datC));
                                    break;
                                case "string":
                                    dS = bl.sacaString(ts);
                                    LVEE.Add(dS);
                                    break;
                                case "boolean":
                                    b = bl.sacaBool(1);
                                    break;
                            }

                            bl.sacaSiguiente();

                            if (bl.Siguiente == -1)
                            {
                                bandF = false;
                            }
                            else
                            {
                                bl.Bloque = arch.LeeBloque(nomsec, t, bl.Siguiente);
                                bloque.Dir = bl.Siguiente;
                            }
                        }

                    }
                    break;
                }
            }

            for(i = 0; i < lista.Count; i++)
            {
                if (lista[i] == dato)
                {
                    if (LVEE[i].Length > 0)
                        return true;
                    else
                        return false;
                }
            }

            return false;
        }

        private void CIngreDat_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!cerrar)
                e.Cancel = true;
        }

        private bool lleno()
        {
            int i;

            for (i = 0; i < dgvIngreDat.ColumnCount; i++)
                if (dgvIngreDat[i, 0].Value == null || dgvIngreDat[i, 0].Value.ToString().Length < 1)
                {
                    MessageBox.Show("Rellene Todas las Celdas");
                    cerrar = false;
                    return false;
                }

            return true;
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            cerrar = true;
        }

        private void dgvIngreDat_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridViewCell celda = dgvIngreDat.CurrentCell;

            if (celda.ValueType == typeof(int))
                MessageBox.Show("La Columna Solo Puede Contener Valores Numericos Enteros");
            if (celda.ValueType == typeof(float))
                MessageBox.Show("La Columna Solo Puede Contener Valores Numericos");
        }
    }
}

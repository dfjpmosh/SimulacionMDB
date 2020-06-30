using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Diccionario
{
    /* Esta clase es la encargada
     * de controlar la modificacion 
     * de los datos de la organizacion Secuencial
     */
    public partial class CModSDat : Form
    {
        private CArchivo arch;
        private CBloque bloque;
        private int tam, indE;
        private List<CAtributo> LA;
        private List<CAtributo> laux;
        private List<CEntidad> LE;
        private long cab, dirA;
        private string nomsec;
        private bool enc = false;//, existe=false;
        private int iu;
        private bool cerrar = true;

        public CModSDat(int indu)
        {
            InitializeComponent();
            iu = indu;
        }

        private void CModSDat_Load(object sender, EventArgs e)
        {
            
        }
        
        /* Este metodo es el encargado de empaquetar los datos
         * y comparar que no se repita el bloque en el archivo
         * y lo escribe en el archivo y modifica los apuntadores
         */
        private void bGuardar_Click(object sender, EventArgs e)
        {
            string fecha, fA="", fB="";
            int uA=0, uB=0;
            bool guardar = true;
            int i, indA = 0, des;
            cab = -1;
            //existe = false;
            CBloque aux = new CBloque(tam);
            CBloque ant = new CBloque(tam);
            
            arch = new CArchivo();
            bloque = new CBloque(tam);
            LE = new List<CEntidad>();
            LE = arch.abrirArchivo(nomsec, cab);
            LA = new List<CAtributo>();
            laux = new List<CAtributo>();
            
            if (indE < LE.Count)
                LA = arch.abrirArchivoAtributo(nomsec, LE[indE]);

            if (lleno())
            {
                for (i = 0; i < LA.Count() - 6; i++)//el -6 es para no tomar en cuenta los ultimos atributos
                {
                    if (LA[i].AptEntidad != -1)
                        if (datoEntExt(LA[i], dgvIngreDat[i, 0].Value.ToString()) == false)
                        {
                            guardar = false;
                            cerrar = false;
                            MessageBox.Show("El valor  " + dgvIngreDat[i, 0].Value.ToString() + "  De la Columna  " + LA[i].Nombre +
                                            "\nNo Existe en la Entidad Relacionada");
                            break;
                        }
                }

                if (guardar)
                {
                    for (i = 0; i < LA.Count() - 6; i++)//Para no tomar en cuenta las fechas
                    {
                        bloque.empaqueta(dgvIngreDat[i, 0].Value.ToString(), LA[i].TipoDato, LA[i].Tamaño);
                    }

                    bloque.Dir = bloque.Direccion(nomsec);

                    aux.Bloque = arch.LeeBloque(nomsec, tam, LE[indE].AptDatos);
                    aux.Dir = LE[indE].AptDatos;
                    aux.Des = 0;
                    foreach (CAtributo ca in LA)
                    {
                        if (ca.TipoClave == 1)
                        {
                            break;
                        }
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
                    bloque.Des = aux.Des = des;

                    if (aux.comparaTo(bloque, LA[indA].TipoDato) == 0)  //1 si aux>bloque  0 si aux==bloque -1 aux<bloque
                    {
                        //Baja Logica
                        bloque.Dir = aux.Dir;

                        aux.Des = aux.Bloque.Length - 80;
                        fA = aux.sacaString(10);
                        uA = aux.sacaInt(4);
                        fB = aux.sacaString(10);
                        uB = aux.sacaInt(4);
                        
                        aux.sacaSiguiente();
                        bloque.empaquetaSig(aux.Siguiente);
                        enc = true;
                        /*aux.sacaSiguiente();
                        LE[indE].AptDatos = aux.Siguiente;
                        arch.EscribeEntidad(LE[indE]);*/
                    }
                    else
                    {
                        aux.sacaSiguiente();
                        while (aux.Siguiente != -1 && !enc)
                        {
                            ant.Bloque = aux.Bloque;
                            ant.Dir = aux.Dir;
                            ant.sacaSiguiente();
                            aux.Bloque = arch.LeeBloque(nomsec, tam, ant.Siguiente);
                            aux.Dir = ant.Siguiente;
                            bloque.Des = aux.Des = des;
                            if (aux.comparaTo(bloque, LA[indA].TipoDato) == 0)
                            {
                                enc = true;
                                bloque.Dir = aux.Dir;
                        
                                aux.Des = aux.Bloque.Length - 80;
                                fA = aux.sacaString(10);
                                uA = aux.sacaInt(4);
                                fB = aux.sacaString(10);
                                uB = aux.sacaInt(4);
                        
                                aux.sacaSiguiente();
                                bloque.empaquetaSig(aux.Siguiente);
                                /*aux.sacaSiguiente();
                                ant.Siguiente = aux.Siguiente;
                                ant.empaquetaSig(ant.Siguiente);
                                arch.EscribeBloque(ant);*/
                                //dgvDS.Rows[indD].Cells[dgvDS.ColumnCount - 1].Value = "Baja Logica";
                            }
                            aux.sacaSiguiente();
                        }
                    }
                    if (enc)
                    {
                        bloque.Des = bloque.Bloque.Length - 80;
                        bloque.empaqueta(fA, "string", 10);
                        bloque.empaqueta(Convert.ToString(uA), "int", 4);
                        bloque.empaqueta(fB, "string", 10);
                        bloque.empaqueta(Convert.ToString(uB), "int", 4);

                        bloque.Des = bloque.Bloque.Length - 32;
                        fecha = DateTime.Today.ToString("d");
                        bloque.empaqueta(fecha, "string", 10);
                        bloque.empaqueta((iu + 1).ToString(), "int", 4);
                        arch.EscribeBloque(bloque);
                        cerrar = true;
                    }
                    else
                        cerrar = false;
                }
            }
            /*
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
                    /*if (aux.comparaTo(bloque, LA[indA].TipoDato) == 0)
                    {
                        existe = true; //Encontro a un numero igual
                        MessageBox.Show("La Clave ya Existe");
                    }//esto
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
                            /*case 0:
                                existe = true; //Encontro a un numero igual
                                MessageBox.Show("La Clave ya Existe");
                            break;//
                            case 1:
                                enc = true; //Encontro a un numero mayor que el
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
                arch.EscribeBloque(bloque);*/
        }

        /* Este metodo retorna y captura el tamaño del bloque*/
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

        /* Este metodo retorna y captura el nombre del archivo con el que se va a trabajar*/
        public string NomSec
        {
            get { return nomsec; }
            set { nomsec = value; }
        }

        /* Este metodo retorna y captura la direccion del atributo*/
        public long DirA
        {
            get { return dirA; }
            set { dirA = value; }
        }

        /* Este metodo impide que se cierre la forma
         * si aun no se completa el alta de datos
         */
        private void CModSDat_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!cerrar)
                e.Cancel = true;
        }

        /* Este metodo valida que 
         * todas las celdas del dataGrid este rellenas
         * si es así activa el boton de guardar
         * de los controrio mantiene el boton desactivado
         */
        private void dgvIngreDat_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            bool b = true;
            
            arch = new CArchivo();
            LE = arch.abrirArchivo(nomsec, cab);
            LA = new List<CAtributo>();
            if (indE < LE.Count)
                LA = arch.abrirArchivoAtributo(nomsec, LE[indE]);

            for (i = 0; i < LA.Count-6; i++)//Para no tomar en cuenta las fechas
            {
                if (dgvIngreDat[i, 0].Value == null)
                    b = false;
            }

            if (b)
                bGuardar.Enabled = true;
        }

        private void dgvIngreDat_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridViewCell celda = dgvIngreDat.CurrentCell;

            if (celda.ValueType == typeof(int))
                MessageBox.Show("La Celda Solo Puede Contener Valores Numericos Enteros");
            if (celda.ValueType == typeof(float))
                MessageBox.Show("La Celda Solo Puede Contener Valores Numericos");
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

            for (i = 0; i < lista.Count; i++)
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

        

        
       
    }
}

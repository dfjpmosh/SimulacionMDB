using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Diccionario
{
    /* Esta clase esta encargada de mostrar
     * entidades y sus bloques de datos,
     * controla el alta, baja y modificacion de los datos
     */
    public partial class CSecuencial : Form
    {
        private CBloque bloque;
        private List<CEntidad> LE;
        private List<CAtributo> LA;
        private List<CUser> LU;
        private List<CAtributo> laux;
        private string nomsec;
        private CArchivo arch;
        private long cab = -1;
        private int inddgvE;
        private int indE, tam;
        private int iu;
        private List<string> LVEE;
        private bool consultas;
        
        public CSecuencial()
        {
            InitializeComponent();
            timer1.Start();
        }

        /* Este metodo inicializa las variables
         * y carga la lista de entidades y las
         * muestra en el dataGrid de entidades
         */
        private void CSecuencial_Load(object sender, EventArgs e)
        {
            //timer1.Start();
            LVEE = new List<string>(); //lista de valores de la entidad externa
            LE = new List<CEntidad>();
            LA = new List<CAtributo>();
            LU= new List<CUser>();
            arch = new CArchivo();
            cab = -1;
            inddgvE = 0;
            
            /*LE = arch.abrirArchivo(nomsec, cab);
            foreach (CEntidad corre in LE)
            {
                dgvES.Rows.Add(corre.Nombre, corre.Direccion, corre.AptEntidad, corre.AptAtributo, corre.AptDatos);
            }*/

            bGuardar.Enabled = false;
            bBajaDato.Enabled = false;
            bModificaDato.Enabled = false;
        }

        /* Este metodo retorna y captura el nombre del archivo con el que se trabajara*/
        public string NomSec
        {
            get { return nomsec; }
            set { nomsec = value; }
        }

        /* Este metodo se encarga de actualizar
         * el dataGrid de datos, segun la entidad
         * seleccionada
         */
        private void dgvES_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn txt, txt1;
            
            int iFA = 0;
            int datI;
            double datD;
            char datC;
            string dS;
            Boolean b = true, bandF = true;
            tam = 0;
            LA.Clear();
            dgvDS.Columns.Clear();
            dgvDS.Rows.Clear();
            dgvDato.Columns.Clear();
            dgvDato.Rows.Clear();
            mNRespaldo.Enabled = true;

            indE = inddgvE = dgvES.CurrentRow.Index;

            if (LE.Count > 0)
            {
                if (inddgvE < LE.Count)
                {
                    LA = arch.abrirArchivoAtributo(nomsec, LE[inddgvE]);
                    if (LE[inddgvE].AptDatos == -1)
                    {
                        bBajaDato.Enabled = false;
                        bModificaDato.Enabled = false;
                    }
                    else
                    {
                        activaPermisos();
                    }
                }
                foreach (CAtributo corre in LA)
                {
                    switch (corre.TipoDato)
                    {
                        case "int": tam += 4;
                            if (corre.Nombre != "Id_Usu_Alt" && corre.Nombre != "Id_Usu_Baj" && corre.Nombre != "Id_Usu_Mod")
                            {
                                txt = new DataGridViewTextBoxColumn();
                                txt.HeaderText = corre.Nombre;
                                txt.Name = corre.Nombre;
                                txt.ValueType = typeof(Int32);
                                txt.MaxInputLength = 7;
                                dgvDS.Columns.Add(txt);
                                txt1 = new DataGridViewTextBoxColumn();
                                txt1.HeaderText = corre.Nombre;
                                txt1.Name = corre.Nombre+"1";
                                txt1.ValueType = typeof(Int32);
                                txt1.MaxInputLength = 7;
                                dgvDato.Columns.Add(txt1);
                            }
                        break;
                        case "float": tam += 8;
                                txt = new DataGridViewTextBoxColumn();
                                txt.HeaderText = corre.Nombre;
                                txt.Name = corre.Nombre;
                                txt.ValueType = typeof(float);
                                txt.MaxInputLength = 7;
                                dgvDS.Columns.Add(txt);
                                txt1 = new DataGridViewTextBoxColumn();
                                txt1.HeaderText = corre.Nombre;
                                txt1.Name = corre.Nombre+"1";
                                txt1.ValueType = typeof(float);
                                txt1.MaxInputLength = 7;
                                dgvDato.Columns.Add(txt1);
                        break;
                        case "string": tam += (corre.Tamaño*2);
                            if (corre.Nombre != "Fecha_Alta" && corre.Nombre != "Fecha_Baja" && corre.Nombre != "Fecha_Mod")
                            {
                                txt = new DataGridViewTextBoxColumn();
                                txt.HeaderText = corre.Nombre;
                                txt.Name = corre.Nombre;
                                txt.ValueType = typeof(string);
                                txt.MaxInputLength = corre.Tamaño;
                                dgvDS.Columns.Add(txt);
                                txt1 = new DataGridViewTextBoxColumn();
                                txt1.HeaderText = corre.Nombre;
                                txt1.Name = corre.Nombre+"1";
                                txt1.ValueType = typeof(string);
                                txt1.MaxInputLength = corre.Tamaño;
                                dgvDato.Columns.Add(txt1);
                            }
                        break;
                        case "char": tam += 2;
                                txt = new DataGridViewTextBoxColumn();
                                txt.HeaderText = corre.Nombre;
                                txt.Name = corre.Nombre;
                                txt.ValueType = typeof(char);
                                txt.MaxInputLength = 7;
                                dgvDS.Columns.Add(txt);
                                txt1 = new DataGridViewTextBoxColumn();
                                txt1.HeaderText = corre.Nombre;
                                txt1.Name = corre.Nombre+"1";
                                txt1.ValueType = typeof(char);
                                txt1.MaxInputLength = 7;
                                dgvDato.Columns.Add(txt1);
                        break;
                        case "boolean": tam += 1;
                                txt = new DataGridViewTextBoxColumn();
                                txt.HeaderText = corre.Nombre;
                                txt.Name = corre.Nombre;
                                txt.ValueType = typeof(Boolean);
                                txt.MaxInputLength = 7;
                                dgvDS.Columns.Add(txt);
                                txt1 = new DataGridViewTextBoxColumn();
                                txt1.HeaderText = corre.Nombre;
                                txt1.Name = corre.Nombre+"1";
                                txt1.ValueType = typeof(Boolean);
                                txt1.MaxInputLength = 7;
                                dgvDato.Columns.Add(txt1);
                        break;
                    }
                }
                tam += 8;
                /*DataGridViewTextBoxColumn di = new DataGridViewTextBoxColumn();
                di.HeaderText = "Estado";
                di.Name = "Estado";
                dgvDS.Columns.Add(di);
                /*DataGridViewTextBoxColumn si = new DataGridViewTextBoxColumn();
                si.HeaderText = "AptSigDatos";
                si.Name = "AptSigDatos";
                dgvDS.Columns.Add(si);*/
            }

            if (LE[inddgvE].AptDatos != -1)
            {
                bloque = new CBloque(tam);
                bloque.Dir = LE[inddgvE].AptDatos;
                bloque.Bloque = arch.LeeBloque(nomsec, tam, bloque.Dir);
                if (inddgvE < LE.Count)
                    LA = arch.abrirArchivoAtributo(nomsec, LE[inddgvE]);
                while (bandF)
                {
                    bloque.Des = 0;
                    dgvDS.Rows.Add();
                    
                    //dgvDS.Rows[iFA].Cells[dgvDS.ColumnCount-1].Value = "Activo"; Era Para Mostrar si estaba dado de baja
                    
                    for (int i = 0; i < LA.Count/*-6*/; i++)//-6 para no tomar en cuenta los ultimos atributos
                    {
                        switch (LA[i].TipoDato)
                        {
                            case "int":
                                datI = bloque.sacaInt(4);
                                if (LA[i].Nombre != "Id_Usu_Mod" && LA[i].Nombre != "Id_Usu_Alt" && LA[i].Nombre != "Id_Usu_Baj")
                                {
                                    dgvDS.Rows[iFA].Cells[i].Value = datI;
                                }
                                break;
                            case "float":
                                datD = bloque.sacaFloat(8);
                                dgvDS.Rows[iFA].Cells[i].Value = datD;
                                break;
                            case "char":
                                datC = bloque.sacaChar(2);
                                dgvDS.Rows[iFA].Cells[i].Value = datC;
                                break;
                            case "string":
                                dS = bloque.sacaString(LA[i].Tamaño);
                                if (LA[i].Nombre != "Fecha_Mod" && LA[i].Nombre != "Fecha_Alta" && LA[i].Nombre != "Fecha_Baja")
                                {
                                    dgvDS.Rows[iFA].Cells[i].Value = dS;
                                }
                                if (LA[i].Nombre == "Fecha_Baja" && dS.Length>0)
                                {
                                    cambiaCF();
                                }
                                break;
                            case "boolean":
                                b = bloque.sacaBool(1);
                                dgvDS.Rows[iFA].Cells[i].Value = b;
                                break;
                        }
                    }
                    bloque.sacaSiguiente();
                    /*dgvDS.Rows[iFA].Cells[dgvDS.ColumnCount - 2].Value = bloque.Dir;
                    dgvDS.Rows[iFA].Cells[dgvDS.ColumnCount - 1].Value = bloque.Siguiente;*/
                    
                    if (bloque.Siguiente == -1)
                    {
                        bandF = false;
                    }
                    else
                    {
                        bloque.Bloque = arch.LeeBloque(nomsec, tam, bloque.Siguiente);
                        bloque.Dir = bloque.Siguiente;
                        iFA++;
                    }
                }
            }
            dgvDS_SelectionChanged(sender, e);
        }

        /* Este metodo incializa las variables
         * del nuevo dialogo y lo carga para que
         * el usuario pueda ingresar datos
         * de ser necesario llama al metodo entidadExterna
         */
        private void bGuardar_Click(object sender, EventArgs e)
        {
            CIngreDat idat = new CIngreDat();

            tam = 0;
            LA.Clear();
            idat.dgvIngreDat.Columns.Clear();
            idat.dgvIngreDat.Rows.Clear();

            indE = inddgvE = dgvES.CurrentRow.Index;

            if (LE.Count > 0)
            {
                if (inddgvE < LE.Count)
                    LA = arch.abrirArchivoAtributo(nomsec, LE[inddgvE]);
                foreach (CAtributo corre in LA)
                {
                    switch (corre.TipoDato)
                    {
                        case "int": tam += 4;
                            if (corre.Nombre != "Id_Usu_Alt" && corre.Nombre != "Id_Usu_Baj" && corre.Nombre != "Id_Usu_Mod")
                            {
                                if (corre.TipoClave == 2)
                                {
                                    /*DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
                                    combo = datoEntExt(corre);
                                    combo.HeaderText = corre.Nombre;
                                    combo.Name = corre.Nombre;
                                    combo.ValueType = typeof(Int32);
                                    idat.dgvIngreDat.Columns.Add(combo);*/
                                }
                                //else
                                {
                                    DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
                                    txt.HeaderText = corre.Nombre;
                                    txt.Name = corre.Nombre;
                                    txt.ValueType = typeof(Int32);
                                    txt.MaxInputLength = 7;
                                    idat.dgvIngreDat.Columns.Add(txt);
                                }
                            }
                            break;
                        case "float": tam += 8;
                            if (corre.TipoClave == 2)
                            {
                                /*DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
                                combo = datoEntExt(corre);
                                combo.HeaderText = corre.Nombre;
                                combo.Name = corre.Nombre;
                                combo.ValueType = typeof(float);
                                idat.dgvIngreDat.Columns.Add(combo);*/
                            }
                            //else
                            {
                                DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
                                txt.HeaderText = corre.Nombre;
                                txt.Name = corre.Nombre;
                                txt.ValueType = typeof(float);
                                txt.MaxInputLength = 7;
                                idat.dgvIngreDat.Columns.Add(txt);
                            }
                            break;
                        case "string": tam += (corre.Tamaño*2);
                            if (corre.Nombre != "Fecha_Alta" && corre.Nombre != "Fecha_Baja" && corre.Nombre != "Fecha_Mod")
                            {
                                if (corre.TipoClave == 2)
                                {
                                /*    DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
                                    combo = datoEntExt(corre);
                                    combo.HeaderText = corre.Nombre;
                                    combo.Name = corre.Nombre;
                                    combo.ValueType = typeof(string);
                                    idat.dgvIngreDat.Columns.Add(combo);*/
                                }
                                //else
                                {
                                    DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
                                    txt.HeaderText = corre.Nombre;
                                    txt.Name = corre.Nombre;
                                    txt.ValueType = typeof(string);
                                    txt.MaxInputLength = corre.Tamaño;
                                    idat.dgvIngreDat.Columns.Add(txt);
                                }
                            }
                            break;
                        case "char": tam += 2;
                            if (corre.TipoClave == 2)
                            {/*
                                DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
                                combo = datoEntExt(corre);
                                combo.HeaderText = corre.Nombre;
                                combo.Name = corre.Nombre;
                                combo.ValueType = typeof(char);
                                idat.dgvIngreDat.Columns.Add(combo);*/
                            }
                            //else
                            {
                                DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
                                txt.HeaderText = corre.Nombre;
                                txt.Name = corre.Nombre;
                                txt.ValueType = typeof(char);
                                txt.MaxInputLength = 1;
                                idat.dgvIngreDat.Columns.Add(txt);
                            }
                            break;
                        case "boolean": tam += 1;
                            if (corre.TipoClave == 2)
                            {
                              /*  DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
                                combo = datoEntExt(corre);
                                combo.HeaderText = corre.Nombre;
                                combo.Name = corre.Nombre;
                                combo.ValueType = typeof(Boolean);
                                idat.dgvIngreDat.Columns.Add(combo);*/
                            }
                            //else
                            {
                                DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
                                txt.HeaderText = corre.Nombre;
                                txt.Name = corre.Nombre;
                                txt.ValueType = typeof(Boolean);
                                txt.MaxInputLength = 7;
                                idat.dgvIngreDat.Columns.Add(txt);
                            }
                            break;
                    }
                }
                tam += 8;
                idat.dgvIngreDat.Rows.Add();
            }

            idat.Tam = tam;
            idat.NomSec = nomsec;
            idat.IndEnt = inddgvE;
            idat.idUs = iu+1;
            if (idat.ShowDialog() == DialogResult.OK)
            {
                dgvES.Rows.Clear();
                //CSecuencial_Load(sender, e);
                LE = arch.abrirArchivo(nomsec, cab);
                foreach (CEntidad corre in LE)
                {
                    dgvES.Rows.Add(corre.Nombre, corre.Direccion, corre.AptEntidad, corre.AptAtributo, corre.AptDatos);
                }
                dgvES_SelectionChanged(sender, e);
            }
        }

        /* Este metodo se encarga de crear un combobox
         * y lo llena con los datos que con tiene la entidad
         * externa del atributo y lo retorna
         */
        private DataGridViewComboBoxColumn datoEntExt(CAtributo a)
        {
            DataGridViewComboBoxColumn co = new DataGridViewComboBoxColumn();
            CBloque bl;
            int t=0, des=0, datI, ts=0;
            string tipo="";
            double datD;
            char datC;
            string dS;
            bool b, bandF=true;
            
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
                                case "int"      : t += 4;           break;
                                case "float"    : t += 8;           break;
                                case "char"     : t += 2;           break;
                                case "string"   : t += ca.Tamaño*2; break;
                                case "boolean"  : t += 1;           break;
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
                                    co.Items.Add(datI);
                                    break;
                                case "float":
                                    datD = bl.sacaFloat(8);
                                    co.Items.Add(datD);
                                    break;
                                case "char":
                                    datC = bl.sacaChar(2);
                                    co.Items.Add(datC);
                                    break;
                                case "string":
                                    dS = bl.sacaString(ts);
                                    co.Items.Add(dS);
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
    
            return co;
        }

        /* Este metodo se encarga de empaquetar los datos del 
         * reglon seleccionado en el dataGrid de los datos
         * hace una busqueda en el archivo del bloque, cuando
         * lo encuentra modifica los apuntadores
         */
        private void bBajaDato_Click(object sender, EventArgs e)
        {
            int indD = dgvDS.CurrentRow.Index, i;
            int indA = 0, des=0;
            cab = -1;
            Boolean enc = false;
            CBloque aux = new CBloque(tam);
            CBloque ant = new CBloque(tam);

            if (MessageBox.Show("Esta Seguro de que Desea dar de Baja el Dato? ", "Confirmar Baja", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bloque = new CBloque(tam);
                if (indE < LE.Count)
                    LA = arch.abrirArchivoAtributo(nomsec, LE[indE]);

                for (i = 0; i < LA.Count() - 6; i++)//-6 para no tomar en cuenta los ultimos atributos
                {
                    bloque.empaqueta(dgvDS[i, indD].Value.ToString(), LA[i].TipoDato, LA[i].Tamaño);
                }

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
                if (false == buscaRel(LE[indE].Direccion, bloque))
                {
                    bloque.Des = aux.Des = des;

                    if (aux.comparaTo(bloque, LA[indA].TipoDato) == 0)  //1 si aux>bloque  0 si aux==bloque -1 aux<bloque
                    {
                        //Baja Logica
                        bajaLogica(aux);
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
                                bajaLogica(aux);
                                /*aux.sacaSiguiente();
                                ant.Siguiente = aux.Siguiente;
                                ant.empaquetaSig(ant.Siguiente);
                                arch.EscribeBloque(ant);*/
                                //dgvDS.Rows[indD].Cells[dgvDS.ColumnCount - 1].Value = "Baja Logica";
                            }
                            aux.sacaSiguiente();
                        }
                    }
                }
                else
                    MessageBox.Show("NO SE PUEDO ELIMINAR Hay datos Relacionados");
                dgvES.Rows.Clear();
                //CSecuencial_Load(sender, e);
                LE = arch.abrirArchivo(nomsec, cab);
                foreach (CEntidad corre in LE)
                {
                    dgvES.Rows.Add(corre.Nombre, corre.Direccion, corre.AptEntidad, corre.AptAtributo, corre.AptDatos);
                }
                dgvES_SelectionChanged(sender, e);
            }
        }

        private void bajaModifica(object sender, EventArgs e)
        {
            int indD = dgvDS.CurrentRow.Index, i;
            int indA = 0, des = 0;
            cab = -1;
            Boolean enc = false;
            CBloque aux = new CBloque(tam);
            CBloque ant = new CBloque(tam);


            bloque = new CBloque(tam);
            if (indE < LE.Count)
                LA = arch.abrirArchivoAtributo(nomsec, LE[indE]);

            for (i = 0; i < LA.Count(); i++)
            {
                bloque.empaqueta(dgvDS[i, indD].Value.ToString(), LA[i].TipoDato, LA[i].Tamaño);
            }

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
            
            if (aux.comparaTo(bloque, LA[indA].TipoDato) == 0)  //1 si aux>bloque  0 si aux==bloque -1 aux<bloque
            {
                aux.sacaSiguiente();
                LE[indE].AptDatos = aux.Siguiente;
                arch.EscribeEntidad(LE[indE]);
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
                    bloque.Des = aux.Des = 0;
                    if (aux.comparaTo(bloque, LA[indA].TipoDato) == 0)
                    {
                        enc = true;
                        aux.sacaSiguiente();
                        ant.Siguiente = aux.Siguiente;
                        ant.empaquetaSig(ant.Siguiente);
                        arch.EscribeBloque(ant);
                    }
                    aux.sacaSiguiente();
                }
            }
            dgvES.Rows.Clear();
            //CSecuencial_Load(sender, e);
            LE = arch.abrirArchivo(nomsec, cab);
            foreach (CEntidad corre in LE)
            {
                dgvES.Rows.Add(corre.Nombre, corre.Direccion, corre.AptEntidad, corre.AptAtributo, corre.AptDatos);
            }
            dgvES_SelectionChanged(sender, e);
        }

        private bool buscaRel(long dirEnt, CBloque bloque)
        {
            List<CAtributo> la = new List<CAtributo>();
            CBloque aux;
            int t = 0, des = 0, ts;
            string tipo = "";

            foreach (CEntidad e in LE)
            {
                t = des = 0;
                la = arch.abrirArchivoAtributo(nomsec, e);

                foreach (CAtributo ca in la)
                {
                    if (ca.TipoClave == 2 && ca.AptEntidad == dirEnt)
                    {
                        des = t;
                        tipo = ca.TipoDato;
                        ts = ca.Tamaño;
                        //return true;
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


                foreach (CAtributo a in la)
                {
                    if (a.TipoClave == 2 && a.AptEntidad == dirEnt && e.AptDatos != -1)
                    {
                        aux = new CBloque(t);
                        aux.Bloque = arch.LeeBloque(nomsec, t, e.AptDatos);
                        aux.Dir = e.AptDatos;
                        aux.Des = des;
                        bajaBloque(bloque, aux, tipo, e);
                        
                    }
                }
            }
            return false;
        }

        private void bajaBloque(CBloque bloque, CBloque aux, string td, CEntidad ent)
        {
            CBloque ant = new CBloque(aux.Tam);
            List<CAtributo> la = new List<CAtributo>();
            bool enc = false;
            int des = bloque.Des, da = aux.Des;

            la = arch.abrirArchivoAtributo(nomsec, ent);

            if (aux.comparaTo(bloque, td) == 0)  //1 si aux>bloque  0 si aux==bloque -1 aux<bloque
            {
                //Baja Logica
                bajaLogica(aux);
                /*aux.sacaSiguiente();
                ent.AptDatos = aux.Siguiente;
                arch.EscribeEntidad(ent);*/
                aux.Des = 0;
                foreach (CAtributo ca in la)
                {
                    if (ca.TipoClave == 1)
                        break;
                    switch (ca.TipoDato)
                    {
                        case "int": aux.Des += 4; break;
                        case "float": aux.Des += 8; break;
                        case "char": aux.Des += 2; break;
                        case "string": aux.Des += ca.Tamaño * 2; break;
                        case "boolean": aux.Des += 1; break;
                    }
                }
                //buscaRel(ent.Direccion, aux);

            }
            //else
            {
                aux.sacaSiguiente();
                while (aux.Siguiente != -1/* && !enc*/)
                {
                    ant.Bloque = aux.Bloque;
                    ant.Dir = aux.Dir;
                    ant.sacaSiguiente();
                    aux.Bloque = arch.LeeBloque(nomsec, aux.Tam, ant.Siguiente);
                    aux.Dir = ant.Siguiente;
                    bloque.Des = des;
                    aux.Des = da;
                    if (aux.comparaTo(bloque, td) == 0)
                    {
                        //enc = true; Afuerza se tiene que recorrer todos los bloques
                        bajaLogica(aux);
                        /*aux.sacaSiguiente();
                        ant.Siguiente = aux.Siguiente;
                        ant.empaquetaSig(ant.Siguiente);
                        arch.EscribeBloque(ant);*/

                        aux.Des = 0;
                        foreach (CAtributo ca in la)
                        {
                            if (ca.TipoClave == 1)
                                break;
                            switch (ca.TipoDato)
                            {
                                case "int": aux.Des += 4; break;
                                case "float": aux.Des += 8; break;
                                case "char": aux.Des += 2; break;
                                case "string": aux.Des += ca.Tamaño * 2; break;
                                case "boolean": aux.Des += 1; break;
                            }
                        }
                        //buscaRel(ent.Direccion, aux); Sin este Solo busca relacion con el bloque escogido del data
                        //solo hace un escalon en la cascada, si el dato relacionando tiene un nivel mas de relacion no 
                        //se borra el otro dato
                    }
                    aux.sacaSiguiente();
                }
            }
        }

        /* Este metodo se encarga de empaquetar los datos del 
         * reglon seleccionado del dataGrid de datos,
         * recorre el archivo, al encontrarlo llama
         * al metodo de cargaModifica
         */
        private void bModificaDato_Click(object sender, EventArgs e)
        {
            int indD = dgvDS.CurrentRow.Index, i;
            int indA = 0, des;
            cab = -1;
            Boolean enc = false;
            CBloque aux = new CBloque(tam);
            CBloque ant = new CBloque(tam);
                        
            bloque = new CBloque(tam);
            if (indE < LE.Count)
                LA = arch.abrirArchivoAtributo(nomsec, LE[indE]);

            for (i = 0; i < LA.Count()-6; i++)//El -6 por las fechas
            {
                bloque.empaqueta(dgvDS[i, indD].Value.ToString(), LA[i].TipoDato, LA[i].Tamaño);
            }

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
            if (aux.comparaTo(bloque, LA[indA].TipoDato) == 0)  //1 si aux>bloque  0 si aux==bloque -1 aux<bloque
            {
                //Aqui se manda a llamar
                cargaModifica(aux, sender, e);
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
                        cargaModifica(aux, sender, e);
                    }
                    aux.sacaSiguiente();
                }
            }
            
        }
        
        /* Este metodo carga el dialogo con los datos recuperados
         * para que puedan ser modificado
         */
        private void cargaModifica(CBloque b, object sender, EventArgs e)
        {
            //DataGridViewTextBoxColumn txt, txt1;
            int i;
            tam = 0;
            CModSDat idat = new CModSDat(iu);
            idat.NomSec = nomsec;
            idat.IndEnt = inddgvE;

            for (i = 0; i < LA.Count;i++) 
            {
                switch (LA[i].TipoDato)
                {
                    case "int": tam += 4;
                        if (LA[i].Nombre != "Id_Usu_Alt" && LA[i].Nombre != "Id_Usu_Baj" && LA[i].Nombre != "Id_Usu_Mod")
                        {
                            /*if (LA[i].TipoClave == 2)
                            {
                                DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
                                combo = datoEntExt(LA[i]);
                                combo.HeaderText = LA[i].Nombre;
                                combo.Name = LA[i].Nombre;
                                combo.ValueType = typeof(Int32);
                                idat.dgvIngreDat.Columns.Add(combo);
                            }
                            else*/
                            {
                                DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
                                txt.HeaderText = LA[i].Nombre;
                                txt.Name = LA[i].Nombre;
                                txt.ValueType = typeof(Int32);
                                txt.MaxInputLength = 7;
                                idat.dgvIngreDat.Columns.Add(txt);
                            }
                        }
                        break;
                    case "float": tam += 8;
                        /*if (LA[i].TipoClave == 2)
                        {
                            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
                            combo = datoEntExt(LA[i]);
                            combo.HeaderText = LA[i].Nombre;
                            combo.Name = LA[i].Nombre;
                            combo.ValueType = typeof(float);
                            idat.dgvIngreDat.Columns.Add(combo);
                        }
                        else*/
                        {
                            DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
                            txt.HeaderText = LA[i].Nombre;
                            txt.Name = LA[i].Nombre;
                            txt.ValueType = typeof(float);
                            txt.MaxInputLength = 7;
                            idat.dgvIngreDat.Columns.Add(txt);
                        }
                        break;
                    case "string": tam += (LA[i].Tamaño * 2);
                        if (LA[i].Nombre != "Fecha_Alta" && LA[i].Nombre != "Fecha_Baja" && LA[i].Nombre != "Fecha_Mod")
                        {
                            /*if (LA[i].TipoClave == 2)
                            {
                                DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
                                combo = datoEntExt(LA[i]);
                                combo.HeaderText = LA[i].Nombre;
                                combo.Name = LA[i].Nombre;
                                combo.ValueType = typeof(string);
                                idat.dgvIngreDat.Columns.Add(combo);
                            }
                            else*/
                            {
                                DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
                                txt.HeaderText = LA[i].Nombre;
                                txt.Name = LA[i].Nombre;
                                txt.ValueType = typeof(string);
                                txt.MaxInputLength = LA[i].Tamaño;
                                idat.dgvIngreDat.Columns.Add(txt);
                            }
                        }
                        break;
                    case "char": tam += 2;
                        /*if (LA[i].TipoClave == 2)
                        {
                            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
                            combo = datoEntExt(LA[i]);
                            combo.HeaderText = LA[i].Nombre;
                            combo.Name = LA[i].Nombre;
                            combo.ValueType = typeof(char);
                            idat.dgvIngreDat.Columns.Add(combo);
                        }
                        else*/
                        {
                            DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
                            txt.HeaderText = LA[i].Nombre;
                            txt.Name = LA[i].Nombre;
                            txt.ValueType = typeof(char);
                            txt.MaxInputLength = 1;
                            idat.dgvIngreDat.Columns.Add(txt);
                        }
                        break;
                    case "boolean": tam += 1;
                        /*if (LA[i].TipoClave == 2)
                        {
                            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
                            combo = datoEntExt(LA[i]);
                            combo.HeaderText = LA[i].Nombre;
                            combo.Name = LA[i].Nombre;
                            combo.ValueType = typeof(Boolean);
                            idat.dgvIngreDat.Columns.Add(combo);
                        }
                        else*/
                        {
                            DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
                            txt.HeaderText = LA[i].Nombre;
                            txt.Name = LA[i].Nombre;
                            txt.ValueType = typeof(Boolean);
                            txt.MaxInputLength = 7;
                            idat.dgvIngreDat.Columns.Add(txt);
                        }
                        break;
                }
            }
            tam += 8;
            idat.dgvIngreDat.Rows.Add();
            idat.DirA = b.Dir;
            b.Des = 0;
            for (i = 0; i < LA.Count-6; i++)
            {
                switch (LA[i].TipoDato)
                {
                    case "int":
                        /*if (LA[i].TipoClave != 2)*/
                        {
                            idat.dgvIngreDat[i, 0].Value = b.sacaInt(4);
                            if (LA[i].TipoClave == 1 || LA[i].TipoClave ==2)
                                idat.dgvIngreDat[i, 0].ReadOnly = true;
                        }
                        break;
                    case "float":
                        //if (LA[i].TipoClave != 2)
                        {
                            idat.dgvIngreDat[i, 0].Value = b.sacaFloat(8);
                            if (LA[i].TipoClave == 1 || LA[i].TipoClave == 2)
                                idat.dgvIngreDat[i, 0].ReadOnly = true;
                        }
                        break;
                    case "string":
                        //if (LA[i].TipoClave != 2)
                        {
                            idat.dgvIngreDat[i, 0].Value = b.sacaString(LA[i].Tamaño);
                            if (LA[i].TipoClave == 1 || LA[i].TipoClave == 2)
                                idat.dgvIngreDat[i, 0].ReadOnly = true;
                        }
                        break;
                    case "char":
                        //if (LA[i].TipoClave != 2)
                        {
                            idat.dgvIngreDat[i, 0].Value = b.sacaChar(2);
                            if (LA[i].TipoClave == 1 || LA[i].TipoClave == 2)
                                idat.dgvIngreDat[i, 0].ReadOnly = true;
                        }
                        break;
                    case "boolean":
                        //if (LA[i].TipoClave != 2)
                        {
                            idat.dgvIngreDat[i, 0].Value = b.sacaBool(1);
                            if (LA[i].TipoClave == 1 || LA[i].TipoClave == 2)
                                idat.dgvIngreDat[i, 0].ReadOnly = true;
                        }
                        break;
                }
            }

            
            idat.Tam = tam;
            idat.NomSec = nomsec;
            idat.IndEnt = inddgvE;
            if (idat.ShowDialog() == DialogResult.OK)
            {
                //bajaModifica(sender, e);
                dgvES.Rows.Clear();
                //CSecuencial_Load(sender, e);
                LE = arch.abrirArchivo(nomsec, cab);
                foreach (CEntidad corre in LE)
                {
                    dgvES.Rows.Add(corre.Nombre, corre.Direccion, corre.AptEntidad, corre.AptAtributo, corre.AptDatos);
                }
                dgvES_SelectionChanged(sender, e);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lHora.Text = DateTime.Now.ToLongTimeString();
            lFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void mAbrir_Click(object sender, EventArgs e)
        {
            DNombre dm = new DNombre();
            string noma;
            iu=0;
            consultas = false;
            

            CAtributo a = new CAtributo();
            dAbrirCrear.Filter = "ficheros .sec (*.sec) | *.sec";
            if (dAbrirCrear.ShowDialog() == DialogResult.OK)
            {
                noma = dAbrirCrear.FileName;
                nomsec = noma.Substring(noma.LastIndexOf("\\") + 1);
                cargarUsuarios(noma);
                iu = validaUsuario();

                if (iu != -1)
                {
                    activaPermisos();
                    LE = arch.abrirArchivo(noma, cab);
                    dgvES.Rows.Clear();
                    
                    foreach (CEntidad corre in LE)
                    {
                        dgvES.Rows.Add(corre.Nombre, corre.Direccion, corre.AptEntidad, corre.AptAtributo, corre.AptDatos);
                    }
                    lUsuario.Text = LU[iu].nombre;
                }
                else
                {
                    MessageBox.Show("No se puede Abrir la Base de Datos:\n" +
                                    "Verifique que sus datos sean correctos y\n"+
                                    "Tenga los permisos suficientes");
                    bGuardar.Enabled = false;
                    bBajaDato.Enabled = false;
                    bModificaDato.Enabled = false;
                }
            }

            dgvDS.Visible = true;
            dgvDato.Visible = false;
            bBuscar.Visible = false;
            tbClave.Visible = false;
        }

        private void mCrear_Click(object sender, EventArgs e)
        {
            CMantenimiento md = new CMantenimiento();
            DNombre dm = new DNombre();
            iu=0;
            string noma;
            
            CAtributo a = new CAtributo();
            dAbrirCrear.Filter = "ficheros .dbd (*.dbd) | *.dbd";
            if(dAbrirCrear.ShowDialog()  == DialogResult.OK)
            {
                dgvES.Rows.Clear();
                dgvDato.Rows.Clear();
                dgvDS.Rows.Clear();
                

                noma = dAbrirCrear.FileName;
                noma = noma.Substring(noma.LastIndexOf("\\") + 1);
                cargarUsuarios(noma);
                iu=validaUsuario();
                if (iu != -1 && LU[iu].permisos[0] && dm.ShowDialog() == DialogResult.OK)
                {
                    activaPermisos();

                    nomsec = dm.tbNom.Text+".sec";
                    if (!File.Exists(nomsec))
                    {
                        File.Copy(noma, nomsec);
                        noma = noma.Substring(0, noma.Length - 4);
                        nomsec = nomsec.Substring(0, nomsec.Length - 4);
                        if(!File.Exists(nomsec+".usr"))
                            File.Copy(noma+".usr", nomsec + ".usr");
                        nomsec = nomsec + ".sec";

                        LE = arch.abrirArchivo(nomsec, cab);
                        foreach (CEntidad corre in LE)
                        {
                            dgvES.Rows.Add(corre.Nombre);
                            
                        }
                        lUsuario.Text = LU[iu].nombre;
                    }
                    else
                        MessageBox.Show("El Nombre de Archivo ya Existe, Intenta Otro");
                }
                else
                {
                    if (iu == -1)
                        MessageBox.Show("No se puede crear la Base de Datos:\n" +
                                   "Verifique que sus datos sean correctos y\n" +
                                   "Tenga los permisos necesarios para crearla");
                    if (iu!=-1 && dm.DialogResult != DialogResult.Cancel)
                        MessageBox.Show("No se puede crear la Base de Datos:\n" +
                                   "Verifique que sus datos sean correctos y\n" +
                                   "Tenga los permisos necesarios para crearla");
                    bGuardar.Enabled = false;
                    bBajaDato.Enabled = false;
                    bModificaDato.Enabled = false;
                }
                
            }
            
        
        }

        public void cargarUsuarios(string nom)
        {
            nom = nom.Substring(0, nom.Length - 4);
            FileStream fs = new FileStream(nom + ".usr", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                LU = (List<CUser>)formatter.Deserialize(fs);
            }
            catch (Exception)
            {
                MessageBox.Show("No se puede abrir el archivo");
            }
            finally
            {
                fs.Close();
            }
        }

        public int validaUsuario()
        {
            CLogin dl = new CLogin();

            if (dl.ShowDialog() == DialogResult.OK)
            {
                for(int i=0; i < LU.Count; i++)
                {
                    if (LU[i].nombre == dl.tbUsuario.Text && LU[i].pass == dl.tbContraseña.Text)
                    {
                        if (validarHorayDia(LU[i]))
                            return i;
                        else
                            return -1;
                    }
                }
            }
            return -1;
        }

        public bool validarHorayDia(CUser usuario)
        {
            DayOfWeek dia =  DateTime.Now.DayOfWeek;
            string fecha = DateTime.Now.ToShortDateString();
            string hora = DateTime.Now.ToLongTimeString();
            DateTime Actual = Convert.ToDateTime(fecha +" "+ hora);
            DateTime Inicial = Convert.ToDateTime(fecha + " " + usuario.hInicial);
            DateTime Final = Convert.ToDateTime(fecha + " " + usuario.hFinal);
            int i;

            for(i=0; i<usuario.dias.Length ;i++)
                switch (i)
                {
                    case 0:
                        if (usuario.dias[i] && dia == DayOfWeek.Monday)
                            if (DateTime.Compare(Inicial, Actual) <= 0 && DateTime.Compare(Final, Actual) >= 0)
                                return true;
                    break;
                    case 1:
                    if (usuario.dias[i] && dia == DayOfWeek.Tuesday)
                        if (DateTime.Compare(Inicial, Actual) <= 0 && DateTime.Compare(Final, Actual) >= 0)
                            return true;
                    break;
                    case 2:
                    if (usuario.dias[i] && dia == DayOfWeek.Wednesday)
                        if (DateTime.Compare(Inicial, Actual) <= 0 && DateTime.Compare(Final, Actual) >= 0)
                            return true;
                    break;
                    case 3:
                    if (usuario.dias[i] && dia == DayOfWeek.Thursday)
                        if (DateTime.Compare(Inicial, Actual) <= 0 && DateTime.Compare(Final, Actual) >= 0)
                            return true;
                    break;
                    case 4:
                    if (usuario.dias[i] && dia == DayOfWeek.Friday)
                        if (DateTime.Compare(Inicial, Actual) <= 0 && DateTime.Compare(Final, Actual) >= 0)
                            return true;
                    break;
                    case 5:
                    if (usuario.dias[i] && dia == DayOfWeek.Saturday)
                        if (DateTime.Compare(Inicial, Actual) <= 0 && DateTime.Compare(Final, Actual) >= 0)
                            return true;
                    break;
                    case 6:
                    if (usuario.dias[i] && dia == DayOfWeek.Sunday)
                        if (DateTime.Compare(Inicial, Actual) <= 0 && DateTime.Compare(Final, Actual) >= 0)
                            return true;
                    break;
                }
            

            return false;
        }

        public void activaPermisos()
        {
            if(!consultas)
            for (int i = 0; i < 4; i++)
                switch (i)
                {
                    case 0:
                        if (LU[iu].permisos[i])
                            bGuardar.Enabled = true;
                        else
                            bGuardar.Enabled = false;
                    break;
                    case 1:
                        if (LU[iu].permisos[i])
                            bBajaDato.Enabled = true;
                        else
                            bBajaDato.Enabled = false;
                    break;
                    case 3:
                        if (LU[iu].permisos[i])
                            bModificaDato.Enabled = true;
                        else
                            bModificaDato.Enabled = false;
                    break;
                }
        }

        private void bBuscar_Click(object sender, EventArgs e)
        {
            bool b=false;
            dgvDato.Rows.Clear();
            int i, j, ind=-1;

            if (dgvDS.ColumnCount > 0)
            {
                inddgvE = dgvES.CurrentRow.Index;
                if (inddgvE < LE.Count)
                    LA = arch.abrirArchivoAtributo(nomsec, LE[inddgvE]);

                for (i = 0; i < LA.Count - 6; i++)
                    if (LA[i].TipoClave == 1)
                    {
                        ind = i;
                    }

                if (ind != -1)
                {
                    for (i = 0; i < dgvDS.RowCount; i++)
                    {
                        if (dgvDS[ind, i].Value.ToString() == tbClave.Text)
                        {
                            b = true;
                            dgvDato.Rows.Add();
                            for (j = 0; j < LA.Count - 6; j++)
                            {
                                dgvDato[j, 0].Value = dgvDS[j, i].Value.ToString();
                            }
                        }
                    }

                }
                if (!b)
                    MessageBox.Show("La Clave No Existe");
                tbClave.Text = "";
            }

        }

        private void mAbrirConsultas_Click(object sender, EventArgs e)
        {
            mAbrir_Click(null, null);

            consultas = true;
            dgvDS.Visible = false;
            dgvDato.Visible = true;
            bBuscar.Visible = true;
            tbClave.Visible = true;
            bGuardar.Enabled = false;
            bBajaDato.Enabled = false;
            bModificaDato.Enabled = false;
        }

        private void tbClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                bBuscar_Click(null, null);
        }

        private void bajaLogica(CBloque b)
        {
            string fecha;
            b.Des = b.Bloque.Length - 56;
            fecha = DateTime.Today.ToString("d");
            b.empaqueta(fecha, "string", 10);
            b.empaqueta((iu+1).ToString(), "int", 4);
            arch.EscribeBloque(b);
        }

        private void cambiaCF()
        {
            int r=dgvDS.RowCount-1;

            dgvDS.Rows[r].DefaultCellStyle.BackColor = Color.Red;
            
        }

        private void dgvDS_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDS.RowCount > 0)
            {
                int indr = dgvDS.CurrentRow.Index;

                if (dgvDS.Rows[indr].DefaultCellStyle.BackColor == Color.Red)
                {
                    bBajaDato.Enabled = false;
                    bModificaDato.Enabled = false;

                }
                else
                {
                    activaPermisos();
                }
            }
        }

        private void mNRespaldo_Click(object sender, EventArgs e)
        {
            FormRespaldos fr = new FormRespaldos(nomsec);

            fr.ShowDialog();
        }
    }
}


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
    public partial class FormSQL : Form
    {
        private CEntidad entA;
        private CEntidad entB;
        private CAtributo atrA;
        private CAtributo atrB;
        private List<CEntidad> lEA;
        private List<CEntidad> lEB;
        private List<CAtributo> lAA;
        private List<CAtributo> lAB;
        private CArchivo aA;
        private CArchivo aB;
        private TextBox tbA;
        private ComboBox cbB;
        private List<TextBox> lTA;
        private List<ComboBox> lCB;
        private string nomA;
        private string nomB;
        private long cabA;
        private long cabB;
        private CBloque bloque;

        public FormSQL()
        {
            InitializeComponent();
        }

        private void FormSQL_Load(object sender, EventArgs e)
        {
            cabA = -1;
            cabB = -1;
            aA = new CArchivo();
            aB = new CArchivo();
            lEA = new List<CEntidad>();
            lEB = new List<CEntidad>();
            lAA = new List<CAtributo>();
            lAB = new List<CAtributo>();
            lTA = new List<TextBox>();
            lCB = new List<ComboBox>();
            entA = new CEntidad();
            entB = new CEntidad();
            atrA = new CAtributo();
            atrB = new CAtributo();

            tbInnerJoin.Text = "";
            dgvInnerJoin.Rows.Clear();
        }

        #region Importar
        private void mImportar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seleccione la Base De Datos Destino");
            dAbrir.Filter = "ficheros .sec (*.sec) | *.sec";
            if (dAbrir.ShowDialog() == DialogResult.OK)
            {
                nomA = dAbrir.FileName;
                lEA = aA.abrirArchivo(nomA, cabA);

                MessageBox.Show("Seleccione la Base De Datos Origen");
                dAbrir.Filter = "ficheros .sec (*.sec) | *.sec";
                if (dAbrir.ShowDialog() == DialogResult.OK)
                {
                    nomB = dAbrir.FileName;
                    lEB = aA.abrirArchivo(nomB, cabB);
                    mostrarBD();
                }
            }
        }

        public void mostrarBD()
        {
            int i;
            crearControles();

            for (i = 0; i < lTA.Count; i++)
            {
                //Controls.Add(lTA[i]);
                //Controls.Add(lCB[i]);
                tcImpCompleta.SelectedTab.Controls.Add(lTA[i]);
                tcImpCompleta.SelectedTab.Controls.Add(lCB[i]);
            }
            this.Height = 30 * lTA.Count + 220;
            tcImpCompleta.Size = new Size(740, 30 * lTA.Count + 180);
            //bImportar.Location = new Point(this.Width - (bImportar.Size.Width + 30), this.Height - (bImportar.Size.Height + 75));
        }

        public void crearControles()
        {
            int i, x = 10, y = 80;

            for (i = 0; i < lEA.Count; i++)
            {
                tbA = new TextBox();
                tbA.Name = "tb" + (i + 1);
                tbA.Text = lEA[i].Nombre;
                tbA.ReadOnly = true;
                tbA.BackColor = Color.White;
                tbA.TextAlign = HorizontalAlignment.Center;
                tbA.Font = new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold);
                tbA.Location = new Point(x, y);
                y += 30;
                lTA.Add(tbA);
            }

            x = 150;
            y = 80;
            for (i = 0; i < lEA.Count; i++)
            {
                cbB = new ComboBox();
                cbB = agregarEntCombo();
                cbB.Font = new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold);
                cbB.Name = "cb" + (i + 1);
                cbB.Text = "[Ninguna]";
                cbB.Location = new Point(x, y);
                y += 30;
                lCB.Add(cbB);
            }
        }

        public ComboBox agregarEntCombo()
        {
            ComboBox c = new ComboBox();
            string nomE;

            foreach (CEntidad e in lEB)
            {

                nomE = e.Nombre;
                c.Items.Add(nomE);
            }

            c.Items.Add("[Ninguna]");
            return c;
        }

        private void bImportar_Click(object sender, EventArgs e)
        {
            int i;
            bool entro = false;

            if (lEA.Count > 0 && lEB.Count > 0)
            {
                for (i = 0; i < lTA.Count; i++)
                {
                    entA = lEA[i];
                    if (lCB[i].Text != "[Ninguna]")
                    {
                        buscaEntyCopia(i, lCB[i].Text);
                        entro = true;
                    }
                }
                if (entro)
                    MessageBox.Show("La Importacion se ha realizado con exito");
                else
                    MessageBox.Show("No ha seleccionado entidades para importar");
            }
            else
                MessageBox.Show("Para Hacer la importacion\n" +
                                "Se Necesita la BD Origen y la BD Destino");
        }

        public void buscaEntyCopia(int iA, string nB)
        {
            int i;

            for (i = 0; i < lEB.Count; i++)
            {
                if (lEB[i].Nombre == nB)
                {
                    entB = lEB[i];
                    copiaDatos();
                    break;
                }
            }
        }

        public void copiaDatos()
        {
            int tam = sacaTam();
            long sig;
            CBloque ant = new CBloque(tam);
            bloque = new CBloque(tam);

            lAB = aB.abrirArchivoAtributo(nomB, entB);
            bloque.Bloque = aB.LeeBloque(nomB, tam, entB.AptDatos);
            bloque.Dir = entB.AptDatos;
            bloque.sacaSiguiente();
            sig = bloque.Siguiente;
            guarda(bloque);//Mandar a guardar a la entidad destino
            bloque.empaquetaSig(sig);
            bloque.sacaSiguiente();

            while (bloque.Siguiente != -1)
            {
                sig = bloque.Siguiente;
                bloque.Bloque = aB.LeeBloque(nomB, tam, bloque.Siguiente);
                bloque.Dir = sig;
                bloque.sacaSiguiente();
                sig = bloque.Siguiente;
                guarda(bloque);//Mandar a guardar a la entidad destino
                bloque.empaquetaSig(sig);
                bloque.sacaSiguiente();

            }

        }

        private void guarda(CBloque b)
        {
            bool existe = false, enc = false;
            int indA = 0, des;
            int tam = sacaTam();
            CBloque aux = new CBloque(tam);
            CBloque ant = new CBloque(tam);
            b.empaquetaSig(-1);


            if (entA.AptDatos == -1)
            {
                entA.AptDatos = b.Dir;
                aA.EscribeEntidad(entA);
            }
            else
            {
                aux.Bloque = aA.LeeBloque(nomA, tam, entA.AptDatos);
                aux.Dir = entA.AptDatos;
                aux.Des = 0;
                foreach (CAtributo ca in lAA)
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

                des = b.Des = aux.Des;
                if (aux.comparaTo(bloque, lAA[indA].TipoDato) == 1)  //1 si aux>bloque  0 si aux==bloque -1 aux<bloque
                {
                    b.Siguiente = entA.AptDatos;
                    b.empaquetaSig(b.Siguiente);
                    aA.EscribeBloque(b);
                    entA.AptDatos = b.Dir;
                    aA.EscribeEntidad(entA);
                }
                else
                {
                    b.Des = aux.Des = des;
                    if (aux.comparaTo(b, lAA[indA].TipoDato) == 0)
                    {
                        existe = true; //Encontro a un numero igual
                        //MessageBox.Show("La Clave ya Existe");
                    }
                    aux.sacaSiguiente();
                    while (aux.Siguiente != -1 && !enc)
                    {
                        ant.Bloque = aux.Bloque;
                        ant.Dir = aux.Dir;
                        ant.sacaSiguiente();
                        aux.Bloque = aA.LeeBloque(nomA, tam, ant.Siguiente);
                        aux.Dir = ant.Siguiente;
                        b.Des = aux.Des = des;
                        switch (aux.comparaTo(b, lAA[indA].TipoDato))
                        {
                            case 0:
                                existe = true; //Encontro a un numero igual
                                //MessageBox.Show("La Clave ya Existe");
                                break;
                            case 1:
                                enc = true; //Encontro a un numero mañor que el
                                break;
                        }
                        if (existe)
                            break;
                        if (enc && !existe)
                        {
                            b.Siguiente = aux.Dir;
                            b.empaquetaSig(b.Siguiente);
                            ant.Siguiente = b.Dir;
                            ant.empaquetaSig(ant.Siguiente);
                            aA.EscribeBloque(ant);
                        }
                        aux.sacaSiguiente();
                    }
                    if (!enc && !existe)
                    {
                        aux.Siguiente = b.Dir;
                        aux.empaquetaSig(aux.Siguiente);
                        aA.EscribeBloque(aux);
                    }
                }
            }
            if (!existe)
                aA.EscribeBloque(b);
        }

        public int sacaTam()
        {
            int tam = 0;

            lAA = aA.abrirArchivoAtributo(nomA, entA);
            foreach (CAtributo corre in lAA)
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
            return tam;
        }

        private void FormSQL_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (TextBox tb in lTA)
            {
                //this.Controls.Remove(tb);
                tcImpCompleta.SelectedTab.Controls.Remove(tb);
            }
            foreach (ComboBox cb in lCB)
            {
                //this.Controls.Remove(cb);
                tcImpCompleta.SelectedTab.Controls.Remove(cb);
            }

            tbConsulta.Text = "";
            tbTDestino.Text = "";

            lAA.Clear();
            lAB.Clear();
            lEA.Clear();
            lEB.Clear();
        }

        private void tcImpCompleta_Selecting(object sender, TabControlCancelEventArgs e)
        {
            foreach (TextBox tb in lTA)
            {
                //this.Controls.Remove(tb);
                tcImpCompleta.SelectedTab.Controls.Remove(tb);
            }
            foreach (ComboBox cb in lCB)
            {
                //this.Controls.Remove(cb);
                tcImpCompleta.SelectedTab.Controls.Remove(cb);
            }

            tbConsulta.Text = "";
            tbTDestino.Text = "";

            this.Size = new Size(756, 320);
            tcImpCompleta.Size = new Size(740, 281);
            lAA.Clear();
            lAB.Clear();
            lEA.Clear();
            lEB.Clear();
            lCB.Clear();
            lTA.Clear();

            dgvInnerJoin.Rows.Clear();
            dgvCrossJoin.Rows.Clear();
            dgvInnerJoin.Columns.Clear();
            dgvCrossJoin.Columns.Clear();
        }

        private void bImportarC_Click(object sender, EventArgs e)
        {
            //int i;
            bool completas = false;
            char[] caracter = {' ', '.'};
            string tDestino = tbTDestino.Text, consulta = tbConsulta.Text;;
            string[] pDestino = tDestino.Split(caracter);
            string[] pConsulta = consulta.Split(caracter);

            if (pDestino.Length == 2)
            {
                nomA = "C:\\Users\\DFJPMOSH\\Documents\\Visual Studio 2010\\Projects\\Base de Datos A\\Diccionario\\bin\\Debug\\" +
                    pDestino[0] + ".sec";
                if (pConsulta.Length == 9)
                {
                    nomB = "C:\\Users\\DFJPMOSH\\Documents\\Visual Studio 2010\\Projects\\Base de Datos A\\Diccionario\\bin\\Debug\\" +
                            pConsulta[3] + ".sec";
                    completas = true;
                }
                else
                    MessageBox.Show("La Consulta Esta Mal Escrita");
            }
            else
                MessageBox.Show("La Consulta Esta Mal Escrita");

            if (completas && validaCadena(pConsulta))
            {
                if (File.Exists(nomA))
                {
                    lEA = aA.abrirArchivo(nomA, cabA);
                    if (existeTabla(lEA, pDestino[1], "entA"))
                    {
                        if (File.Exists(nomB))
                        {
                            lEB = aA.abrirArchivo(nomB, cabB);
                            if (existeTabla(lEB, pConsulta[4], "entB"))
                            {
                                lAA = aA.abrirArchivoAtributo(nomA, entA);
                                if (existeCampo(lAA, pConsulta[6]))
                                {
                                    copiaDatosConsulta(atrB, pConsulta[7], pConsulta[8]);
                                    MessageBox.Show("La Consulta se ha realizado Exitosamente");
                                }
                                else
                                    MessageBox.Show("El Campo No Existe");
                            }
                            else
                                MessageBox.Show("La Tabla No Existe en la BD Origen");
                        }
                        else
                            MessageBox.Show("La BD Origen no Existe");
                    }
                    else
                        MessageBox.Show("La Tabla No Existe en la BD Destino");
                }
                else
                    MessageBox.Show("La BD Destino no Existe");
            }
            if (!validaCadena(pConsulta))
                MessageBox.Show("La Consulta Esta Mal Escrita");
         }

        public bool validaCadena(string[] consulta)
        {
            if (consulta[0] != "SELECT" && consulta[0] != "select" && consulta[0] != "Select")
                return false;
            if (consulta[1] != "*")
                return false;
            if (consulta[2] != "FROM" && consulta[2] != "from" && consulta[2] != "From")
                return false;
            if (consulta[5] != "WHERE" && consulta[5] != "where" && consulta[5] != "Where")
                return false;
            if (consulta[7] != "=" && consulta[7] != "<=" && consulta[7] != ">=" && consulta[7] != "<" && consulta[7] != ">")
                return false;
            
            return true;
        }

        private bool existeTabla(List<CEntidad> lista, string tabla, string ent)
        {
            foreach (CEntidad e in lista)
                if (e.Nombre == tabla)
                {
                    switch (ent)
                    {
                        case "entA":
                            entA = e;
                        break;
                        case "entB":
                            entB = e;
                        break;
                    }
                    return true;
                }
            return false;
        }

        private bool existeCampo(List<CAtributo> lista, string camp)
        {
            foreach (CAtributo a in lista)
                if (a.Nombre == camp)
                {
                    atrB = a;
                    return true;
                }
            return false;
        }

        private void copiaDatosConsulta(CAtributo atr, string op, string dato)
        {
            int tam = sacaTam(), des = sacaDes(atr);
            long sig;
            CBloque ant = new CBloque(tam);
            bloque = new CBloque(tam);

            lAB = aB.abrirArchivoAtributo(nomB, entB);
            bloque.Bloque = aB.LeeBloque(nomB, tam, entB.AptDatos);
            bloque.Dir = entB.AptDatos;
            bloque.sacaSiguiente();
            sig = bloque.Siguiente;
            bloque.Des = des;
            sacaDatoyCompara(bloque, atr, op, dato);
            //guarda(bloque);//Mandar a guardar a la entidad destino
            bloque.empaquetaSig(sig);
            bloque.sacaSiguiente();

            while (bloque.Siguiente != -1)
            {
                sig = bloque.Siguiente;
                bloque.Bloque = aB.LeeBloque(nomB, tam, bloque.Siguiente);
                bloque.Dir = sig;
                bloque.sacaSiguiente();
                sig = bloque.Siguiente;
                bloque.Des = des;
                sacaDatoyCompara(bloque, atr, op, dato);
                //guarda(bloque);//Mandar a guardar a la entidad destino
                bloque.empaquetaSig(sig);
                bloque.sacaSiguiente();

            }

        }

        private int sacaDes(CAtributo atr)
        {
            int des = 0;

            lAA = aA.abrirArchivoAtributo(nomA, entA);
            foreach (CAtributo corre in lAA)
            {
                if (corre.Nombre == atr.Nombre)
                    break;
                switch (corre.TipoDato)
                {
                    case "int": des += 4; break;
                    case "float": des += 8; break;
                    case "string": des += (corre.Tamaño * 2); break;
                    case "char": des += 2; break;
                    case "boolean": des += 1; break;
                }
            }
            return des;
        }

        private void sacaDatoyCompara(CBloque bl, CAtributo atr, string op, string dato)
        {
            int datI;
            double datD;
            char datC;
            string dS;

            switch (atr.TipoDato)
            {
                case "int":
                    datI = bl.sacaInt(4);
                    if (comparaNumero(op, Convert.ToString(datI), dato, atr))
                        guarda(bl);
                    break;
                case "float":
                    datD = bl.sacaFloat(8);
                    if (compara(op, Convert.ToString(datD), dato, atr))
                        guarda(bl);
                    break;
                case "char":
                    datC = bl.sacaChar(2);
                    if (compara(op, Convert.ToString(datC), dato, atr))
                        guarda(bl);
                    break;
                case "string":
                    dS = bl.sacaString(atr.Tamaño);
                    if (compara(op, dS, dato, atr))
                        guarda(bl);
                    break;
            }
        }

        private bool compara(string op, string d1, string d2, CAtributo atr)
        {
            DateTime f1, f2;
            switch (op)
            {
                case "=":
                    if (atr.Nombre == "Fecha_Alta" || atr.Nombre == "Fecha_Baja" || atr.Nombre == "Fecha_Mod")
                    {
                        f1 = Convert.ToDateTime(d1);
                        f2 = Convert.ToDateTime(d2);
                        if (DateTime.Compare(f1, f2) == 0)
                            return true;
                    }
                    else
                    {
                        if (d1 == d2)
                            return true;
                    }
                break;
                case "<=":
                    if (atr.Nombre == "Fecha_Alta" || atr.Nombre == "Fecha_Baja" || atr.Nombre == "Fecha_Mod")
                    {
                        f1 = Convert.ToDateTime(d1);
                        f2 = Convert.ToDateTime(d2);
                        if (DateTime.Compare(f1, f2) <= 0)
                            return true;
                    }
                    else
                    {
                        if (d1.CompareTo(d2) <= 0)
                            return true;
                    }
                break;
                case ">=":
                    if (atr.Nombre == "Fecha_Alta" || atr.Nombre == "Fecha_Baja" || atr.Nombre == "Fecha_Mod")
                    {
                        f1 = Convert.ToDateTime(d1);
                        f2 = Convert.ToDateTime(d2);
                        if (DateTime.Compare(f1, f2) >= 0)
                            return true;
                    }
                    else
                    {
                        if (d1.CompareTo(d2) >= 0)
                            return true;
                    }
                break;
                case "<":
                    if (atr.Nombre == "Fecha_Alta" || atr.Nombre == "Fecha_Baja" || atr.Nombre == "Fecha_Mod")
                    {
                        f1 = Convert.ToDateTime(d1);
                        f2 = Convert.ToDateTime(d2);
                        if (DateTime.Compare(f1, f2) < 0)
                            return true;
                    }
                    else
                    {
                        if (d1.CompareTo(d2) < 0)
                            return true;
                    }
                break;
                case ">":
                if (atr.Nombre == "Fecha_Alta" || atr.Nombre == "Fecha_Baja" || atr.Nombre == "Fecha_Mod")
                    {
                        if (d1.Length == 10 && d2.Length == 10)
                        {
                            f1 = Convert.ToDateTime(d1);
                            f2 = Convert.ToDateTime(d2);
                            if (DateTime.Compare(f1, f2) > 0)
                                return true;
                        }
                    }
                    else
                    {
                        if (d1.CompareTo(d2) > 0)
                            return true;
                    }
                break;
            }
            return false;
        }

        private bool comparaNumero(string op, string dt1, string dt2, CAtributo atr)
        {
            int d1 = Convert.ToInt32(dt1), d2 = Convert.ToInt32(dt2);
            switch (op)
            {
                case "=": if (d1 == d2) return true; break;
                case "<=": if (d1 <= d2) return true; break;
                case ">=": if (d1 >= d2) return true; break;
                case "<": if (d1 < d2) return true; break;
                case ">": if (d1 > d2) return true; break;
            }

            return false;
        }
#endregion

        #region Inner Join
        private void bInnerJoin_Click(object sender, EventArgs e)
        {
            dgvInnerJoin.Rows.Clear();
            dgvInnerJoin.Columns.Clear();
            bool completas = false;
            char[] caracter = { ' ', '.' };
            string consulta = tbInnerJoin.Text;
            string[] pConsulta = consulta.Split(caracter);

            if (pConsulta.Length == 15)
            {
                if (pConsulta[3] == pConsulta[7])
                {
                    nomA = "C:\\Users\\DFJPMOSH\\Documents\\Visual Studio 2010\\Projects\\Base de Datos A\\Diccionario\\bin\\Debug\\" +
                        pConsulta[3] + ".sec";
                    completas = true;
                }
                else
                    MessageBox.Show("Las Bases de Datos no Coinciden");
            }
            else
                MessageBox.Show("La Consulta Esta Mal Escrita");

            if (completas && validaCadenaIJ(pConsulta))
            {
                if (File.Exists(nomA))
                {
                    lEA = aA.abrirArchivo(nomA, cabA);
                    if (existeTabla(lEA, pConsulta[4], "entA") && pConsulta[4]==pConsulta[10])
                    {
                        if (existeTabla(lEA, pConsulta[8], "entB") && pConsulta[8]==pConsulta[13])
                        {
                            lAA = aA.abrirArchivoAtributo(nomA, entA);
                            lAB = aA.abrirArchivoAtributo(nomA, entB);
                            if(existeCampo(lAA, pConsulta[11], "atrA"))
                            {
                                if(existeCampo(lAB, pConsulta[14], "atrB"))
                                {
                                    agregaColumnasIJ(lAA, lAB);
                                    muestraDatosIJ(pConsulta[12]);
                                }
                                else
                                    MessageBox.Show("No Existe la Columna en la Tabla 2");
                            }
                            else
                                MessageBox.Show("No Existe la Columna en la Tabla 1");
                        }
                        else
                            MessageBox.Show("La Tabla2 No Existe en la BD");
                    }
                    else
                        MessageBox.Show("La Tabla1 No Existe en la BD");
                }
                else
                    MessageBox.Show("La BD No Existe");
            }
            if (!validaCadenaIJ(pConsulta))
                MessageBox.Show("La Consulta Esta Mal Escrita");
        }

        public bool validaCadenaIJ(string[] consulta)
        {
            if (consulta[0] != "SELECT" && consulta[0] != "select" && consulta[0] != "Select")
                return false;
            if (consulta[1] != "*")
                return false;
            if (consulta[2] != "FROM" && consulta[2] != "from" && consulta[2] != "From")
                return false;
            if (consulta[5] != "INNER" && consulta[5] != "inner" && consulta[5] != "Inner")
                return false;
            if (consulta[6] != "JOIN" && consulta[5] != "join" && consulta[5] != "Join")
                return false;
            if (consulta[9] != "ON" && consulta[5] != "on" && consulta[5] != "On")
                return false;
            if (consulta[12] != "=")
                return false;

            return true;
        }

        private bool existeCampo(List<CAtributo> lista, string campo, string atr)
        {
            foreach (CAtributo a in lista)
                if (a.Nombre == campo)
                {
                    switch (atr)
                    {
                        case "atrA":
                            atrA = a;
                            break;
                        case "atrB":
                            atrB = a;
                            break;
                    }
                    return true;
                }
            return false;
        }

        private void agregaColumnasIJ(List<CAtributo> la, List<CAtributo> lb)
        {
            foreach (CAtributo a in la)
            {
                if (a.Nombre != "Fecha_Alta" && a.Nombre != "Fecha_Baja" && a.Nombre != "Fecha_Mod" &&
                    a.Nombre != "Id_Usu_Alt" && a.Nombre != "Id_Usu_Baj" && a.Nombre != "Id_Usu_Mod")
                {
                    DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
                    txt.HeaderText = a.Nombre;
                    txt.Name = a.Nombre;
                    dgvInnerJoin.Columns.Add(txt);
                }
            }

            foreach (CAtributo a in lb)
            {
                if (a.Nombre != "Fecha_Alta" && a.Nombre != "Fecha_Baja" && a.Nombre != "Fecha_Mod" &&
                    a.Nombre != "Id_Usu_Alt" && a.Nombre != "Id_Usu_Baj" && a.Nombre != "Id_Usu_Mod")
                {
                    DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
                    txt.HeaderText = a.Nombre;
                    txt.Name = a.Nombre;
                    dgvInnerJoin.Columns.Add(txt);
                }
            }
        }

        public void muestraDatosIJ(string op)
        {
            int tamA = sacaTam(lAA), tamB = sacaTam(lAB), desA = sacaDes(atrA, lAA), desB = sacaDes(atrB, lAB);
            long sigA, sigB;
            CBloque bA = new CBloque(tamA);
            CBloque bB = new CBloque(tamB);
            CBloque bauxA = new CBloque(tamA);
            CBloque bauxB = new CBloque(tamB);
            
            bA.Bloque = aA.LeeBloque(nomA, tamA, entA.AptDatos);
            bA.Dir = entA.AptDatos;
            bA.sacaSiguiente();
            bA.Des = desA;
            
            bB.Bloque = aA.LeeBloque(nomA, tamB, entB.AptDatos);
            bB.Dir = entB.AptDatos;
            bB.sacaSiguiente();
            bB.Des = desB;

            sigA = entA.AptDatos;
            //sacaDatoyCompara(bA, bB, atrA, op);

            while (sigA != -1)
            {
                bauxA.Bloque = aA.LeeBloque(nomA, tamA, sigA);
                bauxA.Dir = bA.Siguiente;
                sigB = entB.AptDatos;
                while (sigB != -1)
                {
                    bauxB.Bloque = aA.LeeBloque(nomA, tamB, sigB);
                    bauxB.Dir = bB.Siguiente;
                    bauxB.Des = desB;
                    bauxA.Des = desA;
                    sacaDatoyComparaIJ(bauxA, bauxB, atrA, op);
                    bauxB.sacaSiguiente();
                    sigB = bauxB.Siguiente;
                }
                bauxA.sacaSiguiente();
                sigA = bauxA.Siguiente;
            }

            /*sigA = bloque.Siguiente;
            bloque.Des = des;
            sacaDatoyCompara(bloque, atr, op, dato);
            //guarda(bloque);//Mandar a guardar a la entidad destino
            bloque.empaquetaSig(sig);
            bloque.sacaSiguiente();

            while (bloque.Siguiente != -1)
            {
                sig = bloque.Siguiente;
                bloque.Bloque = aB.LeeBloque(nomB, tam, bloque.Siguiente);
                bloque.Dir = sig;
                bloque.sacaSiguiente();
                sig = bloque.Siguiente;
                bloque.Des = des;
                sacaDatoyCompara(bloque, atr, op, dato);
                //guarda(bloque);//Mandar a guardar a la entidad destino
                bloque.empaquetaSig(sig);
                bloque.sacaSiguiente();

            }*/
        }

        private int sacaTam(List<CAtributo> lista)
        {
            int tam = 0;

            foreach (CAtributo corre in lista)
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
            return tam;
        }

        private int sacaDes(CAtributo atr, List<CAtributo> lista)
        {
            int des = 0;

            foreach (CAtributo corre in lista)
            {
                if (corre.Nombre == atr.Nombre)
                    break;
                switch (corre.TipoDato)
                {
                    case "int": des += 4; break;
                    case "float": des += 8; break;
                    case "string": des += (corre.Tamaño * 2); break;
                    case "char": des += 2; break;
                    case "boolean": des += 1; break;
                }
            }
            return des;
        }

        private void sacaDatoyComparaIJ(CBloque bA, CBloque bB, CAtributo atr, string op)
        {
            int datIA, datIB;
            double datDA, datDB;
            char datCA, datCB;
            string dSA, dSB;

            switch (atr.TipoDato)
            {
                case "int":
                    datIA = bA.sacaInt(4);
                    datIB = bB.sacaInt(4);
                    if (comparaNumero(op, Convert.ToString(datIA), Convert.ToString(datIB), atr))
                    {
                        dgvInnerJoin.Rows.Add();
                        agregaRenglonIJ(bA, bB);
                    }
                    break;
               case "float":
                    datDA = bA.sacaFloat(8);
                    datDB = bB.sacaFloat(8);
                    if (compara(op, Convert.ToString(datDA), Convert.ToString(datDB), atr))
                    {
                        dgvInnerJoin.Rows.Add();
                        agregaRenglonIJ(bA, bB);
                    }
                    break;
                case "char":
                    datCA = bA.sacaChar(2);
                    datCB = bB.sacaChar(2);
                    if (compara(op, Convert.ToString(datCA), Convert.ToString(datCB), atr))
                    {
                        dgvInnerJoin.Rows.Add();
                        agregaRenglonIJ(bA, bB);
                    }
                    break;
                case "string":
                    dSA = bA.sacaString(atr.Tamaño);
                    dSB = bB.sacaString(atr.Tamaño);
                    if (compara(op, dSA, dSB, atr))
                    {
                        dgvInnerJoin.Rows.Add();
                        agregaRenglonIJ(bA, bB);
                    }
                    break;
            }
        }

        private void agregaRenglonIJ(CBloque bA, CBloque bB)
        {
            int datI;
            double datD;
            char datC;
            string dS;
            bA.Des = bB.Des = 0;

            for (int i = 0; i < lAA.Count/*-6*/; i++)//-6 para no tomar en cuenta los ultimos atributos
            {
                            
                switch (lAA[i].TipoDato)
                {
                    case "int":
                        datI = bA.sacaInt(4);
                        if (lAA[i].Nombre != "Id_Usu_Mod" && lAA[i].Nombre != "Id_Usu_Alt" && lAA[i].Nombre != "Id_Usu_Baj")
                        {
                            dgvInnerJoin[i,dgvInnerJoin.RowCount-1].Value = datI;
                        }
                        break;
                    case "float":
                        datD = bA.sacaFloat(8);
                        dgvInnerJoin[i, dgvInnerJoin.RowCount - 1].Value = datD;
                        break;
                    case "char":
                        datC = bA.sacaChar(2);
                        dgvInnerJoin[i, dgvInnerJoin.RowCount - 1].Value = datC;
                        break;
                    case "string":
                        dS = bA.sacaString(lAA[i].Tamaño);
                        if (lAA[i].Nombre != "Fecha_Mod" && lAA[i].Nombre != "Fecha_Alta" && lAA[i].Nombre != "Fecha_Baja")
                        {
                            dgvInnerJoin[i, dgvInnerJoin.RowCount - 1].Value = dS;
                        }
                        /*if (LA[i].Nombre == "Fecha_Baja" && dS.Length > 0)
                        {
                            cambiaCF();
                        }*/
                        break;
                    /*case "boolean":
                        b = bloque.sacaBool(1);
                        dgvDS.Rows[iFA].Cells[i].Value = b;
                        break;*/
                }
            }

            for (int i = 0; i < lAB.Count/*-6*/; i++)//-6 para no tomar en cuenta los ultimos atributos
            {

                switch (lAB[i].TipoDato)
                {
                    case "int":
                        datI = bB.sacaInt(4);
                        if (lAB[i].Nombre != "Id_Usu_Mod" && lAB[i].Nombre != "Id_Usu_Alt" && lAB[i].Nombre != "Id_Usu_Baj")
                        {
                            dgvInnerJoin[i+lAA.Count-6, dgvInnerJoin.RowCount - 1].Value = datI;
                        }
                        break;
                    case "float":
                        datD = bB.sacaFloat(8);
                        dgvInnerJoin[i + lAA.Count-6, dgvInnerJoin.RowCount - 1].Value = datD;
                        break;
                    case "char":
                        datC = bB.sacaChar(2);
                        dgvInnerJoin[i + lAA.Count-6, dgvInnerJoin.RowCount - 1].Value = datC;
                        break;
                    case "string":
                        dS = bB.sacaString(lAA[i].Tamaño);
                        if (lAB[i].Nombre != "Fecha_Mod" && lAB[i].Nombre != "Fecha_Alta" && lAB[i].Nombre != "Fecha_Baja")
                        {
                            dgvInnerJoin[i + lAA.Count-6, dgvInnerJoin.RowCount - 1].Value = dS;
                        }
                        /*if (LA[i].Nombre == "Fecha_Baja" && dS.Length > 0)
                        {
                            cambiaCF();
                        }*/
                        break;
                    /*case "boolean":
                        b = bloque.sacaBool(1);
                        dgvDS.Rows[iFA].Cells[i].Value = b;
                        break;*/
                }
            }
        }
        #endregion

        private void FormSQL_ClientSizeChanged(object sender, EventArgs e)
        {
        }
        
        #region Cross Join
        private void bCrossJoin_Click(object sender, EventArgs e)
        {
            dgvCrossJoin.Rows.Clear();
            dgvCrossJoin.Columns.Clear();
            bool completas = false;
            char[] caracter = { ' ', '.' };
            string consulta = tbCrossJoin.Text;
            string[] pConsulta = consulta.Split(caracter);

            if (pConsulta.Length == 15)
            {
                if (pConsulta[3] == pConsulta[7])
                {
                    nomA = "C:\\Users\\DFJPMOSH\\Documents\\Visual Studio 2010\\Projects\\Base de Datos A\\Diccionario\\bin\\Debug\\" +
                        pConsulta[3] + ".sec";
                    completas = true;
                }
                else
                    MessageBox.Show("Las Bases de Datos no Coinciden");
            }
            else
                MessageBox.Show("La Consulta Esta Mal Escrita");

            if (completas && validaCadenaCJ(pConsulta))
            {
                if (File.Exists(nomA))
                {
                    lEA = aA.abrirArchivo(nomA, cabA);
                    if (existeTabla(lEA, pConsulta[4], "entA") && pConsulta[4] == pConsulta[10])
                    {
                        if (existeTabla(lEA, pConsulta[8], "entB") && pConsulta[8] == pConsulta[13])
                        {
                            lAA = aA.abrirArchivoAtributo(nomA, entA);
                            lAB = aA.abrirArchivoAtributo(nomA, entB);
                            if (existeCampo(lAA, pConsulta[11], "atrA"))
                            {
                                if (existeCampo(lAB, pConsulta[14], "atrB"))
                                {
                                    agregaColumnasCJ(lAA, lAB);
                                    muestraDatosCJ(pConsulta[12], buscaIndiceB(lAB));
                                }
                                else
                                    MessageBox.Show("No Existe la Columna en la Tabla 2");
                            }
                            else
                                MessageBox.Show("No Existe la Columna en la Tabla 1");
                        }
                        else
                            MessageBox.Show("La Tabla2 No Existe en la BD");
                    }
                    else
                        MessageBox.Show("La Tabla1 No Existe en la BD");
                }
                else
                    MessageBox.Show("La BD No Existe");
            }
            if (!validaCadenaCJ(pConsulta))
                MessageBox.Show("La Consulta Esta Mal Escrita");
        }

        public bool validaCadenaCJ(string[] consulta)
        {
            if (consulta[0] != "SELECT" && consulta[0] != "select" && consulta[0] != "Select")
                return false;
            if (consulta[1] != "*")
                return false;
            if (consulta[2] != "FROM" && consulta[2] != "from" && consulta[2] != "From")
                return false;
            if (consulta[5] != "CROSS" && consulta[5] != "cross" && consulta[5] != "Cross")
                return false;
            if (consulta[6] != "JOIN" && consulta[5] != "join" && consulta[5] != "Join")
                return false;
            if (consulta[9] != "ON" && consulta[5] != "on" && consulta[5] != "On")
                return false;
            if (consulta[12] != "=")
                return false;

            return true;
        }

        private void agregaColumnasCJ(List<CAtributo> la, List<CAtributo> lb)
        {
            foreach (CAtributo a in la)
            {
                if (a.Nombre != "Fecha_Alta" && a.Nombre != "Fecha_Baja" && a.Nombre != "Fecha_Mod" &&
                    a.Nombre != "Id_Usu_Alt" && a.Nombre != "Id_Usu_Baj" && a.Nombre != "Id_Usu_Mod")
                {
                    DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
                    txt.HeaderText = a.Nombre;
                    txt.Name = a.Nombre;
                    dgvCrossJoin.Columns.Add(txt);
                }
            }

            foreach (CAtributo a in lb)
            {
                if (a.Nombre != "Fecha_Alta" && a.Nombre != "Fecha_Baja" && a.Nombre != "Fecha_Mod" &&
                    a.Nombre != "Id_Usu_Alt" && a.Nombre != "Id_Usu_Baj" && a.Nombre != "Id_Usu_Mod")
                {
                    DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
                    txt.HeaderText = a.Nombre;
                    txt.Name = a.Nombre;
                    dgvCrossJoin.Columns.Add(txt);
                }
            }
        }

        public void muestraDatosCJ(string op, int ind)
        {
            int tamA = sacaTam(lAA), tamB = sacaTam(lAB), desA = sacaDes(atrA, lAA), desB = sacaDes(atrB, lAB);
            long sigA, sigB;
            CBloque bA = new CBloque(tamA);
            CBloque bB = new CBloque(tamB);
            CBloque bauxA = new CBloque(tamA);
            CBloque bauxB = new CBloque(tamB);

            bA.Bloque = aA.LeeBloque(nomA, tamA, entA.AptDatos);
            bA.Dir = entA.AptDatos;
            bA.sacaSiguiente();
            bA.Des = desA;

            bB.Bloque = aA.LeeBloque(nomA, tamB, entB.AptDatos);
            bB.Dir = entB.AptDatos;
            bB.sacaSiguiente();
            bB.Des = desB;

            sigA = entA.AptDatos;
            while (sigA != -1)
            {
                bauxA.Bloque = aA.LeeBloque(nomA, tamA, sigA);
                bauxA.Dir = bA.Siguiente;
                sigB = entB.AptDatos;
                while (sigB != -1)
                {
                    bauxB.Bloque = aA.LeeBloque(nomA, tamB, sigB);
                    bauxB.Dir = bB.Siguiente;
                    bauxB.Des = desB;
                    bauxA.Des = desA;
                    sacaDatoyComparaCJ(bauxA, bauxB, atrA, op, ind);
                    bauxB.sacaSiguiente();
                    sigB = bauxB.Siguiente;
                }
                bauxA.sacaSiguiente();
                sigA = bauxA.Siguiente;
            }
            
        }

        private void sacaDatoyComparaCJ(CBloque bA, CBloque bB, CAtributo atr, string op, int ind)
        {
            int datIA, datIB;
            double datDA, datDB;
            char datCA, datCB;
            string dSA, dSB;

            switch (atr.TipoDato)
            {
                case "int":
                    datIA = bA.sacaInt(4);
                    datIB = bB.sacaInt(4);
                    if (comparaNumero(op, Convert.ToString(datIA), Convert.ToString(datIB), atr))
                    {
                        dgvCrossJoin.Rows.Add();
                        agregaRenglonCJ(bA, bB, ind);
                    }
                    else
                    {
                        //Checar si datIA existe en la tabla 2
                        if(!buscaEnTabla2(Convert.ToString(datIA), atr.TipoDato, ind))
                            agregaRenglonCJ(bA, bB, true);
                    }
                    break;
                case "float":
                    datDA = bA.sacaFloat(8);
                    datDB = bB.sacaFloat(8);
                    if (compara(op, Convert.ToString(datDA), Convert.ToString(datDB), atr))
                    {
                        dgvCrossJoin.Rows.Add();
                        agregaRenglonCJ(bA, bB, ind);
                    }
                    break;
                case "char":
                    datCA = bA.sacaChar(2);
                    datCB = bB.sacaChar(2);
                    if (compara(op, Convert.ToString(datCA), Convert.ToString(datCB), atr))
                    {
                        dgvCrossJoin.Rows.Add();
                        agregaRenglonCJ(bA, bB, ind);
                    }
                    break;
                case "string":
                    dSA = bA.sacaString(atr.Tamaño);
                    dSB = bB.sacaString(atr.Tamaño);
                    if (compara(op, dSA, dSB, atr))
                    {
                        dgvCrossJoin.Rows.Add();
                        agregaRenglonCJ(bA, bB, ind);
                    }
                    break;
            }
        }

        private void agregaRenglonCJ(CBloque bA, CBloque bB, int ind)
        {
            int datI;
            double datD;
            char datC;
            string dS;
            bA.Des = bB.Des = 0;

            for (int i = 0; i < lAA.Count/*-6*/; i++)//-6 para no tomar en cuenta los ultimos atributos
            {

                switch (lAA[i].TipoDato)
                {
                    case "int":
                        datI = bA.sacaInt(4);
                        int datIB = sacaDatoB(bB);
                        int j = 0;
                        bool esta = false;

                        for (j = 0; j < dgvCrossJoin.RowCount-1; j++)
                        { //Si truena es por que no esta validado el ind donde esta el id a comparar
                            if (datI == Convert.ToInt32(dgvCrossJoin[0, j].Value.ToString()) && dgvCrossJoin[ind, j].Value != null && datIB == Convert.ToInt32(dgvCrossJoin[3, j].Value.ToString()))
                            {
                                esta=true;
                                dgvCrossJoin.Rows.RemoveAt(dgvCrossJoin.RowCount - 1);
                                break;
                            }
                        }
                        if (!esta && lAA[i].Nombre != "Id_Usu_Mod" && lAA[i].Nombre != "Id_Usu_Alt" && lAA[i].Nombre != "Id_Usu_Baj")
                        {
                            dgvCrossJoin[i, dgvCrossJoin.RowCount - 1].Value = datI;
                        }
                        break;
                    case "float":
                        datD = bA.sacaFloat(8);
                        dgvCrossJoin[i, dgvCrossJoin.RowCount - 1].Value = datD;
                        break;
                    case "char":
                        datC = bA.sacaChar(2);
                        dgvCrossJoin[i, dgvCrossJoin.RowCount - 1].Value = datC;
                        break;
                    case "string":
                        dS = bA.sacaString(lAA[i].Tamaño);
                        if (lAA[i].Nombre != "Fecha_Mod" && lAA[i].Nombre != "Fecha_Alta" && lAA[i].Nombre != "Fecha_Baja")
                        {
                            dgvCrossJoin[i, dgvCrossJoin.RowCount - 1].Value = dS;
                        }
                        /*if (LA[i].Nombre == "Fecha_Baja" && dS.Length > 0)
                        {
                            cambiaCF();
                        }*/
                        break;
                }
            }

            bB.Des = 0;
            for (int i = 0; i < lAB.Count/*-6*/; i++)//-6 para no tomar en cuenta los ultimos atributos
            {

                switch (lAB[i].TipoDato)
                {
                    case "int":
                        datI = bB.sacaInt(4);
                        if (lAB[i].Nombre != "Id_Usu_Mod" && lAB[i].Nombre != "Id_Usu_Alt" && lAB[i].Nombre != "Id_Usu_Baj")
                        {
                            dgvCrossJoin[i + lAA.Count - 6, dgvCrossJoin.RowCount - 1].Value = datI;
                        }
                        break;
                    case "float":
                        datD = bB.sacaFloat(8);
                        dgvCrossJoin[i + lAA.Count - 6, dgvCrossJoin.RowCount - 1].Value = datD;
                        break;
                    case "char":
                        datC = bB.sacaChar(2);
                        dgvCrossJoin[i + lAA.Count - 6, dgvCrossJoin.RowCount - 1].Value = datC;
                        break;
                    case "string":
                        dS = bB.sacaString(lAA[i].Tamaño);
                        if (lAB[i].Nombre != "Fecha_Mod" && lAB[i].Nombre != "Fecha_Alta" && lAB[i].Nombre != "Fecha_Baja")
                        {
                            dgvCrossJoin[i + lAA.Count - 6, dgvCrossJoin.RowCount - 1].Value = dS;
                        }
                        /*if (LA[i].Nombre == "Fecha_Baja" && dS.Length > 0)
                        {
                            cambiaCF();
                        }*/
                        break;
                    }
            }
        }

        private void agregaRenglonCJ(CBloque bA, CBloque bB, bool t)
        {
            int datI;
            double datD;
            char datC;
            string dS;
            bA.Des = 0;
            
            for (int i = 0; i < lAA.Count/*-6*/; i++)//-6 para no tomar en cuenta los ultimos atributos
            {

                switch (lAA[i].TipoDato)
                {
                    case "int":
                        datI = bA.sacaInt(4);
                        int j = 0;
                        bool esta = false;

                        for (j = 0; j < dgvCrossJoin.RowCount; j++)
                        {
                            if (datI == Convert.ToInt32(dgvCrossJoin[0, j].Value.ToString()))
                            {
                                esta=true;
                                break;
                            }
                        }
                        if (lAA[i].TipoClave ==1 && !esta && lAA[i].Nombre != "Id_Usu_Mod" && lAA[i].Nombre != "Id_Usu_Alt" && lAA[i].Nombre != "Id_Usu_Baj")
                        {
                            dgvCrossJoin.Rows.Add();
                            dgvCrossJoin[i, dgvCrossJoin.RowCount - 1].Value = datI;
                        }
                        else
                            if (lAA[i].TipoClave != 1 && !esta && lAA[i].Nombre != "Id_Usu_Mod" && lAA[i].Nombre != "Id_Usu_Alt" && lAA[i].Nombre != "Id_Usu_Baj")
                                dgvCrossJoin[i, dgvCrossJoin.RowCount - 1].Value = datI;
                        break;
                    case "float":
                        datD = bA.sacaFloat(8);
                        dgvCrossJoin[i, dgvCrossJoin.RowCount - 1].Value = datD;
                        break;
                    case "char":
                        datC = bA.sacaChar(2);
                        dgvCrossJoin[i, dgvCrossJoin.RowCount - 1].Value = datC;
                        break;
                    case "string":
                        dS = bA.sacaString(lAA[i].Tamaño);
                        if (lAA[i].Nombre != "Fecha_Mod" && lAA[i].Nombre != "Fecha_Alta" && lAA[i].Nombre != "Fecha_Baja")
                        {
                            dgvCrossJoin[i, dgvCrossJoin.RowCount - 1].Value = dS;
                        }
                        /*if (LA[i].Nombre == "Fecha_Baja" && dS.Length > 0)
                        {
                            cambiaCF();
                        }*/
                        break;
                }
            }

        }

        private int sacaDatoB(CBloque bB)
        {
            bB.Des=0;
            return bB.sacaInt(4);
        }

        private int buscaIndiceB(List<CAtributo> l)
        {
            int i;
            string campo="";

            foreach (CAtributo a in l)
                if (a.TipoClave == 1)
                    campo = a.Nombre;

            for (i = 0; i < dgvCrossJoin.ColumnCount; i++)
                if (campo == dgvCrossJoin.Columns[i].HeaderText)
                    return i;

            return -1;
        }

        private bool buscaEnTabla2(string dato, string tipo, int ind)
        {
            int tamB = sacaTam(lAB), desB = sacaDes(atrB, lAB);
            long sigB;
            CBloque bB = new CBloque(tamB);
            CBloque bauxB = new CBloque(tamB);
            int datIB;
            bool esta = false;

            sigB = entB.AptDatos;
            while (sigB != -1)
            {
                bauxB.Bloque = aA.LeeBloque(nomA, tamB, sigB);
                bauxB.Dir = sigB;
                bauxB.Des = desB;
                switch (tipo)
                {
                    case "int":
                        datIB = bauxB.sacaInt(4);
                        if (Convert.ToInt32(dato) == datIB)
                            esta = true;
                        break;
                    case "float":
                        
                        break;
                    case "char":
                        
                        break;
                    case "string":
                        
                        break;
                }
                if (esta)
                    break;
                bauxB.sacaSiguiente();
                sigB = bauxB.Siguiente;
            }

            return esta;
        }
#endregion

        #region Left Join
        private void bLeftJoin_Click(object sender, EventArgs e)
        {
            dgvLeftJoin.Rows.Clear();
            dgvLeftJoin.Columns.Clear();
            bool completas = false;
            char[] caracter = { ' ', '.' };
            string consulta = tbLeftJoin.Text;
            string[] pConsulta = consulta.Split(caracter);

            if (pConsulta.Length == 15)
            {
                if (pConsulta[3] == pConsulta[7])
                {
                    nomA = "C:\\Users\\DFJPMOSH\\Documents\\Visual Studio 2010\\Projects\\Base de Datos A\\Diccionario\\bin\\Debug\\" +
                        pConsulta[3] + ".sec";
                    completas = true;
                }
                else
                    MessageBox.Show("Las Bases de Datos no Coinciden");
            }
            else
                MessageBox.Show("La Consulta Esta Mal Escrita");

            if (completas && validaCadenaLJ(pConsulta))
            {
                if (File.Exists(nomA))
                {
                    lEA = aA.abrirArchivo(nomA, cabA);
                    if (existeTabla(lEA, pConsulta[4], "entA") && pConsulta[4] == pConsulta[10])
                    {
                        if (existeTabla(lEA, pConsulta[8], "entB") && pConsulta[8] == pConsulta[13])
                        {
                            lAA = aA.abrirArchivoAtributo(nomA, entA);
                            lAB = aA.abrirArchivoAtributo(nomA, entB);
                            if (existeCampo(lAA, pConsulta[11], "atrA"))
                            {
                                if (existeCampo(lAB, pConsulta[14], "atrB"))
                                {
                                    agregaColumnasLJ(lAA, lAB);
                                    muestraDatosLJ(pConsulta[12]);
                                }
                                else
                                    MessageBox.Show("No Existe la Columna en la Tabla 2");
                            }
                            else
                                MessageBox.Show("No Existe la Columna en la Tabla 1");
                        }
                        else
                            MessageBox.Show("La Tabla2 No Existe en la BD");
                    }
                    else
                        MessageBox.Show("La Tabla1 No Existe en la BD");
                }
                else
                    MessageBox.Show("La BD No Existe");
            }
            if (!validaCadenaLJ(pConsulta))
                MessageBox.Show("La Consulta Esta Mal Escrita");
        }

        public bool validaCadenaLJ(string[] consulta)
        {
            if (consulta[0] != "SELECT" && consulta[0] != "select" && consulta[0] != "Select")
                return false;
            if (consulta[1] != "*")
                return false;
            if (consulta[2] != "FROM" && consulta[2] != "from" && consulta[2] != "From")
                return false;
            if (consulta[5] != "LEFT" && consulta[5] != "left" && consulta[5] != "Left")
                return false;
            if (consulta[6] != "JOIN" && consulta[5] != "join" && consulta[5] != "Join")
                return false;
            if (consulta[9] != "ON" && consulta[5] != "on" && consulta[5] != "On")
                return false;
            if (consulta[12] != "=")
                return false;

            return true;
        }

        private void agregaColumnasLJ(List<CAtributo> la, List<CAtributo> lb)
        {
            foreach (CAtributo a in la)
            {
                if (a.Nombre != "Fecha_Alta" && a.Nombre != "Fecha_Baja" && a.Nombre != "Fecha_Mod" &&
                    a.Nombre != "Id_Usu_Alt" && a.Nombre != "Id_Usu_Baj" && a.Nombre != "Id_Usu_Mod")
                {
                    DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
                    txt.HeaderText = a.Nombre;
                    txt.Name = a.Nombre;
                    dgvLeftJoin.Columns.Add(txt);
                }
            }
        }

        public void muestraDatosLJ(string op)
        {
            bool iguales = false;
            int tamA = sacaTam(lAA), tamB = sacaTam(lAB), desA = sacaDes(atrA, lAA), desB = sacaDes(atrB, lAB);
            long sigA, sigB;
            CBloque bA = new CBloque(tamA);
            CBloque bB = new CBloque(tamB);
            CBloque bauxA = new CBloque(tamA);
            CBloque bauxB = new CBloque(tamB);

            bA.Bloque = aA.LeeBloque(nomA, tamA, entA.AptDatos);
            bA.Dir = entA.AptDatos;
            bA.sacaSiguiente();
            bA.Des = desA;

            bB.Bloque = aA.LeeBloque(nomA, tamB, entB.AptDatos);
            bB.Dir = entB.AptDatos;
            bB.sacaSiguiente();
            bB.Des = desB;

            sigA = entA.AptDatos;
            //sacaDatoyCompara(bA, bB, atrA, op);

            while (sigA != -1)
            {
                iguales = false;
                bauxA.Bloque = aA.LeeBloque(nomA, tamA, sigA);
                bauxA.Dir = bA.Siguiente;
                sigB = entB.AptDatos;
                while (sigB != -1 && !iguales)
                {
                    bauxB.Bloque = aA.LeeBloque(nomA, tamB, sigB);
                    bauxB.Dir = bB.Siguiente;
                    bauxB.Des = desB;
                    bauxA.Des = desA;
                    if(sacaDatoyComparaLJ(bauxA, bauxB, atrA, op))
                        iguales = true;
                    bauxB.sacaSiguiente();
                    sigB = bauxB.Siguiente;
                }
                if (!iguales)
                {
                    dgvLeftJoin.Rows.Add();
                    agregaRenglonLJ(bauxA, bauxB);
                }
                bauxA.sacaSiguiente();
                sigA = bauxA.Siguiente;
            }
        }

        private bool sacaDatoyComparaLJ(CBloque bA, CBloque bB, CAtributo atr, string op)
        {
            int datIA, datIB;
            double datDA, datDB;
            char datCA, datCB;
            string dSA, dSB;
            bool iguales = false;

            switch (atr.TipoDato)
            {
                case "int":
                    datIA = bA.sacaInt(4);
                    datIB = bB.sacaInt(4);
                    if (comparaNumero(op, Convert.ToString(datIA), Convert.ToString(datIB), atr))
                        iguales = true;
                    else
                        iguales = false;
                    break;
                case "float":
                    datDA = bA.sacaFloat(8);
                    datDB = bB.sacaFloat(8);
                    if (compara(op, Convert.ToString(datDA), Convert.ToString(datDB), atr))
                        iguales = true;
                    else
                        iguales = false;
                    break;
                case "char":
                    datCA = bA.sacaChar(2);
                    datCB = bB.sacaChar(2);
                    if (compara(op, Convert.ToString(datCA), Convert.ToString(datCB), atr))
                        iguales = true;
                    else
                        iguales = false;
                    break;
                case "string":
                    dSA = bA.sacaString(atr.Tamaño);
                    dSB = bB.sacaString(atr.Tamaño);
                    if (compara(op, dSA, dSB, atr))
                        iguales = true;
                    else
                        iguales = false;
                    break;
            }
            return iguales;
        }

        private void agregaRenglonLJ(CBloque bA, CBloque bB)
        {
            int datI;
            double datD;
            char datC;
            string dS;
            bA.Des = bB.Des = 0;

            for (int i = 0; i < lAA.Count/*-6*/; i++)//-6 para no tomar en cuenta los ultimos atributos
            {

                switch (lAA[i].TipoDato)
                {
                    case "int":
                        datI = bA.sacaInt(4);
                        if (lAA[i].Nombre != "Id_Usu_Mod" && lAA[i].Nombre != "Id_Usu_Alt" && lAA[i].Nombre != "Id_Usu_Baj")
                        {
                            dgvLeftJoin[i, dgvLeftJoin.RowCount - 1].Value = datI;
                        }
                        break;
                    case "float":
                        datD = bA.sacaFloat(8);
                        dgvLeftJoin[i, dgvLeftJoin.RowCount - 1].Value = datD;
                        break;
                    case "char":
                        datC = bA.sacaChar(2);
                        dgvLeftJoin[i, dgvLeftJoin.RowCount - 1].Value = datC;
                        break;
                    case "string":
                        dS = bA.sacaString(lAA[i].Tamaño);
                        if (lAA[i].Nombre != "Fecha_Mod" && lAA[i].Nombre != "Fecha_Alta" && lAA[i].Nombre != "Fecha_Baja")
                        {
                            dgvLeftJoin[i, dgvLeftJoin.RowCount - 1].Value = dS;
                        }
                        /*if (LA[i].Nombre == "Fecha_Baja" && dS.Length > 0)
                        {
                            cambiaCF();
                        }*/
                        break;
                }
            }

            /*for (int i = 0; i < lAB.Count; i++)//-6 para no tomar en cuenta los ultimos atributos
            {

                switch (lAB[i].TipoDato)
                {
                    case "int":
                        datI = bB.sacaInt(4);
                        if (lAB[i].Nombre != "Id_Usu_Mod" && lAB[i].Nombre != "Id_Usu_Alt" && lAB[i].Nombre != "Id_Usu_Baj")
                        {
                            dgvLeftJoin[i + lAA.Count - 6, dgvLeftJoin.RowCount - 1].Value = datI;
                        }
                        break;
                    case "float":
                        datD = bB.sacaFloat(8);
                        dgvLeftJoin[i + lAA.Count - 6, dgvLeftJoin.RowCount - 1].Value = datD;
                        break;
                    case "char":
                        datC = bB.sacaChar(2);
                        dgvLeftJoin[i + lAA.Count - 6, dgvLeftJoin.RowCount - 1].Value = datC;
                        break;
                    case "string":
                        dS = bB.sacaString(lAA[i].Tamaño);
                        if (lAB[i].Nombre != "Fecha_Mod" && lAB[i].Nombre != "Fecha_Alta" && lAB[i].Nombre != "Fecha_Baja")
                        {
                            dgvLeftJoin[i + lAA.Count - 6, dgvLeftJoin.RowCount - 1].Value = dS;
                        }
                        break;
                }
            }*/
        }
        #endregion

        
    }
}

/* **************************************************************************
 * Proyecto de la materia: Bases de Datos A                                 *
 * Maestra: Alicia A. V.                                          *
 * Autor: Jiménez Piña Daniel F.                                            *
 * Descripcion: Este proyecto simula la forma de organizar y ordenar        *   
 *              datos en un archivo, usando los diferentes tipos            *
 *              de organizaciones.                                          *
 ****************************************************************************/

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
    /* Esta clase es la clase principal del proyecto
     * controla la creacion de archivos para el diccionario
     * y las organizaciones.
     * controla la abertura de los archivos de diccionario
     * o archivos de las organizaciones creadas
     * controla el llamado a los dialogos de alta, baja
     * y modificacion de entidad y atributos.
     * controla el mantenimiento del diccionario y organizaciones.
     * controla el llamado a las clases de las organizaciones
     * para que se puedan ingresar datos y ordenarlos por los
     * diferentes metodos de organizacion
     */
    public partial class Diccionario : Form
    {
        private List<CUser> ListaU;
        private List<CEntidad> ListaE;
        private List<CAtributo> ListaA;
        private FileStream fs;
        private BinaryReader br;
        private string nom;
        private CArchivo arch;
        private long cab;
        private CEntidad ent;
        private CAtributo atr;
        private int inddgvE, inddgvA;
        private int indE;
        private int indEntEx;
        private string status;
        
        public Diccionario()
        {
            InitializeComponent();
        }

        /* Este metodo se encarga de inicializar la varibles
         * e inicializa las validaciones de los controles
         */
        private void Diccionario_Load(object sender, EventArgs e)
        {
            inddgvE = inddgvA = -1;
            ListaU = new List<CUser>();
            ListaE = new List<CEntidad>();
            ListaA = new List<CAtributo>();
            arch = new CArchivo();
            dgvU.Rows.Clear();
            dgvA.Rows.Clear();
            dgvE.Rows.Clear();
            
            cab = -1;
                        
            menuEntidad.Enabled = false;
            menuAltaEntidad.Enabled = false;
            menuBajaEntidad.Enabled = false;
            menuModificarEntidad.Enabled = false;
            botonAltaEntidad.Enabled = false;
            botonBajaEntidad.Enabled = false;
            botonModificaEntidad.Enabled = false;
            
            menuAtributo.Enabled = false;
            menuAltaAtributo.Enabled = false;
            menuBajaAtributo.Enabled = false;
            menuModificarAtributo.Enabled = false;
            botonAltaAtributo.Enabled = false;
            botonBajaAtributo.Enabled = false;
            botonModificaAtributo.Enabled = false;

            
        }

        /* Este metodo se invoca al dar clic en el menu o boton nuevo
         * este metodo crea y carga el dialogo para capturar el nombre
         * del nuevo archivo de diccionario.
         * crea el archivo para trabajar sobre el.
         * si el archivo ya existe manda un mensaje al
         * usuario
         */
        private void menuNuevoDiccionario_Click(object sender, EventArgs e)
        {
            ListaU.Clear();
            dgvU.Rows.Clear();
            ListaA.Clear();
            dgvA.Rows.Clear();

            ListaE.Clear();
            dgvE.Rows.Clear();
            DNombre dNom = new DNombre();
            dNom.Text = "Base de Datos";
            
            if (dNom.ShowDialog() == DialogResult.OK)
            {
                arch = new CArchivo();
                nom = dNom.tbNom.Text;
                arch.Nombre = nom + ".dbd";

                if (!File.Exists(arch.Nombre))
                {
                    arch.Crear_Archivo(cab);

                    menuEntidad.Enabled = true;
                    menuAltaEntidad.Enabled = true;
                    botonAltaEntidad.Enabled = true;

                    menuBajaEntidad.Enabled = false;
                    menuModificarEntidad.Enabled = false;
                    botonBajaEntidad.Enabled = false;
                    botonModificaEntidad.Enabled = false;

                    menuAtributo.Enabled = false;
                    menuAltaAtributo.Enabled = false;
                    menuBajaAtributo.Enabled = false;
                    menuModificarAtributo.Enabled = false;
                    botonAltaAtributo.Enabled = false;
                    botonBajaAtributo.Enabled = false;
                    botonModificaAtributo.Enabled = false;

                    mUsuarios.Enabled = true;
                }
                else
                    MessageBox.Show("No se puedo crear El Nombre ya existe");
            }
        }

        /* Este metodo se invoca cuando se da clic en el menu o boton Abrir
         * este metodo abre un dialogo con todos los archivos con extension .dic
         * para seleccionar el archivo que se desee y abrir
         * al abrirlo carga la lista de entidades y las muestra en el
         * dataGrid de entidades y activa algunos controles para
         * la manipulacion del diccionario.
         */
        private void menuAbrirDiccionario_Click(object sender, EventArgs e)
        {
            ListaU.Clear();
            dgvU.Rows.Clear();
            ListaE.Clear();
            dgvE.Rows.Clear();
            ListaA.Clear();
            dgvA.Rows.Clear();

            dialogoAbrirArchivo.Filter = "ficheros .dbd (*.dbd) | *.dbd|Todos(*.*)|*.*";

            if (dialogoAbrirArchivo.ShowDialog() == DialogResult.OK)
            {
                nom = dialogoAbrirArchivo.FileName;
                nom = nom.Substring(nom.LastIndexOf("\\") + 1);

                ListaE = arch.abrirArchivo(nom, cab);
                
                if (ListaE.Count > 0)
                {
                    menuEntidad.Enabled = true;
                    menuAltaEntidad.Enabled = true;
                    menuBajaEntidad.Enabled = true;
                    menuModificarEntidad.Enabled = true;
                    botonAltaEntidad.Enabled = true;
                    botonBajaEntidad.Enabled = true;
                    botonModificaEntidad.Enabled = true;
                }
                else
                {
                    menuEntidad.Enabled = true;
                    menuAltaEntidad.Enabled = true;
                    menuBajaEntidad.Enabled = false;
                    menuModificarEntidad.Enabled = false;
                    botonAltaEntidad.Enabled = true;
                    botonBajaEntidad.Enabled = false;
                    botonModificaEntidad.Enabled = false;
                }

                foreach (CEntidad corre in ListaE)
                {
                    dgvE.Rows.Add(corre.Nombre);
                    dgvE.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                }

                nom = arch.Nombre.Substring(0, arch.Nombre.Length - 4);
                FileStream fs = new FileStream(nom+".usr", FileMode.Open);
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    ListaU = (List<CUser>)formatter.Deserialize(fs);
                }
                catch (Exception)
                {
                    MessageBox.Show("No se puede abrir el archivo");
                }
                finally
                {
                    fs.Close();
                }
                foreach (CUser corre in ListaU)
                    dgvU.Rows.Add(corre.nombre, corre.pass, corre.hInicial, corre.hFinal, 
                                  corre.dias[0], corre.dias[1], corre.dias[2], corre.dias[3],
                                  corre.dias[4], corre.dias[5], corre.dias[6],"",
                                  corre.permisos[0], corre.permisos[1], corre.permisos[2], corre.permisos[3]);
                

                if (ListaA.Count > 0)
                {
                    menuAtributo.Enabled = true;
                    menuAltaAtributo.Enabled = true;
                    menuBajaAtributo.Enabled = true;
                    menuModificarAtributo.Enabled = true;
                    botonAltaAtributo.Enabled = true;
                    botonBajaAtributo.Enabled = true;
                    botonModificaAtributo.Enabled = true;

                    mUsuarios.Enabled = true;
                }
                else
                {
                    if (ListaE.Count > 0)
                    {
                        menuAtributo.Enabled = true;
                        menuAltaAtributo.Enabled = true;
                        menuBajaAtributo.Enabled = false;
                        menuModificarAtributo.Enabled = false;
                        botonAltaAtributo.Enabled = true;
                        botonBajaAtributo.Enabled = false;
                        botonModificaAtributo.Enabled = false;
                    }
                }
            }
        }

        /* Este metodo se encarga de cargar el dialogo
         * para capturar el nombre de la nueva entidad
         * y verifica que no exista la entidad en la lista
         * de entidades.
         * si no existe llama al metodo altaEntidad
         */
        private void menuAltaEntidad_Click(object sender, EventArgs e)
        {
            DNombre dNom = new DNombre();
            dNom.Text = "Nombre de la Entidad";
            bool bE = false;
            
            if (dNom.ShowDialog() == DialogResult.OK)
            {
                nom = dNom.tbNom.Text;
                ent = new CEntidad();
                ent.Nombre = nom;

                foreach (CEntidad correE in ListaE)
                    if (correE.Nombre == ent.Nombre)
                    {
                        MessageBox.Show("Ya existe una entidad con el mismo nombre");
                        bE = true;
                        break;
                    }
                if(!bE)
                    AltaEntidad(ent);

                dgvE.Rows.Clear();
                foreach (CEntidad corre in ListaE)
                {
                    dgvE.Rows.Add(corre.Nombre, corre.Direccion, corre.AptEntidad, corre.AptAtributo);
                    dgvE.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                }

                if (ListaE.Count > 0)
                {
                    menuAtributo.Enabled = true;
                    menuAltaAtributo.Enabled = true;
                    botonAltaAtributo.Enabled = true;

                    menuEntidad.Enabled = true;
                    menuAltaEntidad.Enabled = true;
                    menuBajaEntidad.Enabled = true;
                    menuModificarEntidad.Enabled = true;
                    botonAltaEntidad.Enabled = true;
                    botonBajaEntidad.Enabled = true;
                    botonModificaEntidad.Enabled = true;
                }
            }
        }

        /* Este metodo recibe una entidad calcula su lugar
         * en el archivo y la escribe y la inserta en orden
         * alfabetico en la lista de entidades y modifica
         * apuntadores
         */
        private void AltaEntidad(CEntidad ent)
        {
            fs = new FileStream(arch.Nombre, FileMode.Open, FileAccess.Read);
            br = new BinaryReader(fs);
            ent.Direccion = fs.Seek(0, SeekOrigin.End);
            br.Close();
            fs.Close();

            int ind = -1;

            if (ListaE.Count == 0 || String.Compare(ListaE[0].Nombre, ent.Nombre) > 0)
            {
                ent.AptEntidad = cab;
                cab = ent.Direccion;
                ListaE.Insert(0, ent);//Al inicio
                arch.Escribecab(cab);
            }
            else
            {
                foreach (CEntidad corre in ListaE)
                {
                    if (String.Compare(corre.Nombre, ent.Nombre) > 0)
                    {
                        ind = ListaE.IndexOf(corre);
                        break;
                    }
                }

                if (ind != -1)
                {
                    ent.AptEntidad = ListaE[ind].Direccion;
                    ListaE[ind - 1].AptEntidad = ent.Direccion;
                    arch.EscribeEntidad(ListaE[ind - 1]);
                    ListaE.Insert(ind, ent);
                }
                else
                {
                    ListaE[ListaE.Count - 1].AptEntidad = ent.Direccion;
                    arch.EscribeEntidad(ListaE[ListaE.Count - 1]);
                    ListaE.Add(ent);//Al final
                }
            }
            arch.EscribeEntidad(ent);
        }

        /* Este metodo se encarga de crear y cargar
         * el dialogo con la entidad seleccionada que se borrara
         * si regresa un Ok se modifican los apuntadores de la 
         * lista de entidades,
         * se llama al metodo baja entidad
         */
        private void menuBajaEntidad_Click(object sender, EventArgs e)
        {
            DBajaEnt dBE = new DBajaEnt();
            
            indE = inddgvE;
            dBE.cbEntidad.Text = ListaE[indE].Nombre;
            dBE.cbEntidad.Enabled = false;
            ent = ListaE[indE];
            
            if (dBE.ShowDialog() == DialogResult.OK)
            {
                ModificaAtributoLigado(ent);

                BajaEntidad(ent);

                foreach (CEntidad corre in ListaE)
                {
                    dgvE.Rows.Add(corre.Nombre);
                    dgvE.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                }
                dgvE.Rows.Clear();
                foreach (CEntidad corre in ListaE)
                {
                    dgvE.Rows.Add(corre.Nombre);
                    dgvE.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                }

                if (ListaE.Count == 0)
                {
                    menuEntidad.Enabled = true;
                    menuAltaEntidad.Enabled = true;
                    menuBajaEntidad.Enabled = false;
                    menuModificarEntidad.Enabled = false;
                    botonAltaEntidad.Enabled = true;
                    botonBajaEntidad.Enabled = false;
                    botonModificaEntidad.Enabled = false;

                    menuAtributo.Enabled = false;
                    menuAltaAtributo.Enabled = false;
                    menuBajaAtributo.Enabled = false;
                    menuModificarAtributo.Enabled = false;
                    botonAltaAtributo.Enabled = false;
                    botonBajaAtributo.Enabled = false;
                    botonModificaAtributo.Enabled = false;
                }
            }
        }

        /* Este metodo se encarga de eliminar
         * los apuntadores a ese entidad y
         * se modifican los apuntadores y se reescriben
         * la entidades que sean necesarias
         */
        private void BajaEntidad(CEntidad ent)
        {
            if (indE == 0)
            {
                cab = ListaE[indE].AptEntidad;
                arch.Escribecab(cab);
            }
            else
            {
                ListaE[indE - 1].AptEntidad = ListaE[indE].AptEntidad;
                arch.EscribeEntidad(ListaE[indE - 1]);
            }
            ListaE.RemoveAt(indE);
        }

        /* Este metodo se encarga de buscar la entidad
         * seleccionada en la lista de entidades
         * crea y carga el dialogo con la informacion de la entidad
         * para que pueda ser modificada
         */
        private void menuModificarEntidad_Click(object sender, EventArgs e)
        {
            DModificarEnt dME = new DModificarEnt();
            dME.Text = "Modificar Entidad";
            dME.cbEntSel.Text = ListaE[inddgvE].Nombre;
            dME.tbNom.Text = ListaE[inddgvE].Nombre;
            
            if (dME.ShowDialog() == DialogResult.OK)
            {
                bool bE = false;
                nom = dME.tbNom.Text;
                
                ent = new CEntidad();
                ent.Nombre = nom;
                ent.AptAtributo = ListaE[inddgvE].AptAtributo;
                ent.AptDatos = ListaE[inddgvE].AptDatos;

                foreach (CEntidad correE in ListaE)
                    if (correE.Nombre == ent.Nombre)
                    {
                        MessageBox.Show("Ya existe una entidad con el mismo nombre");
                        bE = true;
                        break;
                    }
                if (!bE)
                {
                    long dir = ListaE[inddgvE].Direccion;

                    indE = inddgvE;
                    BajaEntidad(ListaE[inddgvE]);
                    AltaEntidad(ent);

                    foreach (CEntidad correE in ListaE)
                    {
                        ListaA = arch.abrirArchivoAtributo(arch.Nombre, correE);
                        foreach (CAtributo correA in ListaA)
                        {
                            if (correA.AptEntidad == dir)
                            {
                                correA.AptEntidad = ent.Direccion;
                                arch.EscribeAtributo(correA);
                            }
                        }
                    }
                }
                

                dgvE.Rows.Clear();
                foreach (CEntidad corre in ListaE)
                {
                    dgvE.Rows.Add(corre.Nombre);
                    dgvE.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                }
            }
        }

        /* Este metodo se encarga de crear y cargar el dialogo
         * de con el que se capturaran los datos
         * del atributo
         * si regresa un OK se busca el atributo en la lista
         * de atributos de la entidad si el atributo existe
         * se manda un mensaje de que ya existe el atributo.
         * sino existe se llama al metodo altaAtributo
         */
        private void menuAltaAtributo_Click(object sender, EventArgs e)
        {
            DAltaAtr dAA = new DAltaAtr();
            bool b = false;
            bool ba = true;

            foreach (CEntidad corre in ListaE)
            {
                if(corre.Nombre != ListaE[inddgvE].Nombre)
                    dAA.cbEntExt.Items.Add(corre.Nombre);
            }
            dAA.cbEntSel.Text = ListaE[inddgvE].Nombre;
            dAA.na = arch.Nombre;
            
            if (dAA.ShowDialog() == DialogResult.OK)
            {
                nom = dAA.tbNom.Text;
                atr = new CAtributo();
                atr.Nombre = nom;

                foreach (CAtributo correA in ListaA)
                    if (correA.Nombre == atr.Nombre)
                    {
                        MessageBox.Show("La Entidad ya Tiene un Atributo Con el mismo Nombre");
                        b = true;
                        break;
                    }
                    if(!b)
                    {
                        switch (atr.TipoDato = dAA.cbTipo.Text)
                        {
                            case "string":
                                atr.Tamaño = Convert.ToInt32(dAA.tbTam.Text);
                            break;
                            case "int":
                                atr.Tamaño = 4;
                            break;
                            case "float":
                                atr.Tamaño = 4;
                            break;
                            case "char":
                                atr.Tamaño = 2;
                            break;
                        /*if ((atr.TipoDato = dAA.cbTipo.Text) == "string")
                        {
                            atr.Tamaño = Convert.ToInt32(dAA.tbTam.Text);*/
                        }
                        atr.TipoClave = dAA.TipoClave;
                        switch (atr.TipoClave)
                        {
                            case 1:
                                foreach (CAtributo correA in ListaA)
                                {
                                    if (correA.TipoClave == 1)
                                    {
                                        DMClaveP dMCP = new DMClaveP();
                                        dMCP.lbEnt.Text = ListaE[inddgvE].Nombre;
                                        dMCP.lbAtr.Text = correA.Nombre;
                                        if (dMCP.ShowDialog() == DialogResult.OK)
                                        {
                                            correA.TipoClave = 0;
                                            arch.EscribeAtributo(correA);
                                        }
                                        else
                                        {
                                            atr.TipoClave = 0;
                                        }
                                        break;
                                    }
                                }
                            break;
                            case 2:
                                List<CAtributo> auxAtr = new List<CAtributo>();
                                
                                indEntEx = dAA.iee;
                                foreach (CAtributo ca in ListaA)
                                {
                                    if (ca.AptEntidad == ListaE[indEntEx].Direccion)
                                    {
                                        ba = false;
                                        MessageBox.Show("Ya existe un atributo que apunta a la entidad");
                                        break;
                                    }
                                }

                                if (ba)
                                {
                                    atr.AptEntidad = ListaE[indEntEx].Direccion;
                                    auxAtr = arch.abrirArchivoAtributo(arch.Nombre, ListaE[indEntEx]);
                                    if (auxAtr.Count > 0)
                                    {
                                        foreach (CAtributo correA in auxAtr)
                                        {
                                            if (correA.TipoClave == 1)
                                            {
                                                atr.TipoDato = correA.TipoDato;
                                                dAA.cbTipo.Enabled = false;
                                                b = false;
                                                break;
                                            }
                                            else
                                                b = true;
                                        }
                                        if (b == true)
                                            MessageBox.Show("No se encontro un atributo con clave primaria en la entidad\n"+
                                                            "Seleccione otra entidad");
                                    }
                                    else
                                    {
                                        b = true;
                                        MessageBox.Show("La entidad no tiene Atributos");
                                    }
                                }
                            break;
                        }
                    }
                if (b == false && ba == true)
                {
                    fs = new FileStream(arch.Nombre, FileMode.Open, FileAccess.Read);
                    br = new BinaryReader(fs);
                    atr.Direccion = fs.Seek(0, SeekOrigin.End);
                    br.Close();
                    fs.Close();

                    AltaAtributo(atr, inddgvE);
                    
                    dgvA.Rows.Clear();
                    dgvE_SelectionChanged(sender, e);
                    
                    menuBajaAtributo.Enabled = true;
                    menuModificarAtributo.Enabled = true;
                    botonBajaAtributo.Enabled = true;
                    botonModificaAtributo.Enabled = true;
                }
            }

            
        }

        /* Este metodo inserta el atributo
         * en la posicion que le corresponde
         * dentro de la lista de atributos de la entidad
         * y se escribe el atributo en el archivo
         * se modifican los apuntadores y se reescriben
         * las entidades que sean necesarias
         */
        private void AltaAtributo(CAtributo at, int indEnt)//La lista de atributos se carga al seleccionar la entidad
        {
            if (ListaA.Count == 0)
            {
                ListaE[indEnt].AptAtributo = at.Direccion;
                arch.EscribeEntidad(ListaE[indEnt]);
            }
            else
            {
                ListaA[ListaA.Count - 1].AptAtributo = at.Direccion;
                arch.EscribeAtributo(ListaA[ListaA.Count - 1]);
            }
            ListaA.Add(at);//Al final
            arch.EscribeAtributo(at);
        }

        /* Este metodo crea y carga el dialogo
         * con la informacion del atributo que sera eliminado
         * si regresa OK se llama al metodo bajaAtributo
         */
        private void menuBajaAtributo_Click(object sender, EventArgs e)
        {
            DBajaAtr dBA = new DBajaAtr();
            
            
            dBA.cbEntSel.Text = ListaE[inddgvE].Nombre;
            dBA.cbAtrSel.Text = ListaA[inddgvA].Nombre;
            
            if (dBA.ShowDialog() == DialogResult.OK)
            {
                ModificaAtributoLigado(ListaE[inddgvE]);

                BajaAtributo(inddgvA, inddgvE);

                dgvA.Rows.Clear();
                foreach (CAtributo corre in ListaA)
                {
                    switch (corre.TipoClave)
                    {
                        case 0: status = "CN"; break;
                        case 1: status = "KP"; break;
                        case 2: status = "KF"; break;
                        case 3: status = "CR"; break;
                    }
                    dgvA.Rows.Add(corre.Nombre, corre.TipoDato, corre.Tamaño, status);
                    dgvA.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                }
            }

            if (ListaA.Count == 0)
            {
                menuAtributo.Enabled = true;
                menuAltaAtributo.Enabled = true;
                menuBajaAtributo.Enabled = false;
                menuModificarAtributo.Enabled = false;
                botonAltaAtributo.Enabled = true;
                botonBajaAtributo.Enabled = false;
                botonModificaAtributo.Enabled = false;
            }
        }

        /* Este metodo busca el atributo
         * dentro de la lista de atributos
         * y modifica los apuntadores que apuntan 
         * a el y reescribe los atributos que se modificaron
         */
        private void BajaAtributo(int indA, int indE)
        {
            if (indA == 0)
            {
                ListaE[indE].AptAtributo = ListaA[indA].AptAtributo;
                arch.EscribeEntidad(ListaE[indE]);
            }
            else
            {
                ListaA[indA - 1].AptAtributo = ListaA[indA].AptAtributo;
                arch.EscribeAtributo(ListaA[indA - 1]);
            }
            ListaA.RemoveAt(indA);
        }

        /* Este metodo crea y carga el dialogo con la informacion
         * del atributo seleccionado para que puedan ser modificados
         * actualiza la informacion del dataGrid de atributos si
         * hubo cambios.
         */
        private void menuModificarAtributo_Click(object sender, EventArgs e)
        {
            DModificaAtr dMA = new DModificaAtr();
            inddgvA = dgvA.CurrentRow.Index;
            bool b = false;
            int tca = 0;
            foreach (CEntidad corre in ListaE)
            {
                if (corre.Nombre != ListaE[inddgvE].Nombre)
                    dMA.cbEntExt.Items.Add(corre.Nombre);
            }
            dMA.na = arch.Nombre;
            dMA.tbEntSel.Text = ListaE[inddgvE].Nombre;
            dMA.tbAtrSel.Text = ListaA[inddgvA].Nombre;
            switch (ListaA[inddgvA].TipoClave)
            {
                case 0:
                    tca = 0;
                break;
                case 1:
                    tca = 1;
                break;
                case 2:
                    tca = 2;
                break;
            }

            if (dMA.ShowDialog() == DialogResult.OK)
            {
                bool ba = true;
                nom = dMA.tbNom.Text;
                atr = new CAtributo();
                atr.Nombre = nom;

                foreach (CAtributo correA in ListaA)
                    if (correA.Nombre == atr.Nombre && atr.Nombre != dMA.tbAtrSel.Text)
                    {
                        MessageBox.Show("La Entidad ya Tiene un Atributo Con el mismo Nombre");
                        b = true;
                        break;
                    }
                if (!b)
                {
                    switch (atr.TipoDato = dMA.cbTipo.Text)
                    {
                        case "string":
                            atr.Tamaño = Convert.ToInt32(dMA.tbTam.Text);
                            break;
                        case "int":
                            atr.Tamaño = 4;
                            break;
                        case "float":
                            atr.Tamaño = 4;
                            break;
                        case "char":
                            atr.Tamaño = 2;
                            break;
                    }
                    /*if (( dMA.cbTipo.Text) == "string")
                    {
                        atr.Tamaño = Convert.ToInt32(dMA.tbTam.Text);
                    }*/
                    atr.TipoClave = dMA.TipoClave;
                    switch (atr.TipoClave)
                    {
                        case 0:
                            DMClaveP dMCP1 = new DMClaveP();
                            dMCP1.Text = "Eliminar Relaciones";
                            dMCP1.lbMensaje.Text = "Si Continua se Eliminaran Las Relaciones";
                            dMCP1.lbAtr.Visible = false;
                            dMCP1.lbEnt.Visible = false;
                            if (tca == 1)
                            {
                                if (dMCP1.ShowDialog() == DialogResult.OK)
                                    ModificaAtributoLigado(ListaE[inddgvE]);
                                else
                                    b = true;
                            }
                        break;
                        case 1:
                            foreach (CAtributo correA in ListaA)
                            {
                                if (correA.TipoClave == 1)
                                {
                                    DMClaveP dMCP = new DMClaveP();
                                    dMCP.lbEnt.Text = ListaE[inddgvE].Nombre;
                                    dMCP.lbAtr.Text = correA.Nombre;
                                    if (dMCP.ShowDialog() == DialogResult.OK)
                                    {
                                        correA.TipoClave = 0;
                                        ModificaAtributoLigado(ListaE[inddgvE]);
                                        arch.EscribeAtributo(correA);
                                    }
                                    else
                                    {
                                        b = true;
                                    }
                                    break;
                                }
                            }
                        break;
                        case 2:
                            if (tca == 1)
                            {
                                ModificaAtributoLigado(ListaE[inddgvE]);
                            }
                            List<CAtributo> auxAtr = new List<CAtributo>();

                            indEntEx = dMA.iee;
                            foreach (CAtributo ca in ListaA)
                                {
                                    if (ca.AptEntidad == ListaE[indEntEx].Direccion)
                                    {
                                        ba = false;
                                        MessageBox.Show("Ya existe un atributo que apunta a la entidad");
                                        break;
                                    }
                                }
                            if(ba)
                            {
                                atr.AptEntidad = ListaE[indEntEx].Direccion;
                                auxAtr = arch.abrirArchivoAtributo(arch.Nombre, ListaE[indEntEx]);
                                if (auxAtr.Count > 0)
                                {
                                    foreach (CAtributo correA in auxAtr)
                                    {
                                        if (correA.TipoClave == 1)
                                        {
                                            atr.TipoDato = correA.TipoDato;
                                            dMA.cbTipo.Enabled = false;
                                            break;
                                        }
                                    }
                                    if (dMA.cbTipo.Enabled == true)
                                    {
                                        MessageBox.Show("No se encontro un atributo con clave primaria en la entidad");
                                        b = true;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("La entidad no tiene Atributos");
                                }
                            }
                            break;
                    }
                }
                if (b == false && ba == true)
                {
                    fs = new FileStream(arch.Nombre, FileMode.Open, FileAccess.Read);
                    br = new BinaryReader(fs);
                    atr.Direccion = fs.Seek(0, SeekOrigin.End);
                    br.Close();
                    fs.Close();

                    BajaAtributo(inddgvA, inddgvE);
                    AltaAtributo(atr, inddgvE);

                    dgvA.Rows.Clear();
                    dgvE_SelectionChanged(sender, e);
                }
            }
        }

        /* Este metodo limpia y actualiza la informacion
         * del dataGrid de atributos segun la entidad seleccionada.
         * se carga la lista de esta y se imprime en el dataGrid
         */
        private void dgvE_SelectionChanged(object sender, EventArgs e)
        {
            ListaA.Clear();
            dgvA.Rows.Clear();

            inddgvE = dgvE.CurrentRow.Index;
            
            if (ListaE.Count > 0)
            {
                if(inddgvE < ListaE.Count)
                    ListaA = arch.abrirArchivoAtributo(arch.Nombre, ListaE[inddgvE]);
                foreach (CAtributo corre in ListaA)
                {
                    switch (corre.TipoClave)
                    {
                        case 0: status = "CN"; break;
                        case 1: status = "KP"; break;
                        case 2: status = "KF"; break;
                        case 3: status = "CR"; break;
                    }
                    dgvA.Rows.Add(corre.Nombre, corre.TipoDato, corre.Tamaño, status);
                    dgvA.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                }
            }
            if (ListaA.Count > 0)
            {
                menuBajaAtributo.Enabled = true;
                menuModificarAtributo.Enabled = true;
                botonAltaAtributo.Enabled = true;
                botonBajaAtributo.Enabled = true;
                botonModificaAtributo.Enabled = true;
            }
            else
            {
                menuAtributo.Enabled = true;
                menuAltaAtributo.Enabled = true;
                menuBajaAtributo.Enabled = false;
                menuModificarAtributo.Enabled = false;
                botonAltaAtributo.Enabled = true;
                botonBajaAtributo.Enabled = false;
                botonModificaAtributo.Enabled = false;
            }
        }

        /* Este metodo es llamado si alguno atributo con 
         * clave esterna es modificado
         */
        private void ModificaAtributoLigado(CEntidad ent)
        {
            List<CAtributo> aux_LA = new List<CAtributo>();
            
            foreach(CEntidad correE in ListaE)
            {
                aux_LA = arch.abrirArchivoAtributo(arch.Nombre, correE);
                foreach (CAtributo correA in aux_LA)
                {
                    if (correA.AptEntidad == ent.Direccion)
                    {
                        correA.AptEntidad = -1;
                        correA.TipoClave = 0;
                        arch.EscribeAtributo(correA);
                        break;
                    }
                }
            }
        }

        /* Este metodo captura el indice que corresponde al atributo seleccionado*/
        private void dgvA_SelectionChanged(object sender, EventArgs e)
        {
            inddgvA = dgvA.CurrentRow.Index;
        }

        /* Este metodo impide que se cierre la forma
         * si alguna entida no cueta con atributos
         * con clave primaria.
         * si falta alguna, mustra un mensaje con 
         * el nombre de la entidad que esta incompleta
         */
        private void Diccionario_FormClosing(object sender, FormClosingEventArgs e)
        {
            CAtributo a = new CAtributo();
            
            foreach (CEntidad correE in ListaE)
            {
                ListaA = arch.abrirArchivoAtributo(arch.Nombre, correE);
                if (ListaA.Count == 0)
                {
                    e.Cancel = true;
                    MessageBox.Show("La Entidad    " + correE.Nombre + "    No Tiene Atributos Con Clave Primaria");
                    break;
                }
                else
                {
                    foreach (CAtributo correA in ListaA)
                    {
                        a = correA;
                        if (a.TipoClave == 1)
                            break;
                    }
                    if (a.TipoClave != 1)
                    {
                        e.Cancel = true;
                        MessageBox.Show("La Entidad    " + correE.Nombre + "    No Tiene Atributos Con Clave Primaria");
                        break;
                    }
                }

                inAtrDefault();
            }
            
            
            if (arch.Nombre != null)
            {
                nom = arch.Nombre.Substring(0, arch.Nombre.Length - 4);
                FileStream fs = new FileStream(nom+".usr", FileMode.Create);
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    formatter.Serialize(fs, ListaU);
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo guardar el archivo");
                }
                finally
                {
                    fs.Close();
                }
            }

            /*if (ListaE.Count > 0)
            {
                CMantenimiento md = new CMantenimiento();
                md.mantenimientoDic(arch.Nombre);
            }*/
        }

        public void inAtrDefault()
        {
            CAtributo a;
            bool exat = false;
                        
            foreach (CAtributo atr in ListaA)
            {
                if (atr.Nombre == "Fecha_Alta")
                {
                    exat = true;
                    break;
                }
            }

            if (!exat)
            {
                a = new CAtributo();
                a.Nombre = "Fecha_Alta";
                a.TipoDato = "string";
                a.Tamaño = 10;
                a.TipoClave = 0;
                a.Direccion = sacaDir();
                AltaAtributo(a, -1); //No necesita el numero de la entidad para darlo de Alta

                a = new CAtributo();
                a.Nombre = "Id_Usu_Alt";
                a.TipoDato = "int";
                a.Tamaño = 4;
                a.TipoClave = 0;
                a.Direccion = sacaDir();
                AltaAtributo(a, -1); //No necesita el numero de la entidad para darlo de Alta

                a = new CAtributo();
                a.Nombre = "Fecha_Baja";
                a.TipoDato = "string";
                a.Tamaño = 10;
                a.TipoClave = 0;
                a.Direccion = sacaDir();
                AltaAtributo(a, -1); //No necesita el numero de la entidad para darlo de Alta

                a = new CAtributo();
                a.Nombre = "Id_Usu_Baj";
                a.TipoDato = "int";
                a.Tamaño = 4;
                a.TipoClave = 0;
                a.Direccion = sacaDir();
                AltaAtributo(a, -1); //No necesita el numero de la entidad para darlo de Alta

                a = new CAtributo();
                a.Nombre = "Fecha_Mod";
                a.TipoDato = "string";
                a.Tamaño = 10;
                a.TipoClave = 0;
                a.Direccion = sacaDir();
                AltaAtributo(a, -1); //No necesita el numero de la entidad para darlo de Alta

                a = new CAtributo();
                a.Nombre = "Id_Usu_Mod";
                a.TipoDato = "int";
                a.Tamaño = 4;
                a.TipoClave = 0;
                a.Direccion = sacaDir();
                AltaAtributo(a, -1); //No necesita el numero de la entidad para darlo de Alta
                
            }
        }

        public long sacaDir()
        {
            long dir;

            fs = new FileStream(arch.Nombre, FileMode.Open, FileAccess.Read);
            br = new BinaryReader(fs);
            dir = fs.Seek(0, SeekOrigin.End);
            br.Close();
            fs.Close();

            return dir;
        }

        /* Este metodo se llama cuando se da clic
         * en el menu de mateniemto del diccionario
         * crea y llama a la clase que se encarga de hacer
         * el mantenimiento del diccionario
         */
        private void menuMDiccionario_Click(object sender, EventArgs e)
        {
            CMantenimiento md = new CMantenimiento();

            md.mantenimientoDic(arch.Nombre);
            ListaE = arch.abrirArchivo(arch.Nombre, cab);
        }

        /* Este metodo se llama cuando se da clic
         * en el menu de abrir secuencil
         * abre un dialgo con archivos con extensio .sec
         * se cargan las lista de entidades atributos
         * del archivo y se muestra el dialo que controla
         * los datos de la organizacion secuencial
         *
        public void AbrirBD()
        {
            CSecuencial ms = new CSecuencial();
            arch = new CArchivo();

            dialogoAbrirArchivo.Filter = "ficheros .dbd (*.dbd) | *.dbd";

            if (dialogoAbrirArchivo.ShowDialog() == DialogResult.OK)
            {
                ms.NomSec = dialogoAbrirArchivo.FileName;
                ms.NomSec = ms.NomSec.Substring(ms.NomSec.LastIndexOf("\\") + 1);

                ListaE = arch.abrirArchivo(ms.NomSec, cab);

                ms.ShowDialog();
            }
        }*/
        

        private void mUsuarios_Click(object sender, EventArgs e)
        {
            CUsuario dU = new CUsuario(ListaU);
            CUser us = new CUser();

            if (arch.Nombre != null && dU.ShowDialog() == DialogResult.OK)
            {
                us.nombre = dU.nombre;
                us.pass = dU.pass;
                us.hInicial = dU.hInicial;
                us.hFinal = dU.hFinal;
                us.dias = dU.dias;
                us.permisos = dU.permisos;

                ListaU.Add(us);

                dgvU.Rows.Clear();

                foreach (CUser corre in ListaU)
                {
                    dgvU.Rows.Add(corre.nombre, corre.pass, corre.hInicial, corre.hFinal,
                                  corre.dias[0], corre.dias[1], corre.dias[2], corre.dias[3],
                                  corre.dias[4], corre.dias[5], corre.dias[6], "",
                                  corre.permisos[0], corre.permisos[1], corre.permisos[2], corre.permisos[3]);
                    dgvU.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                }
            }

            if (arch.Nombre == null)
                MessageBox.Show("Necesita Abrir o Crear una Estructura\n"+
                                "Para agregar un nuevo Usuario");
        }

        

    }
}

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
    public partial class CUsuario : Form
    {
        public string nombre;
        public string pass;
        /*public int hInicial;
        public int mInicial;
        public int sInicial;
        public int hFinal;
        public int mFinal;
        public int sFinal;*/
        public string hInicial;
        public string hFinal;
        public bool[] dias;
        public bool[] permisos;
        private List<CUser> LU;

        public CUsuario(List<CUser> lu)
        {
            InitializeComponent();
            LU = new List<CUser>();
            LU = lu;
        }
         
        private void CUsuario_Load(object sender, EventArgs e)
        {
            dias = new bool[7];
            permisos = new bool[4];   
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            
            nombre = tbNombre.Text;
            pass = tbContraseña.Text;

            /*hInicial = tbHI.Text;
            hFinal = tbHF.Text;
            hInicial = Convert.ToInt32(tbHI.Text);
            mInicial = Convert.ToInt32(tbMI.Text);
            sInicial = Convert.ToInt32(tbSI.Text);
            
            hFinal = Convert.ToInt32(tbHF.Text);
            mFinal = Convert.ToInt32(tbMF.Text);
            sFinal = Convert.ToInt32(tbSF.Text);*/

            hInicial = cbHInicial.Text;
            hFinal = cbHFinal.Text;

            dias[0] = cbLunes.Checked;
            dias[1] = cbMartes.Checked;
            dias[2] = cbMiercoles.Checked;
            dias[3] = cbJueves.Checked;
            dias[4] = cbViernes.Checked;
            dias[5] = cbSabado.Checked;
            dias[6] = cbDomingo.Checked;

            permisos[0] = cbAlta.Checked;
            permisos[1] = cbBaja.Checked;
            permisos[2] = cbConsulta.Checked;
            permisos[3] = cbModifica.Checked;
        }

        private void CUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                DateTime hi = Convert.ToDateTime(cbHInicial.Text);
                DateTime hf = Convert.ToDateTime(cbHFinal.Text);

                foreach(CUser u in LU)
                    if (u.nombre == tbNombre.Text)
                    {
                        MessageBox.Show("El Nombre Usuario ya Existe");
                        e.Cancel = true;
                        break;
                    }
                if (tbNombre.TextLength < 4)
                {
                    e.Cancel = true;
                    MessageBox.Show("El Nombre Debe de Contener al Menos 4 Caracteres");
                }
                if (tbContraseña.TextLength < 4)
                {
                    e.Cancel = true;
                    MessageBox.Show("La Contraseña Debe de Contener al Menos 4 Caracteres");
                }
                
                if (hi.CompareTo(hf) >= 0)
                {
                    e.Cancel = true;
                    MessageBox.Show("La hora Inicial No Puede Ser Mayor o Igual a la Hora Final\n");
                }
            }
        }

        

        
    }
}

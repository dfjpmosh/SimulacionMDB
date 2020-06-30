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
    public partial class CLogin : Form
    {
        public CLogin()
        {
            InitializeComponent();
        }

        private void CLogin_Load(object sender, EventArgs e)
        {

        }

        private void tbUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void lUsuario_Click(object sender, EventArgs e)
        {

        }

        private void CLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (tbUsuario.TextLength < 1 || tbContraseña.TextLength < 1)
                {
                    e.Cancel = true;
                    MessageBox.Show("No Deje Campos Vacios");
                }
            }
        }
    }
}

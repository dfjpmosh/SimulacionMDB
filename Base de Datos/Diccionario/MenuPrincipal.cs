using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Diccionario
{
    public partial class MenuPrincipal : Form
    {
        Diccionario dic = new Diccionario();
        CSecuencial dSec = new CSecuencial();
        FormSQL fsql = new FormSQL();

        public MenuPrincipal()
        {
            /*Thread t = new Thread(new ThreadStart(SplashScreen));
            t.Start();
            Thread.Sleep(12000);
            t.Abort();*/
            InitializeComponent();
        }
        
        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }
        
        public void SplashScreen()
        {
            Application.Run(new FormPreload());
        }

        private void mMantemiento_Click(object sender, EventArgs e)
        {
            CSecuencial ms = new CSecuencial();

            ms.ShowDialog();
        }

        private void mEstructura_Click(object sender, EventArgs e)
        {
            CLogin dl = new CLogin();

            if (dl.ShowDialog() == DialogResult.OK)
            {
                if (dl.tbUsuario.Text == "Admon" && dl.tbContraseña.Text == "12345")
                    dic.ShowDialog();
                else
                    MessageBox.Show("Usuario o Contraseña Incorrecta");
            }
        }

        private void bSQL_Click(object sender, EventArgs e)
        {
            CLogin dl = new CLogin();

            if (dl.ShowDialog() == DialogResult.OK)
            {
                if (dl.tbUsuario.Text == "Admon" && dl.tbContraseña.Text == "12345")
                    fsql.ShowDialog();
                else
                    MessageBox.Show("Usuario o Contraseña Incorrecta");
            }
        }

        

        
    }
}

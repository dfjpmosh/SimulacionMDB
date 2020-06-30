using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diccionario
{
    [Serializable]
    public class CUser
    {
        public string nombre;
        public string pass;
        public string hInicial;
        public string hFinal;
        /*public int hInicial;
        public int mInicial;
        public int sInicial;
        public int hFinal;
        public int mFinal;
        public int sFinal;*/
        public bool[] dias;
        public bool[] permisos;
    }
}

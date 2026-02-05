using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad3
{
    internal class NodoGrafo<T>
    {
        public string Clave { get; set; }

        public NodoGrafo(string clave)
        {
            Clave = clave;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad3
{
    internal class ListAdyacencia
    {
        public string Destino { get; set; }
        public int Peso { get; set; }
        public ListAdyacencia Siguiente {  get; set; }

        public ListAdyacencia(string destino, int peso)
        {
            Destino = destino;
            Peso = peso;
            Siguiente = null;
        }
        
       
    }
}

    

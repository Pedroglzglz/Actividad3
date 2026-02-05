using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Actividad3
{
    internal class Grafo
    {
        private NodoGrafo<string> nodo;
        private int contador;
        private Dictionary<string, ListAdyacencia> listaAdyacencia;
        private Dictionary<string, object> valoresNodos;
        public Grafo()
        {
            nodo = null;
            listaAdyacencia = new Dictionary<string, ListAdyacencia>();
            valoresNodos = new Dictionary<string, object>();
        }

        public bool InsertarNodo(NodoGrafo<string> nodoInsercion)
        {
            if (listaAdyacencia.ContainsKey(nodoInsercion.Clave))
            {
                return false;
            }

            listaAdyacencia[nodoInsercion.Clave] = null;
            valoresNodos[nodoInsercion.Clave] = null;
            contador++;
            return true;
        }

        public bool BorrarNodo(string clave)
        {
            if (!listaAdyacencia.ContainsKey(clave))
            {
                return false;
            }
            listaAdyacencia.Remove(clave);
            valoresNodos.Remove(clave);

            foreach(var nodo in listaAdyacencia.Keys)
            {
                EliminarDeListaAdyacencia(nodo, clave);
            }
            contador--;
            return true;
        }

        public bool ExisteNodo(string clave)
        {
            if (listaAdyacencia.ContainsKey(clave)) 
            {
                return true;
            }
            return false;
        }

        private bool EliminarDeListaAdyacencia(string origen, string destino)
        {
            if (!listaAdyacencia.ContainsKey(origen))
            {
                return false;
            }
            ListAdyacencia actual = listaAdyacencia[origen];
            ListAdyacencia anterior = null;

            while(actual != null)
            {
                if(actual.Destino == destino)
                {
                    if(anterior == null)
                    {
                        listaAdyacencia[origen] = actual.Siguiente;
                    }
                    else
                    {
                        anterior.Siguiente = actual.Siguiente;
                    }
                    return true;
                }
                anterior = actual;
                actual = actual.Siguiente;
            }

            return false;
        }
    }

    

    
}

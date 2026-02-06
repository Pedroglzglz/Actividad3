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

        // Método para insertar aristas entre los nodos (gasolineras)
        public bool InsertarArista(string origen, string destino, int peso)
        {
            // Si no existe ningun nodo se devuelve false
            if(!ExisteNodo(origen) || !ExisteNodo(destino))
            {
                return false;
            }

            // Comprobar si ya existe la conexión
            ListAdyacencia actual = listaAdyacencia[origen];
            while (actual != null)
            {
                if (actual.Destino == destino) return false; // Ya existe
                actual = actual.Siguiente;
            }

            // Crear nueva arista e insertarla al principio
            ListAdyacencia nuevaConexion = new ListAdyacencia(destino, peso);
            
            // El siguiente del nuevo será el que antes era el primero
            nuevaConexion.Siguiente = listaAdyacencia[origen];
            
            // Actualizamos la cabecera
            listaAdyacencia[origen] = nuevaConexion;

            return true;

        }

        // Método para eliminar una arista entre dos nodos
        public bool BorrarArista(string origen, string destino)
        {
            // Si no existe ningun nodo se devuelve false
            if (!ExisteNodo(origen) || !ExisteNodo(destino))
            {
                return false;
            }

            return EliminarDeListaAdyacencia(origen, destino);
        }

        // Método para verificar si existe una arista entre dos nodos
        public bool ExisteArista(string origen, string destino)
        {
            if (!ExisteNodo(origen) || !ExisteNodo(destino))
            {
                return false;
            }

            ListAdyacencia actual = listaAdyacencia[origen];
            while (actual != null)
            {
                if (actual.Destino == destino) return true; // Existe la conexión
                actual = actual.Siguiente;
            }
            return false; // No existe la conexión
        }

        public override string ToString()
        {
            string resultado = "";

            foreach(var nodoKey in listaAdyacencia.Keys)
            {
                // Obtenemos el primer nodo de la lista enlazada
                ListAdyacencia actual = listaAdyacencia[nodoKey];

                while (actual != null)
                {
                    resultado += $" -> {actual.Destino} ({actual.Peso}km) ";
                    actual = actual.Siguiente;
                }

                resultado += "\n";
            }

            return resultado;
        }

        public int NumeroNodos
        {
            get { return contador; }
        }

        public int NumeroAristas
        {
            get 
            {
                int total = 0;
                foreach(var nodoKey in listaAdyacencia.Keys)
                {
                    ListAdyacencia actual = listaAdyacencia[nodoKey];
                    while (actual != null)
                    {
                        total++;
                        actual = actual.Siguiente;
                    }
                }
                return total;
            }
        }
    }
    
}

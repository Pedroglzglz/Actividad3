using System;

namespace Actividad3
{
    internal class Gasolinera : NodoGrafo<string> 
    {
        // Atributos propios de la Gasolinera
        public string Rotulo { get; private set; }
        public string Direccion { get; private set; }
        public string Latitud { get; private set; }
        public string Longitud { get; private set; }

        public Gasolinera(string clave, string rotulo, string direccion, string localidad, string latitud, string longitud) 
            : base(clave) 
        {
            this.Rotulo = rotulo;
            this.Direccion = direccion;
            this.Latitud = latitud;
            this.Longitud = longitud;
        }

        public override string ToString()
        {
            return $"{Rotulo} - {Direccion}";
        }
    }
}
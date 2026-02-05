using System;

namespace Actividad3
{
    internal class Gasolinera : NodoGrafo<string> 
    {
        // Atributos propios de la Gasolinera
        public string Rotulo { get; private set; }
        public string Direccion { get; private set; }
        public string Localidad { get; private set; }
        public double Latitud { get; private set; }
        public double Longitud { get; private set; }

        public Gasolinera(string rotulo, string direccion, string localidad, double latitud, double longitud) 
            : base(rotulo) 
        {
            this.Rotulo = rotulo;
            this.Direccion = direccion;
            this.Localidad = localidad;
            this.Latitud = latitud;
            this.Longitud = longitud;
        }

        public override string ToString()
        {
            return $"{Rotulo} - {Direccion} ({Localidad})";
        }
    }
}
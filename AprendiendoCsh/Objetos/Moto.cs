using AprendiendoCsh.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendiendoCsh.Objetos
{
    internal class Moto : Persona, IEstandarVehiculo
    {
        public string Marca { get; set; }
        public string Color { get; set; }
        public double Kilometraje { get; set; }
        public string TipoEoA { get; set; }
        public string Placas { get; set; }
        public int Año { get; set; }
        //private string localizacion { get; set; }
        //protected string placa { get; set; }
        public Moto(string Color, double Kilometraje, string Nombre,
            string ApellidoP, string ApellidoM, int Edad) : base(Nombre,
                ApellidoP, ApellidoM, Edad)
        {
            this.Color = Color;
            this.Kilometraje = Kilometraje;
        }

        public void Usar(double recorrido)
        {
            this.Kilometraje += recorrido;
        }
    }
}

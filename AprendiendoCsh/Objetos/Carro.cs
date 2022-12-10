using System;

namespace AprendiendoCsh.Objetos
{
    internal class Carro:Persona
    {
        public string Color { get; set; }
        public int Kilometraje { get; set; }
        //private string localizacion { get; set; }
        //protected string placa { get; set; }

        public Carro(string Color, int Kilometraje, string Nombre, 
            string ApellidoP, string ApellidoM, int Edad) :base(Nombre,
                ApellidoP, ApellidoM, Edad)
        {
            this.Color = Color;
            this.Kilometraje = Kilometraje;
        }
        public void usar(int recorrido) {
            this.Kilometraje += recorrido;
        }
    }
}

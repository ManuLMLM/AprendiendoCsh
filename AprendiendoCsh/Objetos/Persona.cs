using System;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

namespace AprendiendoCsh.Objetos
{
    internal class Persona
    {
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public int Edad { get; set; }
        public bool Permiso { get; set; }

        public Persona(string Nombre, string ApellidoP, string ApellidoM,int Edad)
        {
            this.Nombre = Nombre;
            this.ApellidoP = ApellidoP;
            this.ApellidoM = ApellidoM;
            this.Edad = Edad;
            
        }

        public void EdadConducir(int Edad)
        {
            if (Edad >= 18)
            {
                this.Permiso = true;
                Console.WriteLine("Sí puede conducir");
            }
            else
            {
                this.Permiso = false;
                Console.WriteLine("No puede conducir");
            }
            
        }
    }
}

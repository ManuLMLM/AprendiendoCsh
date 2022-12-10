using System;
using System.Transactions;
using AprendiendoCsh.Objetos;

namespace AprendiendoCsh
{
    internal class Clases
    {
        static void Main(string[] arg)
        {
            Persona persona1 = new Persona("Luis", "López", "Morales", 17);
            Carro carro1 = new Carro("Rojo",1200,persona1.Nombre,persona1.ApellidoP,
                persona1.ApellidoM,persona1.Edad);
            persona1.EdadConducir(persona1.Edad);
            if (persona1.Permiso == true)
            {
                carro1.usar(700);
                Console.WriteLine("El nuevo kilometraje es: " + carro1.Kilometraje + "km");
            }
            
            
        }
    }
}

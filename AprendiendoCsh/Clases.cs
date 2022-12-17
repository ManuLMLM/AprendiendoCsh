using System;
using System.Transactions;
using AprendiendoCsh.Interfaces;
using AprendiendoCsh.Objetos;
using MySql.Data.MySqlClient;

namespace AprendiendoCsh
{
    internal class Clases
    {
        static void Main(string[] arg)
        {
            Persona persona1 = new Persona("Luis", "López", "Morales", 23);
            Carro carro1 = new Carro("Rojo",1200,persona1.Nombre,persona1.ApellidoP,
                persona1.ApellidoM,persona1.Edad);
            Persona persona2 = new Persona("César","López","Morales",27);
            Moto moto1 = new Moto("Azúl",800,persona2.Nombre,persona2.ApellidoP,
                persona2.ApellidoM,persona2.Edad);
            ConexionMySQL consultapersonas = new ConexionMySQL();
            var listapersonas = consultapersonas.Get();
            foreach (var item in listapersonas)
            {
                Console.WriteLine(item.Nombre+" "+item.ApellidoP);
            }
            persona1.EdadConducir(persona1.Edad);
            if (persona1.Permiso == true)
            {
                EstandarVehiculoAprobado(carro1);
                Console.WriteLine("El nuevo kilometraje es: " + carro1.Kilometraje + "km");
            }
            persona2.EdadConducir(persona2.Edad);
            if (persona2.Permiso == true)
            {
                EstandarVehiculoAprobado(moto1);
                Console.WriteLine("El nuevo kilometraje es: "+moto1.Kilometraje+"km");
            }
        }
        static void EstandarVehiculoAprobado(IEstandarVehiculo Persona)
        {
            Persona.Usar(700);
        }
    }
}

using System;
using System.Data.SqlClient;
using System.Transactions;
using AprendiendoCsh.Interfaces;
using AprendiendoCsh.Objetos;

namespace AprendiendoCsh
{
    internal class Clases
    {
        static void Main(string[] arg)
        {
            //Objetos
            Persona persona1 = new Persona("Luis", "López", "Morales", 23);
            Carro carro1 = new Carro("Rojo",1200,persona1.Nombre,persona1.ApellidoP,
                persona1.ApellidoM,persona1.Edad);
            Persona persona2 = new Persona("César","López","Morales",17);
            Moto moto1 = new Moto("Azúl",800,persona2.Nombre,persona2.ApellidoP,
                persona2.ApellidoM,persona2.Edad);

            //Insertar persona
            {/*
                ConexionSqlserver agregarp = new ConexionSqlserver();
                Persona personaagregada = new Persona("Ulises Arturo", "Molina", "Lugo", 29);
                agregarp.InsertarPersona(personaagregada);*/
            }
            //Editar persona
            {/*
                ConexionSqlserver editarp = new ConexionSqlserver();
                Persona personaeditada = new Persona("Ulises Arturito", "Molina", "Lugo", 90);
                editarp.EditarPersona(personaeditada,3);*/
            }
            //Eliminar persona
            {/*
                ConexionSqlserver eliminarp = new ConexionSqlserver();
                eliminarp.EliminarPersona(3);*/
            }
            //impresiones de consultas
            ConexionSqlserver consultalistapersonas = new ConexionSqlserver();
            var listapersonas = consultalistapersonas.Get();
            foreach (var item in listapersonas)
            {
                Console.WriteLine(item.Nombre + " " + item.ApellidoP);
                
            }
            var consultarpersonas = consultalistapersonas.Get1(2);
            Console.WriteLine(consultarpersonas.Nombre + " " + consultarpersonas.ApellidoP);
            //Impresiones de objetos usando funciones
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
        //Aplicación de una interfaz
        static void EstandarVehiculoAprobado(IEstandarVehiculo Persona)
        {
            Persona.Usar(700);
        }
    }
}

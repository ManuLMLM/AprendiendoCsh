using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Threading.Tasks;
using System.Net;
using AprendiendoCsh.Objetos;
using System.Linq;

namespace AprendiendoCsh
{
    internal class ServiciosMain
    {
        static async Task Main(string[] arg)// se one async Task para trabajar con hilos
        {
            Comida comida1 = new Comida("Volobanes", 50, 2);

            //Serialización de datos del objeto a formato Json
            //string JsonComida1 = JsonSerializer.Serialize(comida1);
            //Creación de un archivo
            //File.WriteAllText("Comida1.txt", JsonComida1);
            //Extracción del contenido del archivo a una variable
            string ExtraerComida = File.ReadAllText("Comida1.txt");
            //Deserialización de un formato Json
            Comida ComidaExtraida = JsonSerializer.Deserialize<Comida>(ExtraerComida);

            string link = "https://jsonplaceholder.typicode.com/posts";
            var cliente = new HttpClient();

            //var Respuesta = cliente.GetAsync(link);//Se hace un proceso de solicitud a servidor
            //await Respuesta;//Obliga que se espere aquí hasta que ese proceso se complete

            var HttpRespuesta = await cliente.GetAsync(link);//Imponer espera hasta terminar proceso
            if (HttpRespuesta.IsSuccessStatusCode)//Que si el proceso fue exitoso
            {
                var contenido = await HttpRespuesta.Content.ReadAsStringAsync();//Contenido de lo solicitado al servidor
                List<Objetos.Post> Posts =
                    JsonSerializer.Deserialize<List<Objetos.Post>>(contenido);
            }
            Post post = new Post(){userId = 12, title = "Hola Hola", body = "Cuerpo"};
            var data = JsonSerializer.Serialize<Post>(post);
            HttpContent contenido1 = new StringContent(data,System.Text.Encoding.UTF8, "application/json");
            var respuesta1 = await cliente.PostAsync(link,contenido1);
            if (respuesta1.IsSuccessStatusCode)
            {
                var resultado = await respuesta1.Content.ReadAsStringAsync();
                var resultado2 = JsonSerializer.Deserialize<Post>(resultado);
            }
            Comida comida3 = new Comida()
            { Nombre ="Tacos de carnitas", Precio=35, Cantidad=3 };
            Objetos.EnviarRespuesta<Comida> ObjetoEnviar = new Objetos.EnviarRespuesta<Comida>();
            var mandarcomida = await ObjetoEnviar.Send(comida3);

            List<int> lista1 = new List<int>() { 1,2,0,9,8,7,4,5,6,15,76,44,19,833};

            var numero = lista1.Where(d => d ==19).FirstOrDefault();//Consulta para Buscar x valor en la lista
            var numordenados = lista1.OrderBy(d => d);//Consulta para Ordenar los valores
            var numsumatoria = lista1.Sum(d => d);//Consulta que suma los valores de la lista
            var numpromedio = lista1.Average(d => d);//Consulta para promedio
            foreach (var item in numordenados)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(numero);
            Console.WriteLine(numsumatoria);
            Console.WriteLine(numpromedio);
            List<Comida> comidas = new List<Comida>()
            {
                new Comida(){id=1,Nombre="Tamales",Precio=15,Cantidad=1},
                new Comida(){id=3,Nombre="Torta Sencilla",Precio=25,Cantidad=1},
                new Comida(){id=5,Nombre="Sandwich",Precio=40,Cantidad=4},
                new Comida(){id=6,Nombre="Sopes",Precio=30,Cantidad=3},
                new Comida(){id=9,Nombre="Gorditas",Precio=30,Cantidad=3}
            };
            //Consulta para ordenar una lista de Objetos
            var ordenarlistacomida = from d in comidas where d.Precio==30 && d.Cantidad==3 
                                     orderby d.Precio select d;
            foreach (var item in ordenarlistacomida)
            {
                Console.WriteLine(item.id+".- " + " Comida: " + item.Nombre + ". Precio: " + item.Precio
                    +". Cantidad: "+item.Cantidad);
            }
            List<Local> locales = new List<Local>()//Lista de locales con sus listas de comidas
            {
                new Local("Fondita María")
                {
                    Comidas = new List<Comida>()
                    {
                        new Comida(){id=1, Nombre="Torta Simple",Precio=25,Cantidad=1},
                        new Comida(){id = 2, Nombre = "Torta Triple", Precio = 40, Cantidad = 1},
                        new Comida(){id = 3, Nombre = "Torta Cubana", Precio = 60, Cantidad = 1},
                        new Comida(){id=4,Nombre="Hamburguesa", Precio=35, Cantidad=1},
                        new Comida(){id=5,Nombre="Sandwich",Precio=45,Cantidad=3},
                        new Comida(){id=6,Nombre="Sopes",Precio=30,Cantidad=3}
                    }
                },
                new Local("Doña pelos")
                {
                    Comidas=new List<Comida>()
                    {
                        new Comida(){id=1,Nombre="Sopes",Precio=30,Cantidad=3},
                        new Comida(){id=2,Nombre="Gorditas",Precio=15,Cantidad=1},
                        new Comida(){id=3,Nombre="Tacos dorados",Precio=30,Cantidad=5},
                        new Comida(){id=4,Nombre="Tostadas",Precio=30,Cantidad=4}
                    }
                },
                new Local("Tacazos")
                {
                    Comidas= new List<Comida>()
                    {
                        new Comida(){id=1,Nombre="Tacos de Cecina",Precio=40,Cantidad=5},
                        new Comida(){id=2,Nombre="Tacos de Barbacoa",Precio=45,Cantidad=5},
                        new Comida(){id=3,Nombre="Tacos de Tripa", Precio=40,Cantidad=4}
                    }
                }
            };
            var local = (from d in locales
                         where d.Comidas.Where(c => c.Nombre == "Sopes").Count() > 0
                         select d
                         ).ToList();
        }
    }
}

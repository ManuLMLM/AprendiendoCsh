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
            //Leer un archivo
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
            Post post = new Post()
            {
                userId = 12,
                title = "Hola Hola",
                body = "Cuerpo"
            };
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
        }
    }
}

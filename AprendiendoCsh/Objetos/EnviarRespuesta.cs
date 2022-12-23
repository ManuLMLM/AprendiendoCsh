using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AprendiendoCsh.Objetos
{
    //Es un Generic. va a recibir una clase
    public class EnviarRespuesta<T>// Where T: Interface //así sería para condicionarle una interface
    {
        private HttpClient cliente = new HttpClient();
        public async Task<T> Send(T modelo)
        {
            string link = "https://jsonplaceholder.typicode.com/posts/";
            var data = JsonSerializer.Serialize<T>(modelo);
            HttpContent contenido1 = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var respuesta1 = await cliente.PostAsync(link, contenido1);

            if (respuesta1.IsSuccessStatusCode)
            {
                var resultado = await respuesta1.Content.ReadAsStringAsync();

                var resultado1 = JsonSerializer.Deserialize<T>(resultado);
                return resultado1;
            }
            return default(T);
        }
    }
}

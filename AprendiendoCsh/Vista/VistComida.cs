using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendiendoCsh.Vista
{
    public class VistComida
    {
        public string Nombre { get; set; }
        public List<Comida> ComidasResu { get; set; }
        public VistComida(string Nombre)
        {
            this.Nombre = Nombre;
        }
    }
}

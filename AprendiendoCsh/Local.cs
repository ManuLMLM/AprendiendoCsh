using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendiendoCsh
{
    public class Local
    {
        public string Nombre { get; set; }
        public List<Comida> Comidas{ get; set; }
        public Local(string Nombre)
        {
            this.Nombre = Nombre;
        }
    }
}

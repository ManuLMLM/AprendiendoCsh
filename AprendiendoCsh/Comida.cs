using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendiendoCsh
{
    class Comida
    {
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public double Cantidad { get; set; }
        public int id { get; set; }
        public Comida() { }
        public Comida(string nombre,int precio,double cantidad) 
        {
            this.Nombre= nombre;
            this.Cantidad= cantidad;
            this.Precio= precio;
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendiendoCsh
{
    public class Comida
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public int id { get; set; }
        public Comida() { }
        public Comida(string Nombre) { this.Nombre = Nombre; }
        public Comida(string nombre,double precio,int cantidad) 
        {
            this.Nombre= nombre;
            this.Cantidad= cantidad;
            this.Precio= precio;
        }
        public Comida(string nombre, double precio)
        {
            this.Nombre = nombre;
            this.Precio = precio;
        }
    }
}

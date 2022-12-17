using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendiendoCsh.Interfaces
{
    interface IEstandarVehiculo
    {
        public string Placas { get; set; }
        public double Kilometraje { get; set; }
        public string TipoEoA { get; set; }
        public int Año { get; set; }
        public void Usar(double recorrido);
    }
}

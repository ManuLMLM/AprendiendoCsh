using System;
using System.Transactions;

namespace AprendiendoCsh
{
    class Variables
    {
        static void Main(String[] arg)
        {
            byte tipobyte = 255;//entero con valor hasta de 255, solo números positivos
            sbyte tipobytenega = -128;//entero con valores entre -128 a 127, números positivos y negativos
            short nshort = 12345;//entero de 5 cifras,
            ushort nshortnega = 123;//solo valores positivos
            int numeroint = 1234567890;//entero con valor de 10 cifras, números positivos y negativos
            uint numerointnega = 1234567890;//solo números positivos
            long numerobig = -123;//entero con la mayor longitud, números positivos y negativos
            ulong numerobigposi = 123;//solo números positivos

            float nflotante = 1.3f;//entero con decimal, debe llevar la f al final del valor
            double ndouble = 3213.4d;//entero con decimal, d al final
            decimal ndecimal = 12312.21335m;//entero con decimal de mayor longitud, m al final

            char caracter = 'L';//solo una letra
            string palabra = "Luis";//texto
            char? sinvalor = null;//variable sin valor, aplica para todas las demás

            bool si = true,no = false;//´ verdadero y falso

            var nombres = "Luis Manuel";//var es para asignar variables de forma flexible
            var nchar = 'a';
            var numeros = 123;
            var numeros1 = 1.5;

            DateTime fecha = DateTime.Now;//fecha

        }
    }
}

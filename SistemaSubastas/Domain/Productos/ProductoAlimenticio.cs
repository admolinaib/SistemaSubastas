using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSubastas.Domain.Productos
{
    public class ProductoAlimenticio : Producto
    {
        public bool CercaCaducidad { get; set; }

        public ProductoAlimenticio(string nombre, decimal precio, string desc, bool cercaCad)
            : base(nombre, precio, desc)
        {
            CercaCaducidad = cercaCad;
        }

        public override decimal CalcularPrecioFinal(decimal precioActual)
        {
            return CercaCaducidad ? precioActual * 0.85m : precioActual;
        }
    }
}

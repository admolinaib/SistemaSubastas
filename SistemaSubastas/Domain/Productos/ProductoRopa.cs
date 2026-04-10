using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSubastas.Domain.Productos
{
    public class ProductoRopa : Producto
    {
        public bool EnLiquidacion { get; set; }

        public ProductoRopa(string nombre, decimal precio, string desc, bool liquidacion)
            : base(nombre, precio, desc)
        {
            EnLiquidacion = liquidacion;
        }

        public override decimal CalcularPrecioFinal(decimal precioActual)
        {
            return EnLiquidacion ? precioActual * 0.80m : precioActual;
        }
    }
}

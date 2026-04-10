using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSubastas.Domain.Productos
{
    public class ProductoElectronico : Producto
    {
        public ProductoElectronico(string nombre, decimal precio, string desc)
            : base(nombre, precio, desc) { }

        public override decimal CalcularPrecioFinal(decimal precioActual)
        {
            return precioActual * 1.10m;
        }
    }
}

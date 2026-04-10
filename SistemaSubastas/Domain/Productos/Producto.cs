using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSubastas.Domain.Productos
{
    public abstract class Producto
    {
        public string Nombre { get; set; }
        public decimal PrecioInicial { get; set; }
        public string Descripcion { get; set; }

        protected Producto(string nombre, decimal precioInicial, string descripcion)
        {
            Nombre = nombre;
            PrecioInicial = precioInicial;
            Descripcion = descripcion;
        }

        public abstract decimal CalcularPrecioFinal(decimal precioActual);
    }
}

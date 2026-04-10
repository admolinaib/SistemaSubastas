using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSubastas.Domain.Productos
{
    public abstract class ProductoFactory
    {
        public abstract Producto CrearProducto(string nombre, decimal precio, string descripcion);
    }
}

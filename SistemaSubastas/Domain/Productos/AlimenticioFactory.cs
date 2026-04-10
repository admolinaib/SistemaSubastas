using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSubastas.Domain.Productos
{
    public class AlimenticioFactory : ProductoFactory
    {
        public override Producto CrearProducto(string nombre, decimal precio, string descripcion)
        {
            return new ProductoAlimenticio(nombre, precio, descripcion, true);
        }
    }
}

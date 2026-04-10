using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSubastas.Domain.Productos
{
    public class ElectronicoFactory : ProductoFactory
    {
        public override Producto CrearProducto(string nombre, decimal precio, string descripcion)
        {
            return new ProductoElectronico(nombre, precio, descripcion);
        }
    }
}

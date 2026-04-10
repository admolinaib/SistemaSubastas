using SistemaSubastas.Domain.Productos;
using SistemaSubastas.Domain.Subastas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSubastas.App
{
    public class SubastaService
    {
        public List<Subasta> Subastas { get; private set; } = new();

        public Subasta CrearSubasta(string tipoProducto, string tipoSubasta)
        {
            ProductoFactory fabrica = tipoProducto switch
            {
                "Electrónico" => new ElectronicoFactory(),
                "Alimenticio" => new AlimenticioFactory(),
                "Ropa" => new RopaFactory(),
                _ => throw new Exception("Tipo inválido")
            };

            var producto = fabrica.CrearProducto("Producto Demo", 100, "Demo");

            IStrategySubasta estrategia = tipoSubasta switch
            {
                "Ascendente" => new SubastaAscendente(),
                "Descendente" => new SubastaDescendente(),
                "Cerrada" => new SubastaCerrada(),
                _ => throw new Exception("Tipo inválido")
            };

            var subasta = new Subasta(producto, estrategia);

            Subastas.Add(subasta);
            return subasta;
        }
        public void CargarDatosDemo()
        {
            CrearSubastaDemo("Laptop Gamer ASUS", 1500, "Electrónico", "Ascendente");
            CrearSubastaDemo("Smart TV Samsung 55\"", 900, "Electrónico", "Cerrada");
            CrearSubastaDemo("iPhone 13", 1200, "Electrónico", "Descendente");

            CrearSubastaDemo("Caja de Manzanas", 50, "Alimenticio", "Ascendente");
            CrearSubastaDemo("Lote de Yogures", 30, "Alimenticio", "Descendente");
            CrearSubastaDemo("Queso Importado", 80, "Alimenticio", "Cerrada");

            CrearSubastaDemo("Chaqueta Nike", 120, "Ropa", "Ascendente");
            CrearSubastaDemo("Zapatillas Adidas", 95, "Ropa", "Descendente");
            CrearSubastaDemo("Camiseta Polo", 60, "Ropa", "Cerrada");
        }

        private Subasta CrearSubastaDemo(string nombre, decimal precio, string tipoProducto, string tipoSubasta)
        {
            ProductoFactory fabrica;

            switch (tipoProducto)
            {
                case "Electrónico":
                    fabrica = new ElectronicoFactory();
                    break;
                case "Alimenticio":
                    fabrica = new AlimenticioFactory();
                    break;
                case "Ropa":
                    fabrica = new RopaFactory();
                    break;
                default:
                    throw new Exception("Tipo inválido");
            }

            var producto = fabrica.CrearProducto(nombre, precio, "Producto demo");

            IStrategySubasta estrategia;

            switch (tipoSubasta)
            {
                case "Ascendente":
                    estrategia = new SubastaAscendente();
                    break;
                case "Descendente":
                    estrategia = new SubastaDescendente();
                    break;
                case "Cerrada":
                    estrategia = new SubastaCerrada();
                    break;
                default:
                    throw new Exception("Tipo inválido");
            }

            var subasta = new Subasta(producto, estrategia);
            Subastas.Add(subasta);

            return subasta;
        }
    }
}

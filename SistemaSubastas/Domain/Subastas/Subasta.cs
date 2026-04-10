using SistemaSubastas.Domain.Productos;
using SistemaSubastas.Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSubastas.Domain.Subastas
{
    public class Subasta
    {
        public Producto Producto { get; set; }
        public decimal PrecioActual { get; set; }
        public Usuario? Ganador { get; set; }
        public bool Activa { get; private set; } = true;
        public DateTime UltimaOferta { get; set; }
        public int TiempoLimiteSegundos { get; set; } = 30;

        public string TipoSubasta => _estrategia.TipoSubasta;

        private readonly IStrategySubasta _estrategia;

        public Subasta(Producto producto, IStrategySubasta estrategia)
        {
            Producto = producto;
            PrecioActual = producto.PrecioInicial;
            _estrategia = estrategia;
            UltimaOferta = DateTime.Now;
        }

        public void RecibirOferta(Usuario usuario, decimal monto)
        {
            if (!Activa)
                throw new Exception("La subasta ya fue cerrada.");

            _estrategia.ProcesarOferta(this, usuario, monto);
            UltimaOferta = DateTime.Now;
        }

        public void Cerrar()
        {
            Activa = false;
        }

        public void Actualizar()
        {
            if (!Activa) return;
            _estrategia.Actualizar(this);
        }
    }
}

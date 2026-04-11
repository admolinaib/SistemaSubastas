using SistemaSubastas.Domain.Productos;
using SistemaSubastas.Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaSubastas.Domain.Subastas
{
    public class Subasta
    {
        public Producto Producto { get; set; }
        public Guid Id { get; } = Guid.NewGuid();
        public decimal PrecioActual { get; set; }
        public Usuario? Ganador { get; set; }
        public bool Activa { get; private set; } = true;
        public bool Iniciada { get; private set; } = false;
        public DateTime UltimaOferta { get; set; }
        public int TiempoLimiteSegundos { get; set; } = 10;

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
        public void Iniciar()
        {
            if (Iniciada || !Activa) return;
            Iniciada = true;
            UltimaOferta = DateTime.Now;
        }
        public void Cerrar()
        {
            if (!Activa) return;
            Activa = false;

            string mensaje = Ganador != null
                ? $"✅ Subasta cerrada.\nGanador: {Ganador.Nombre}\nPrecio final: ${Producto.CalcularPrecioFinal(PrecioActual):N2}"
                : "🔒 Subasta cerrada sin ganador.";

            MessageBox.Show(mensaje, "Subasta finalizada",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Actualizar()
        {
            if (!Activa || !Iniciada) return;
            _estrategia.Actualizar(this);
        }
    }
}

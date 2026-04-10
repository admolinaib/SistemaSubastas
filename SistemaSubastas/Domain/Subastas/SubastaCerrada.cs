using System;
using SistemaSubastas.Domain.Usuarios;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSubastas.Domain.Subastas
{
    public class SubastaCerrada : IStrategySubasta
    {
        public string TipoSubasta => "Cerrada";

        private readonly List<(Usuario usuario, decimal monto)> _ofertas = new();

        public void ProcesarOferta(Subasta subasta, Usuario usuario, decimal monto)
        {
            if (_ofertas.Any(o => o.usuario.Nombre == usuario.Nombre))
                throw new Exception("Ya realizaste una oferta. En subasta cerrada no se puede modificar.");

            _ofertas.Add((usuario, monto));
        }
        public void Actualizar(Subasta subasta)
        {
            var segundosTranscurridos = (DateTime.Now - subasta.UltimaOferta).TotalSeconds;
            if (segundosTranscurridos >= subasta.TiempoLimiteSegundos)
            {
                DeterminarGanador(subasta);
                subasta.Cerrar();
            }
        }

        private void DeterminarGanador(Subasta subasta)
        {
            if (!_ofertas.Any()) return;

            var mejor = _ofertas.OrderByDescending(o => o.monto).First();
            subasta.Ganador = mejor.usuario;
            subasta.PrecioActual = mejor.monto;
        }
    }

}

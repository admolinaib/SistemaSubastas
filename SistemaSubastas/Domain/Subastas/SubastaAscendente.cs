using SistemaSubastas.Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSubastas.Domain.Subastas
{
    public class SubastaAscendente : IStrategySubasta
    {
        public string TipoSubasta => "Ascendente";

        public void ProcesarOferta(Subasta subasta, Usuario usuario, decimal monto)
        {
            if (monto <= subasta.PrecioActual)
                throw new Exception("La oferta debe ser mayor a la actual.");

            subasta.PrecioActual = monto;
            subasta.Ganador = usuario;
        }

        public void Actualizar(Subasta subasta)
        {
            var segundosTranscurridos = (DateTime.Now - subasta.UltimaOferta).TotalSeconds;
            if (segundosTranscurridos >= subasta.TiempoLimiteSegundos)
                subasta.Cerrar();
        }
    }
}

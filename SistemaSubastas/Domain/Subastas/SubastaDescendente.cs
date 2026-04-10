using System;
using SistemaSubastas.Domain.Usuarios;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSubastas.Domain.Subastas
{
    public class SubastaDescendente : IStrategySubasta
    {
        public string TipoSubasta => "Descendente";

        private const decimal DecrementoPorTick = 10m;

        public void ProcesarOferta(Subasta subasta, Usuario usuario, decimal monto)
        {
            subasta.Ganador = usuario;
            subasta.Cerrar();
        }

        public void Actualizar(Subasta subasta)
        {
            if (subasta.PrecioActual > DecrementoPorTick)
                subasta.PrecioActual -= DecrementoPorTick;
            else
                subasta.Cerrar(); 
        }
    }
}

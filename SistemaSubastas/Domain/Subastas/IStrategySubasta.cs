using SistemaSubastas.Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSubastas.Domain.Subastas
{
    public interface IStrategySubasta
    {
        string TipoSubasta { get; }
        void ProcesarOferta(Subasta subasta, Usuario usuario, decimal monto);
        void Actualizar(Subasta subasta);
    }
}

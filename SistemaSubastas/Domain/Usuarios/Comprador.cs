using SistemaSubastas.Domain.Subastas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSubastas.Domain.Usuarios
{
    public class Comprador : Usuario
    {
        public Comprador(string nombre) : base(nombre) { }

        public override void RealizarOferta(Subasta subasta, decimal monto)
        {
            subasta.RecibirOferta(this, monto);
        }
    }
}

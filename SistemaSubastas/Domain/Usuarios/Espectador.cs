using SistemaSubastas.Domain.Subastas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSubastas.Domain.Usuarios
{
    public class Espectador : Usuario
    {
        public Espectador(string nombre) : base(nombre) { }

        public override void RealizarOferta(Subasta subasta, decimal monto)
        {
            throw new InvalidOperationException("Un espectador no puede ofertar. ");
        }
    }
}

using SistemaSubastas.Domain.Subastas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSubastas.Domain.Usuarios
{
    public abstract class Usuario
    {
        public string Nombre { get; set; }

        protected Usuario(string nombre)
        {
            Nombre = nombre;
        }

        public abstract void RealizarOferta(Subasta subasta, decimal monto);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Models;

namespace Biblioteca.Models
{
    public class Usuario
    {
        public string usuario { get; set; }

        public string contrasenia { get; set; }
        public string nombre { get; set; }

        public string apellido { get; set; }
        public string dni { get; set; }
        public string ConfirmarClave { get; set; }

    }
}

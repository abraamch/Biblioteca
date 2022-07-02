using Biblioteca.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class ManageUsersViewModel
    {
        public BibliotecaUser[] Administrators { get; set; }

        public BibliotecaUser[] Usuarios { get; set; }

    }
}

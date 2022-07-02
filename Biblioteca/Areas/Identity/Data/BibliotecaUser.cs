using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Models;
using Microsoft.AspNetCore.Identity;

namespace Biblioteca.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the BibliotecaUser class
    public class BibliotecaUser : IdentityUser
    {
        public int DNI { get; set; }
        public string NombreApellido { get; set; }

        

       
        
  
    }
}

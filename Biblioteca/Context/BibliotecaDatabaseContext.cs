using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Models;

namespace Biblioteca.Context
{
    public class BibliotecaDatabaseContext : DbContext
    {
        public
       BibliotecaDatabaseContext(DbContextOptions<BibliotecaDatabaseContext> options)
       : base(options)
        {
        }
        public DbSet<Libro> Libros { get; set; }
      
    }
}


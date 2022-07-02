using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Areas.Identity.Data;
using Biblioteca.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Data
{
    public class BibliotecaContext : IdentityDbContext<BibliotecaUser>
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
           
                      
        }
    }

    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<BibliotecaUser>
    {
        public void Configure(EntityTypeBuilder<BibliotecaUser> builder)
        {
            builder.Property(t => t.DNI).HasMaxLength(9);
            builder.Property(t => t.NombreApellido);
            




        }
    }
  

}

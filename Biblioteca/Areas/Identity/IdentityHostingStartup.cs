using System;
using Biblioteca.Areas.Identity.Data;
using Biblioteca.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Biblioteca.Areas.Identity.IdentityHostingStartup))]
namespace Biblioteca.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<BibliotecaContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("BibliotecaContextConnection")));

                services.AddDefaultIdentity<BibliotecaUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<BibliotecaContext>();
            });
        }
    }
}
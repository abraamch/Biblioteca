using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Areas.Identity.Data;

namespace Biblioteca.Controllers
{
    [Authorize]
    public class ManageUsersController : Controller
    {
        private readonly UserManager<BibliotecaUser> _userManager;

        public ManageUsersController(
            UserManager<BibliotecaUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            

            var usuarios = await _userManager.Users
                .ToArrayAsync();

            var model = new ManageUsersViewModel
            {
                
                Usuarios = usuarios
            };

            return View(model);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Context;
using Biblioteca.Models;
using Microsoft.AspNetCore.Authorization;
using Biblioteca.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Biblioteca.Data;

namespace Biblioteca.Controllers
{
   
    public class LibroController : Controller
    {
        private readonly UserManager<BibliotecaUser> _userManager;
        private readonly BibliotecaDatabaseContext _context;
        private readonly BibliotecaContext _context1;

        public LibroController(BibliotecaDatabaseContext context, BibliotecaContext context1, UserManager<BibliotecaUser> userManager)
        {
            _context = context;
            _context1 = context1;
            _userManager = userManager;
        }

        // GET: Libro
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Libros.ToListAsync());
        }

        // GET: Libro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libro/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Libro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CantPaginas,Nombre,Tapa,Autor,Genero")] Libro libro)
        {
            libro.VencimientoEntrega = DateTime.Today;
            if (ModelState.IsValid)
            {
                _context.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
        }

        // GET: Libro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        // POST: Libro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CantPaginas,Nombre,Tapa,Autor,Genero")] Libro libro)
        {

            if (id != libro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
        }

        // GET: Libro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }                                                                                                                                                                                                                                                                                                       

        // POST: Libro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
            return _context.Libros.Any(e => e.Id == id);
        }
       
        [HttpPost,  ActionName("ReservarLibro")]
        public async Task<IActionResult> ReservarLibroConfirmed(Libro libro)
        {
            int id = libro.Id;
            var usuario = await _userManager.GetUserAsync(User);
            libro = await _context.FindAsync<Libro>(id);
            await _context1.SaveChangesAsync();
            LibroUsuario libroUser = new LibroUsuario();
            libroUser.MailUsuario = usuario.Email;
            libroUser.PaginasLibro = libro.CantPaginas;
            libroUser.NombreLibro = libro.Nombre;
            libroUser.VencimientoLibro = libro.VencimientoEntrega.AddDays(15);
            libroUser.GeneroLibro = libro.Genero;
            libroUser.AutorLibro = libro.Autor;
            libroUser.TapaLibro = libro.Tapa;
            _context.LibrosDeUsuarios.Add(libroUser);
            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index","LibroUsuarios");
        }
        public async Task<IActionResult> ReservarLibro(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }


    }
}

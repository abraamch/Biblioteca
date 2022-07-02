using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Context;
using Biblioteca.Models;
using Microsoft.AspNetCore.Identity;
using Biblioteca.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

namespace Biblioteca.Controllers
{
    public class LibroUsuariosController : Controller
    {
        private readonly BibliotecaDatabaseContext _context;
        private readonly UserManager<BibliotecaUser> _userManager;
        public LibroUsuariosController(BibliotecaDatabaseContext context, UserManager<BibliotecaUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: LibroUsuarios
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.LibrosDeUsuarios.ToListAsync());
        }

        // GET: LibroUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libroUsuario = await _context.LibrosDeUsuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libroUsuario == null)
            {
                return NotFound();
            }

            return View(libroUsuario);
        }

        // GET: LibroUsuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LibroUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MailUsuario,PaginasLibro,NombreLibro,GeneroLibro,VencimientoLibro")] LibroUsuario libroUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libroUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(libroUsuario);
        }

        // GET: LibroUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libroUsuario = await _context.LibrosDeUsuarios.FindAsync(id);
            if (libroUsuario == null)
            {
                return NotFound();
            }
            return View(libroUsuario);
        }

        // POST: LibroUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MailUsuario,PaginasLibro,NombreLibro,GeneroLibro,VencimientoLibro")] LibroUsuario libroUsuario)
        {
            if (id != libroUsuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libroUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroUsuarioExists(libroUsuario.Id))
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
            return View(libroUsuario);
        }

        // GET: LibroUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libroUsuario = await _context.LibrosDeUsuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libroUsuario == null)
            {
                return NotFound();
            }

            return View(libroUsuario);
        }

        // POST: LibroUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libroUsuario = await _context.LibrosDeUsuarios.FindAsync(id);
            _context.LibrosDeUsuarios.Remove(libroUsuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroUsuarioExists(int id)
        {
            return _context.LibrosDeUsuarios.Any(e => e.Id == id);
        }
        [HttpPost, ActionName("DevolverLibro")]
        public async Task<IActionResult> DevolverLibroConfirmed(LibroUsuario libroUsuario)
        {
            int id = libroUsuario.Id;
            
            libroUsuario = await _context.FindAsync<LibroUsuario>(id);
            
            Libro libro = new Libro();
            libro.CantPaginas = libroUsuario.PaginasLibro;
            libro.Nombre = libroUsuario.NombreLibro;
            libro.Tapa = libroUsuario.TapaLibro;
            libro.Autor = libroUsuario.AutorLibro;
            libro.Genero = libroUsuario.GeneroLibro;
            libro.VencimientoEntrega = libroUsuario.VencimientoLibro;
            _context.Libros.Add(libro);
            _context.LibrosDeUsuarios.Remove(libroUsuario);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "LibroUsuarios");
        }

        public async Task<IActionResult> DevolverLibro(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.LibrosDeUsuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }
    }
}

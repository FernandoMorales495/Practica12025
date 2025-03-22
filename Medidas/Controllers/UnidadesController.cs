using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Medidas.Models;

namespace Medidas.Controllers
{
    public class UnidadesController : Controller
    {
        private readonly MedidasContext _context;

        public UnidadesController(MedidasContext context)
        {
            _context = context;
        }

        // GET: Unidades
        public async Task<IActionResult> Index()
        {
            return View(await _context.UnidadesDeMedida.ToListAsync());
        }

        // GET: Unidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadesDeMedidum = await _context.UnidadesDeMedida
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unidadesDeMedidum == null)
            {
                return NotFound();
            }

            return View(unidadesDeMedidum);
        }

        // GET: Unidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Unidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Abreviatura")] UnidadesDeMedidum unidadesDeMedidum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidadesDeMedidum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unidadesDeMedidum);
        }

        // GET: Unidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadesDeMedidum = await _context.UnidadesDeMedida.FindAsync(id);
            if (unidadesDeMedidum == null)
            {
                return NotFound();
            }
            return View(unidadesDeMedidum);
        }

        // POST: Unidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Abreviatura")] UnidadesDeMedidum unidadesDeMedidum)
        {
            if (id != unidadesDeMedidum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidadesDeMedidum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadesDeMedidumExists(unidadesDeMedidum.Id))
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
            return View(unidadesDeMedidum);
        }

        // GET: Unidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadesDeMedidum = await _context.UnidadesDeMedida
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unidadesDeMedidum == null)
            {
                return NotFound();
            }

            return View(unidadesDeMedidum);
        }

        // POST: Unidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unidadesDeMedidum = await _context.UnidadesDeMedida.FindAsync(id);
            if (unidadesDeMedidum != null)
            {
                _context.UnidadesDeMedida.Remove(unidadesDeMedidum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadesDeMedidumExists(int id)
        {
            return _context.UnidadesDeMedida.Any(e => e.Id == id);
        }
    }
}

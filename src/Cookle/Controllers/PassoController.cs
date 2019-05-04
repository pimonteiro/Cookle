using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cookle.Models;

namespace Cookle.Controllers
{
    public class PassoController : Controller
    {
        private readonly CookleContext _context;

        public PassoController(CookleContext context)
        {
            _context = context;
        }

        // GET: Passo
        public async Task<IActionResult> Index()
        {
            var cookleContext = _context.Passo.Include(p => p.Ingredientes);
            return View(await cookleContext.ToListAsync());
        }

        // GET: Passo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passo = await _context.Passo
                .Include(p => p.Ingredientes)
                .FirstOrDefaultAsync(m => m.Ingrediente == id);
            if (passo == null)
            {
                return NotFound();
            }

            return View(passo);
        }

        // GET: Passo/Create
        public IActionResult Create()
        {
            ViewData["Ingrediente"] = new SelectList(_context.Ingrediente, "Id", "Nome");
            return View();
        }

        // POST: Passo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Numero,Ingrediente,SubReceita,Descricao")] Passo passo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Ingrediente"] = new SelectList(_context.Ingrediente, "Id", "Nome", passo.Ingrediente);
            return View(passo);
        }

        // GET: Passo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passo = await _context.Passo.FindAsync(id);
            if (passo == null)
            {
                return NotFound();
            }
            ViewData["Ingrediente"] = new SelectList(_context.Ingrediente, "Id", "Nome", passo.Ingrediente);
            return View(passo);
        }

        // POST: Passo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Numero,Ingrediente,SubReceita,Descricao")] Passo passo)
        {
            if (id != passo.Ingrediente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassoExists(passo.Ingrediente))
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
            ViewData["Ingrediente"] = new SelectList(_context.Ingrediente, "Id", "Nome", passo.Ingrediente);
            return View(passo);
        }

        // GET: Passo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passo = await _context.Passo
                .Include(p => p.Ingredientes)
                .FirstOrDefaultAsync(m => m.Ingrediente == id);
            if (passo == null)
            {
                return NotFound();
            }

            return View(passo);
        }

        // POST: Passo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var passo = await _context.Passo.FindAsync(id);
            _context.Passo.Remove(passo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassoExists(int id)
        {
            return _context.Passo.Any(e => e.Ingrediente == id);
        }
    }
}

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
    public class PreferenciaIngredienteController : Controller
    {
        private readonly CookleContext _context;

        public PreferenciaIngredienteController(CookleContext context)
        {
            _context = context;
        }

        // GET: PreferenciaIngrediente
        public async Task<IActionResult> Index()
        {
            var cookleContext = _context.PreferenciaIngrediente.Include(p => p.Ingredientes).Include(p => p.Users);
            return View(await cookleContext.ToListAsync());
        }

        // GET: PreferenciaIngrediente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preferenciaIngrediente = await _context.PreferenciaIngrediente
                .Include(p => p.Ingredientes)
                .Include(p => p.Users)
                .FirstOrDefaultAsync(m => m.User == id);
            if (preferenciaIngrediente == null)
            {
                return NotFound();
            }

            return View(preferenciaIngrediente);
        }

        // GET: PreferenciaIngrediente/Create
        public IActionResult Create()
        {
            ViewData["Ingrediente"] = new SelectList(_context.Ingrediente, "Id", "Nome");
            ViewData["User"] = new SelectList(_context.User, "Id", "Email");
            return View();
        }

        // POST: PreferenciaIngrediente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("User,Ingrediente,Tipo")] PreferenciaIngrediente preferenciaIngrediente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(preferenciaIngrediente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Ingrediente"] = new SelectList(_context.Ingrediente, "Id", "Nome", preferenciaIngrediente.Ingrediente);
            ViewData["User"] = new SelectList(_context.User, "Id", "Email", preferenciaIngrediente.User);
            return View(preferenciaIngrediente);
        }

        // GET: PreferenciaIngrediente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preferenciaIngrediente = await _context.PreferenciaIngrediente.FindAsync(id);
            if (preferenciaIngrediente == null)
            {
                return NotFound();
            }
            ViewData["Ingrediente"] = new SelectList(_context.Ingrediente, "Id", "Nome", preferenciaIngrediente.Ingrediente);
            ViewData["User"] = new SelectList(_context.User, "Id", "Email", preferenciaIngrediente.User);
            return View(preferenciaIngrediente);
        }

        // POST: PreferenciaIngrediente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("User,Ingrediente,Tipo")] PreferenciaIngrediente preferenciaIngrediente)
        {
            if (id != preferenciaIngrediente.User)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(preferenciaIngrediente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PreferenciaIngredienteExists(preferenciaIngrediente.User))
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
            ViewData["Ingrediente"] = new SelectList(_context.Ingrediente, "Id", "Nome", preferenciaIngrediente.Ingrediente);
            ViewData["User"] = new SelectList(_context.User, "Id", "Email", preferenciaIngrediente.User);
            return View(preferenciaIngrediente);
        }

        // GET: PreferenciaIngrediente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preferenciaIngrediente = await _context.PreferenciaIngrediente
                .Include(p => p.Ingredientes)
                .Include(p => p.Users)
                .FirstOrDefaultAsync(m => m.User == id);
            if (preferenciaIngrediente == null)
            {
                return NotFound();
            }

            return View(preferenciaIngrediente);
        }

        // POST: PreferenciaIngrediente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var preferenciaIngrediente = await _context.PreferenciaIngrediente.FindAsync(id);
            _context.PreferenciaIngrediente.Remove(preferenciaIngrediente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PreferenciaIngredienteExists(int id)
        {
            return _context.PreferenciaIngrediente.Any(e => e.User == id);
        }
    }
}

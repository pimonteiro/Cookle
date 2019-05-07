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
            var cookleContext = _context.PreferenciaIngrediente.Include(p => p.User);
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
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (preferenciaIngrediente == null)
            {
                return NotFound();
            }

            return View(preferenciaIngrediente);
        }

        // GET: PreferenciaIngrediente/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Email");
            return View();
        }

        // POST: PreferenciaIngrediente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,IngredienteId,Tipo")] PreferenciaIngrediente preferenciaIngrediente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(preferenciaIngrediente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Email", preferenciaIngrediente.UserId);
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
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Email", preferenciaIngrediente.UserId);
            return View(preferenciaIngrediente);
        }

        // POST: PreferenciaIngrediente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,IngredienteId,Tipo")] PreferenciaIngrediente preferenciaIngrediente)
        {
            if (id != preferenciaIngrediente.UserId)
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
                    if (!PreferenciaIngredienteExists(preferenciaIngrediente.UserId))
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
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Email", preferenciaIngrediente.UserId);
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
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
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
            return _context.PreferenciaIngrediente.Any(e => e.UserId == id);
        }
    }
}

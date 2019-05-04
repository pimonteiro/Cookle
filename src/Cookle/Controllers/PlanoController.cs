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
    public class PlanoController : Controller
    {
        private readonly CookleContext _context;

        public PlanoController(CookleContext context)
        {
            _context = context;
        }

        // GET: Plano
        public async Task<IActionResult> Index()
        {
            var cookleContext = _context.Plano.Include(p => p.Receitas).Include(p => p.Users);
            return View(await cookleContext.ToListAsync());
        }

        // GET: Plano/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plano = await _context.Plano
                .Include(p => p.Receitas)
                .Include(p => p.Users)
                .FirstOrDefaultAsync(m => m.User == id);
            if (plano == null)
            {
                return NotFound();
            }

            return View(plano);
        }

        // GET: Plano/Create
        public IActionResult Create()
        {
            ViewData["Receita"] = new SelectList(_context.Receita, "Id", "Descricao");
            ViewData["User"] = new SelectList(_context.User, "Id", "Email");
            return View();
        }

        // POST: Plano/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("User,Receita")] Plano plano)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plano);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Receita"] = new SelectList(_context.Receita, "Id", "Descricao", plano.Receita);
            ViewData["User"] = new SelectList(_context.User, "Id", "Email", plano.User);
            return View(plano);
        }

        // GET: Plano/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plano = await _context.Plano.FindAsync(id);
            if (plano == null)
            {
                return NotFound();
            }
            ViewData["Receita"] = new SelectList(_context.Receita, "Id", "Descricao", plano.Receita);
            ViewData["User"] = new SelectList(_context.User, "Id", "Email", plano.User);
            return View(plano);
        }

        // POST: Plano/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("User,Receita")] Plano plano)
        {
            if (id != plano.User)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plano);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanoExists(plano.User))
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
            ViewData["Receita"] = new SelectList(_context.Receita, "Id", "Descricao", plano.Receita);
            ViewData["User"] = new SelectList(_context.User, "Id", "Email", plano.User);
            return View(plano);
        }

        // GET: Plano/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plano = await _context.Plano
                .Include(p => p.Receitas)
                .Include(p => p.Users)
                .FirstOrDefaultAsync(m => m.User == id);
            if (plano == null)
            {
                return NotFound();
            }

            return View(plano);
        }

        // POST: Plano/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plano = await _context.Plano.FindAsync(id);
            _context.Plano.Remove(plano);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanoExists(int id)
        {
            return _context.Plano.Any(e => e.User == id);
        }
    }
}

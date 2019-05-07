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
    public class MoradaController : Controller
    {
        private readonly CookleContext _context;

        public MoradaController(CookleContext context)
        {
            _context = context;
        }

        // GET: Morada
        public async Task<IActionResult> Index()
        {
            var cookleContext = _context.Morada.Include(m => m.Pais);
            return View(await cookleContext.ToListAsync());
        }

        // GET: Morada/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var morada = await _context.Morada
                .Include(m => m.Pais)
                .FirstOrDefaultAsync(m => m.Rua == id);
            if (morada == null)
            {
                return NotFound();
            }

            return View(morada);
        }

        // GET: Morada/Create
        public IActionResult Create()
        {
            ViewData["PaisId"] = new SelectList(_context.Pais, "Id", "Name");
            return View();
        }

        // POST: Morada/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Rua,Cidade,CodigoPostal,PaisId")] Morada morada)
        {
            if (ModelState.IsValid)
            {
                _context.Add(morada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaisId"] = new SelectList(_context.Pais, "Id", "Name", morada.PaisId);
            return View(morada);
        }

        // GET: Morada/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var morada = await _context.Morada.FindAsync(id);
            if (morada == null)
            {
                return NotFound();
            }
            ViewData["PaisId"] = new SelectList(_context.Pais, "Id", "Name", morada.PaisId);
            return View(morada);
        }

        // POST: Morada/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Rua,Cidade,CodigoPostal,PaisId")] Morada morada)
        {
            if (id != morada.Rua)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(morada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoradaExists(morada.Rua))
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
            ViewData["PaisId"] = new SelectList(_context.Pais, "Id", "Name", morada.PaisId);
            return View(morada);
        }

        // GET: Morada/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var morada = await _context.Morada
                .Include(m => m.Pais)
                .FirstOrDefaultAsync(m => m.Rua == id);
            if (morada == null)
            {
                return NotFound();
            }

            return View(morada);
        }

        // POST: Morada/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var morada = await _context.Morada.FindAsync(id);
            _context.Morada.Remove(morada);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoradaExists(string id)
        {
            return _context.Morada.Any(e => e.Rua == id);
        }
    }
}

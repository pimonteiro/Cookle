using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cookle.Data;
using Cookle.Models;

namespace Cookle.Controllers
{
    public class NutrienteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NutrienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Nutriente
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nutriente.ToListAsync());
        }

        // GET: Nutriente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nutriente = await _context.Nutriente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nutriente == null)
            {
                return NotFound();
            }

            return View(nutriente);
        }

        // GET: Nutriente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nutriente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Unidade")] Nutriente nutriente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nutriente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nutriente);
        }

        // GET: Nutriente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nutriente = await _context.Nutriente.FindAsync(id);
            if (nutriente == null)
            {
                return NotFound();
            }
            return View(nutriente);
        }

        // POST: Nutriente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Unidade")] Nutriente nutriente)
        {
            if (id != nutriente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nutriente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NutrienteExists(nutriente.Id))
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
            return View(nutriente);
        }

        // GET: Nutriente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nutriente = await _context.Nutriente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nutriente == null)
            {
                return NotFound();
            }

            return View(nutriente);
        }

        // POST: Nutriente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nutriente = await _context.Nutriente.FindAsync(id);
            _context.Nutriente.Remove(nutriente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NutrienteExists(int id)
        {
            return _context.Nutriente.Any(e => e.Id == id);
        }
    }
}

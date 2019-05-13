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
    public class NutrienteReceitaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NutrienteReceitaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NutrienteReceita
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.NutrienteReceita.Include(n => n.Receita);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: NutrienteReceita/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nutrienteReceita = await _context.NutrienteReceita
                .Include(n => n.Receita)
                .FirstOrDefaultAsync(m => m.NutrienteId == id);
            if (nutrienteReceita == null)
            {
                return NotFound();
            }

            return View(nutrienteReceita);
        }

        // GET: NutrienteReceita/Create
        public IActionResult Create()
        {
            ViewData["ReceitaId"] = new SelectList(_context.Set<Receita>(), "Id", "Descricao");
            return View();
        }

        // POST: NutrienteReceita/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReceitaId,NutrienteId,Quantidade")] NutrienteReceita nutrienteReceita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nutrienteReceita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReceitaId"] = new SelectList(_context.Set<Receita>(), "Id", "Descricao", nutrienteReceita.ReceitaId);
            return View(nutrienteReceita);
        }

        // GET: NutrienteReceita/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nutrienteReceita = await _context.NutrienteReceita.FindAsync(id);
            if (nutrienteReceita == null)
            {
                return NotFound();
            }
            ViewData["ReceitaId"] = new SelectList(_context.Set<Receita>(), "Id", "Descricao", nutrienteReceita.ReceitaId);
            return View(nutrienteReceita);
        }

        // POST: NutrienteReceita/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReceitaId,NutrienteId,Quantidade")] NutrienteReceita nutrienteReceita)
        {
            if (id != nutrienteReceita.NutrienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nutrienteReceita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NutrienteReceitaExists(nutrienteReceita.NutrienteId))
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
            ViewData["ReceitaId"] = new SelectList(_context.Set<Receita>(), "Id", "Descricao", nutrienteReceita.ReceitaId);
            return View(nutrienteReceita);
        }

        // GET: NutrienteReceita/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nutrienteReceita = await _context.NutrienteReceita
                .Include(n => n.Receita)
                .FirstOrDefaultAsync(m => m.NutrienteId == id);
            if (nutrienteReceita == null)
            {
                return NotFound();
            }

            return View(nutrienteReceita);
        }

        // POST: NutrienteReceita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nutrienteReceita = await _context.NutrienteReceita.FindAsync(id);
            _context.NutrienteReceita.Remove(nutrienteReceita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NutrienteReceitaExists(int id)
        {
            return _context.NutrienteReceita.Any(e => e.NutrienteId == id);
        }
    }
}

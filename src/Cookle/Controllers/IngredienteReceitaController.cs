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
    public class IngredienteReceitaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IngredienteReceitaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IngredienteReceita
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.IngredienteReceita.Include(i => i.Ingrediente).Include(i => i.Receita);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: IngredienteReceita/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredienteReceita = await _context.IngredienteReceita
                .Include(i => i.Ingrediente)
                .Include(i => i.Receita)
                .FirstOrDefaultAsync(m => m.IngredienteId == id);
            if (ingredienteReceita == null)
            {
                return NotFound();
            }

            return View(ingredienteReceita);
        }

        // GET: IngredienteReceita/Create
        public IActionResult Create()
        {
            ViewData["IngredienteId"] = new SelectList(_context.Ingrediente, "Id", "Nome");
            ViewData["ReceitaId"] = new SelectList(_context.Set<Receita>(), "Id", "Descricao");
            return View();
        }

        // POST: IngredienteReceita/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReceitaId,IngredienteId,Quantidade,Unidade")] IngredienteReceita ingredienteReceita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingredienteReceita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IngredienteId"] = new SelectList(_context.Ingrediente, "Id", "Nome", ingredienteReceita.IngredienteId);
            ViewData["ReceitaId"] = new SelectList(_context.Set<Receita>(), "Id", "Descricao", ingredienteReceita.ReceitaId);
            return View(ingredienteReceita);
        }

        // GET: IngredienteReceita/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredienteReceita = await _context.IngredienteReceita.FindAsync(id);
            if (ingredienteReceita == null)
            {
                return NotFound();
            }
            ViewData["IngredienteId"] = new SelectList(_context.Ingrediente, "Id", "Nome", ingredienteReceita.IngredienteId);
            ViewData["ReceitaId"] = new SelectList(_context.Set<Receita>(), "Id", "Descricao", ingredienteReceita.ReceitaId);
            return View(ingredienteReceita);
        }

        // POST: IngredienteReceita/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReceitaId,IngredienteId,Quantidade,Unidade")] IngredienteReceita ingredienteReceita)
        {
            if (id != ingredienteReceita.IngredienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingredienteReceita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredienteReceitaExists(ingredienteReceita.IngredienteId))
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
            ViewData["IngredienteId"] = new SelectList(_context.Ingrediente, "Id", "Nome", ingredienteReceita.IngredienteId);
            ViewData["ReceitaId"] = new SelectList(_context.Set<Receita>(), "Id", "Descricao", ingredienteReceita.ReceitaId);
            return View(ingredienteReceita);
        }

        // GET: IngredienteReceita/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredienteReceita = await _context.IngredienteReceita
                .Include(i => i.Ingrediente)
                .Include(i => i.Receita)
                .FirstOrDefaultAsync(m => m.IngredienteId == id);
            if (ingredienteReceita == null)
            {
                return NotFound();
            }

            return View(ingredienteReceita);
        }

        // POST: IngredienteReceita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingredienteReceita = await _context.IngredienteReceita.FindAsync(id);
            _context.IngredienteReceita.Remove(ingredienteReceita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngredienteReceitaExists(int id)
        {
            return _context.IngredienteReceita.Any(e => e.IngredienteId == id);
        }
    }
}

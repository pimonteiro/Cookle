using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cookle.Data;
using Cookle.Models;

namespace Cookle.Controllers
{
    public class PassoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PassoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Passo
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Passo.Include(p => p.Receita).Include(p => p.SubReceita);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Passo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passo = await _context.Passo
                .Include(p => p.Receita)
                .Include(p => p.SubReceita)
                .FirstOrDefaultAsync(m => m.Numero == id);
            if (passo == null)
            {
                return NotFound();
            }

            return View(passo);
        }

        // GET: Passo/Create
        public IActionResult Create()
        {
            ViewData["ReceitaId"] = new SelectList(_context.Receita, "Id", "Descricao");
            ViewData["SubReceitaId"] = new SelectList(_context.Receita, "Id", "Descricao");
            return View();
        }

        // POST: Passo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Numero,ReceitaId,SubReceitaId,Descricao")] Passo passo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReceitaId"] = new SelectList(_context.Receita, "Id", "Descricao", passo.ReceitaId);
            ViewData["SubReceitaId"] = new SelectList(_context.Receita, "Id", "Descricao", passo.SubReceitaId);
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
            ViewData["ReceitaId"] = new SelectList(_context.Receita, "Id", "Descricao", passo.ReceitaId);
            ViewData["SubReceitaId"] = new SelectList(_context.Receita, "Id", "Descricao", passo.SubReceitaId);
            return View(passo);
        }

        // POST: Passo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Numero,ReceitaId,SubReceitaId,Descricao")] Passo passo)
        {
            if (id != passo.Numero)
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
                    if (!PassoExists(passo.Numero))
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
            ViewData["ReceitaId"] = new SelectList(_context.Receita, "Id", "Descricao", passo.ReceitaId);
            ViewData["SubReceitaId"] = new SelectList(_context.Receita, "Id", "Descricao", passo.SubReceitaId);
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
                .Include(p => p.Receita)
                .Include(p => p.SubReceita)
                .FirstOrDefaultAsync(m => m.Numero == id);
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
            return _context.Passo.Any(e => e.Numero == id);
        }

        // Get Passo/Receipt/5?passo=1
        public IActionResult Receipt(int id, int passo)
        {
            var receita = _context.Receita.Include(f => f.Passos).Where(r => r.Id == id).ToList().FirstOrDefault();
            
            if (receita == null)
            {
                return NotFound();
            }

            if (passo <= 0)
            {
                var data = new
                {
                    id = id
                };
                return RedirectToAction("Preview", "Receita", data);
            }
            else if (passo == receita.Passos.Count)

            {
                var data = new
                {
                    idR = id,
                    idU = User.FindFirst(ClaimTypes.NameIdentifier).Value
                };
                return RedirectToAction("Finish", "Receita", data);

            }
            else if (passo > receita.Passos.Count)
            {
                return NotFound();
            }
                return View(receita.Passos[passo-1]);
        }
    }
}

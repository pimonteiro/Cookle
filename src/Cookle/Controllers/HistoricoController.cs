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
    public class HistoricoController : Controller
    {
        private readonly CookleContext _context;

        public HistoricoController(CookleContext context)
        {
            _context = context;
        }

        // GET: Historico
        public async Task<IActionResult> Index()
        {
            var cookleContext = _context.Historico.Include(h => h.Receita).Include(h => h.User);
            return View(await cookleContext.ToListAsync());
        }

        // GET: Historico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historico = await _context.Historico
                .Include(h => h.Receita)
                .Include(h => h.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (historico == null)
            {
                return NotFound();
            }

            return View(historico);
        }

        // GET: Historico/Create
        public IActionResult Create()
        {
            ViewData["ReceitaId"] = new SelectList(_context.Receita, "Id", "Descricao");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Cidade");
            return View();
        }

        // POST: Historico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,ReceitaId,UltimaVez,Numero")] Historico historico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReceitaId"] = new SelectList(_context.Receita, "Id", "Descricao", historico.ReceitaId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Cidade", historico.UserId);
            return View(historico);
        }

        // GET: Historico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historico = await _context.Historico.FindAsync(id);
            if (historico == null)
            {
                return NotFound();
            }
            ViewData["ReceitaId"] = new SelectList(_context.Receita, "Id", "Descricao", historico.ReceitaId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Cidade", historico.UserId);
            return View(historico);
        }

        // POST: Historico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,ReceitaId,UltimaVez,Numero")] Historico historico)
        {
            if (id != historico.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoricoExists(historico.UserId))
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
            ViewData["ReceitaId"] = new SelectList(_context.Receita, "Id", "Descricao", historico.ReceitaId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Cidade", historico.UserId);
            return View(historico);
        }

        // GET: Historico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historico = await _context.Historico
                .Include(h => h.Receita)
                .Include(h => h.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (historico == null)
            {
                return NotFound();
            }

            return View(historico);
        }

        // POST: Historico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historico = await _context.Historico.FindAsync(id);
            _context.Historico.Remove(historico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoricoExists(int id)
        {
            return _context.Historico.Any(e => e.UserId == id);
        }
    }
}

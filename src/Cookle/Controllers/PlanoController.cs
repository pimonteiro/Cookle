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
    public class PlanoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlanoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Plano
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Plano.Include(p => p.Receita).Include(p => p.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Plano/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plano = await _context.Plano
                .Include(p => p.Receita)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (plano == null)
            {
                return NotFound();
            }

            return View(plano);
        }

        // GET: Plano/Create
        public IActionResult Create()
        {
            ViewData["ReceitaId"] = new SelectList(_context.Receita, "Id", "Descricao");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id");
            return View();
        }

        // POST: Plano/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,ReceitaId")] Plano plano)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plano);
                await _context.SaveChangesAsync();
                var data = new
                {
                    id = plano.UserId
                };
                return RedirectToAction("User", data);
            }
            ViewData["ReceitaId"] = new SelectList(_context.Receita, "Id", "Descricao", plano.ReceitaId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", plano.UserId);
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
            ViewData["ReceitaId"] = new SelectList(_context.Receita, "Id", "Descricao", plano.ReceitaId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", plano.UserId);
            return View(plano);
        }

        // POST: Plano/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,ReceitaId")] Plano plano)
        {
            if (id != plano.UserId)
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
                    if (!PlanoExists(plano.UserId))
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
            ViewData["ReceitaId"] = new SelectList(_context.Receita, "Id", "Descricao", plano.ReceitaId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", plano.UserId);
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
                .Include(p => p.Receita)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
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
            return _context.Plano.Any(e => e.UserId == id);
        }
        
        
        public IActionResult User(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var plano = _context.Plano
                .Include(r => r.Receita)
                .Where(f => f.UserId == id).ToList();
            ViewData["User"] = id;
            return View(plano);

        }
        
        public async Task<IActionResult> RemoveRec(int? id, int? rec)
        {
            if (rec == null){
                return RedirectToAction("User", new {id = id});
            }

            var plano = _context.Plano.Where(f => f.UserId == id && f.ReceitaId == rec).ToList();
            _context.Plano.Remove(plano.FirstOrDefault());
            await _context.SaveChangesAsync();
            return RedirectToAction("User", new {id = id});

        }
        
        public async Task<IActionResult> AddRec([Bind("UserId,ReceitaId")] Plano plano)
        {
            var data = new
            {
                id = plano.UserId
            };
            
            if (_context.Plano.FirstOrDefault(f => plano.UserId == f.UserId && plano.ReceitaId == f.ReceitaId) == null)
            {
                _context.Add(plano);
                await _context.SaveChangesAsync();
                
            }

            return RedirectToAction("User", data);
        }
    }
}

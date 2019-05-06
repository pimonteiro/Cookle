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
    public class FrigorificoController : Controller
    {
        private readonly CookleContext _context;

        public FrigorificoController(CookleContext context)
        {
            _context = context;
        }

        // GET: Frigorifico
        public async Task<IActionResult> Index()
        {
            var cookleContext = _context.Frigorifico.Include(f => f.User);
            return View(await cookleContext.ToListAsync());
        }

        // GET: Frigorifico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frigorifico = await _context.Frigorifico
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (frigorifico == null)
            {
                return NotFound();
            }

            return View(frigorifico);
        }

        // GET: Frigorifico/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Cidade");
            return View();
        }

        // POST: Frigorifico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,IngredienteId,Quantidade,Data")] Frigorifico frigorifico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(frigorifico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Cidade", frigorifico.UserId);
            return View(frigorifico);
        }

        // GET: Frigorifico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frigorifico = await _context.Frigorifico.FindAsync(id);
            if (frigorifico == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Cidade", frigorifico.UserId);
            return View(frigorifico);
        }

        // POST: Frigorifico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,IngredienteId,Quantidade,Data")] Frigorifico frigorifico)
        {
            if (id != frigorifico.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(frigorifico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FrigorificoExists(frigorifico.UserId))
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
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Cidade", frigorifico.UserId);
            return View(frigorifico);
        }

        // GET: Frigorifico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frigorifico = await _context.Frigorifico
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (frigorifico == null)
            {
                return NotFound();
            }

            return View(frigorifico);
        }

        // POST: Frigorifico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var frigorifico = await _context.Frigorifico.FindAsync(id);
            _context.Frigorifico.Remove(frigorifico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FrigorificoExists(int id)
        {
            return _context.Frigorifico.Any(e => e.UserId == id);
        }
    }
}

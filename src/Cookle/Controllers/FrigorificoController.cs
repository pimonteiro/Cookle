using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cookle.Data;
using Cookle.Models;
using Microsoft.AspNetCore.Routing;

namespace Cookle.Controllers
{
    public class FrigorificoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FrigorificoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Frigorifico
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Frigorifico.Include(f => f.User);
            return View(await applicationDbContext.ToListAsync());
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
                .Where(f => f.UserId == id)
                .ToListAsync();
            if (frigorifico == null)
            {
                return NotFound();
            }

            return View(frigorifico);
        }

        // GET: Frigorifico/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id");
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
                var tmp = _context.Frigorifico.Where(f =>
                    f.UserId == frigorifico.UserId && f.IngredienteId == frigorifico.IngredienteId).ToList();

                if (tmp.Count == 0)
                {
                    frigorifico.User = _context.User.Find(frigorifico.UserId);
                    frigorifico.Ingrediente = _context.Ingrediente.Find(frigorifico.IngredienteId);
                    _context.Add(frigorifico);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var updatedFrigde = tmp.First();
                    updatedFrigde.Quantidade += frigorifico.Quantidade;
                    updatedFrigde.Data = DateTime.Now;
                    await _context.SaveChangesAsync();
                }
                
                var data = new
                {
                    id = frigorifico.UserId
                };
                return RedirectToAction("User", data);
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", frigorifico.UserId);
            return RedirectToAction(nameof(User), new {id = frigorifico.UserId});
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
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", frigorifico.UserId);
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
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", frigorifico.UserId);
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

        public IActionResult User(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var frigorificos = _context.Frigorifico
                .Include(m => m.Ingrediente)
                .Where(f => f.UserId == id).ToList();
            ViewData["Ingredientes"] = _context.Ingrediente.ToList();
            ViewData["User"] = id;
            return View(frigorificos);

        }

        public async Task<IActionResult> RemoveIng(int? id, int? ing)
        {
            if (ing == null){
                return RedirectToAction("User", new {id = id});
            }

            var frigorifico = _context.Frigorifico.Where(f => f.UserId == id && f.IngredienteId == ing).ToList();
            _context.Frigorifico.Remove(frigorifico.FirstOrDefault());
            await _context.SaveChangesAsync();
            return RedirectToAction("User", new {id = id});

        }
    }
}

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
using Microsoft.AspNetCore.Identity;

namespace Cookle.Controllers
{
    public class ReceitaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReceitaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Receita
        public async Task<IActionResult> Index()
        {
            return View(await _context.Receita.ToListAsync());
        }

        // GET: Receita/Details/5
        // Receita na integra
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = await _context.Receita
                .Include(f => f.Passos)
                .Include(f => f.IngredienteReceitas)
                .ThenInclude(m => m.Ingrediente)
                .Include(f => f.NutrienteReceitas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receita == null)
            {
                return NotFound();
            }

            float nut = 0;
            if (receita.NutrienteReceitas != null)
            {
                foreach (NutrienteReceita rec in receita.NutrienteReceitas)
                {
                    nut += rec.Quantidade;
                }
            }

            ViewData["ValorNutricional"] = nut;
            ViewData["UserId"] = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return View(receita);
        }

        // GET: Receita/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Receita/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,TempoPrep,NumPessoas,Dificuldade,Tipo,Imagem,Video")] Receita receita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(receita);
        }

        // GET: Receita/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = await _context.Receita.FindAsync(id);
            if (receita == null)
            {
                return NotFound();
            }
            return View(receita);
        }

        // POST: Receita/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,TempoPrep,NumPessoas,Dificuldade,Tipo,Imagem,Video")] Receita receita)
        {
            if (id != receita.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceitaExists(receita.Id))
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
            return View(receita);
        }

        // GET: Receita/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = await _context.Receita
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receita == null)
            {
                return NotFound();
            }

            return View(receita);
        }

        // POST: Receita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var receita = await _context.Receita.FindAsync(id);
            _context.Receita.Remove(receita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceitaExists(int id)
        {
            return _context.Receita.Any(e => e.Id == id);
        }

        // GET: Receita/Preview/5
        public async Task<IActionResult> Preview(int? id)
        {    
            if (id == null)
            {
                return NotFound();
            }

            var receita = await _context.Receita
                .Include(f => f.Passos)
                .Include(f => f.IngredienteReceitas)
                .ThenInclude(m => m.Ingrediente)
                .Include(f => f.NutrienteReceitas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receita == null)
            {
                return NotFound();
            }

            float nut = 0;
            if (receita.NutrienteReceitas != null)
            {
                foreach (NutrienteReceita rec in receita.NutrienteReceitas)
                {
                    nut += rec.Quantidade;
                }
            }
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var notas = _context.Nota.Where(f => f.ReceitaId == id && f.UserId.ToString() == userId).ToList();

            ViewData["ValorNutricional"] = nut;
            ViewData["NotasUser"] = notas;
            ViewData["UserId"] = userId;
            return View(receita);
        }

        // GET: Receita/Finish/5
        public  IActionResult Finish(int idU, int idR)
        {
            var past = _context.Historico.Where(h => h.ReceitaId == idR && h.UserId == idU).ToList();
            if ( past.Count != 0)
            {
                var temp = _context.Historico.First(h => h.ReceitaId == idR && h.UserId == idU);
                temp.Numero++;
                temp.UltimaVez = DateTime.Now;
            }
            else
            {
                var historico = new Historico()
                {
                    UserId = idU,
                    ReceitaId = idR,
                    UltimaVez = DateTime.Now,
                    User = _context.User.First(u => u.Id == idU),
                    Receita = _context.Receita.First(u => u.Id == idR)
                };
                _context.Historico.Add(historico);
            }

            var planos = _context.Plano.FirstOrDefault(p => p.UserId == idU && p.ReceitaId == idR);
            if (planos != null)
            {
                _context.Remove(planos);
                
            }
            _context.SaveChangesAsync();
            return RedirectToAction("Preview", new {id = idR});
        }

        // GET: Receita/Search
        public async Task<IActionResult> Search(string search, string tipo)
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewData["UserId"] = _context.User.Include(f => f.Planos).First(p => p.Id.ToString() == id);

            if (!String.IsNullOrEmpty(search))
            {
                return View(_context.Receita.Where(f => f.Nome.Contains(search)).ToList());
            }
            else
            {
                return View(_context.Receita.ToList());
            }
        }
    }
}

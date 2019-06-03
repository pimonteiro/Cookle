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
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || id.ToString() != LoggedUserId())
            {
                return NotFound();
            }

            var user = await _context.User.Include(f => f.PreferenciaIngredientes).FirstAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            ViewData["Ingredientes"] = _context.Ingrediente.ToList();

            return View(user);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind(
                "Sexo,DataNascimento,Voz,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")]
            User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.Include(f => f.PreferenciaIngredientes).FirstAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            ViewData["Ingredientes"] = _context.Ingrediente.ToList();
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind(
                "Sexo,DataNascimento,Voz,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")]
            User user)
        {
            if (id != user.Id || id.ToString() != LoggedUserId())
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction("Details",new {id = id});
            }

            return RedirectToAction("Details",new {id = id});
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }

        public String LoggedUserId()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return id;
        }

        [HttpPost]
        public async Task<IActionResult> AddIng(int id, [Bind("Tipo,IngredienteId")] PreferenciaIngrediente ing)
        {
            if (id.ToString() != LoggedUserId())
            {
                return NotFound();
            }
            ing.Ingrediente = _context.Ingrediente.Find(ing.IngredienteId);
            ing.User = _context.User.Find(id);
            ing.UserId = id;
            _context.PreferenciaIngrediente.Add(ing);
            await _context.SaveChangesAsync();
            
            return RedirectToAction("Details", new {id = id});
        }

        public async Task<IActionResult> RemoveIng(int id, int ingId)
        {
            if (id.ToString() != LoggedUserId())
            {
                return NotFound();
            }
            var ing = _context.PreferenciaIngrediente.First(f => f.UserId == id && f.IngredienteId == ingId);
            if (ing == null)
            {
                return NotFound();
            }
            _context.Remove(ing);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new {id = id});
        }
    }
}
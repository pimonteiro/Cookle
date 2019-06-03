using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Cookle.Data;
using Microsoft.AspNetCore.Mvc;
using Cookle.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cookle.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<User> _userManager;
        private ApplicationDbContext _context;

        public HomeController(UserManager<User> userManager, ApplicationDbContext context)
        {
            {
                _userManager = userManager;
                _context = context;
            }
        }
        
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            //TODO need to access user stuff from the database
            var userData = await _context.User
                .Include(f => f.Frigorificos)
                .ThenInclude(m => m.Ingrediente)
                .Include(f => f.Historicos)
                .ThenInclude(m => m.Receita)
                .Include(f => f.Planos)
                .ThenInclude(m => m.Receita)
                .Where(f => f.Id == user.Id).FirstAsync();
        
            return View(userData);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            return View();
        }

        
    }
}

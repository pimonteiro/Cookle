using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cookle.Models;

namespace Cookle.Models
{
    public class CookleContext : DbContext
    {
        public CookleContext(DbContextOptions<CookleContext> options) : base(options)
        {
        }

        public DbSet<Cookle.Models.User> User { get; set; }
        public DbSet<Cookle.Models.Pais> Pais { get; set; }
        public DbSet<Cookle.Models.Admin> Admin { get; set; }
        public DbSet<Cookle.Models.Nutriente> Nutriente { get; set; }
        public DbSet<Cookle.Models.Ingrediente> Ingrediente { get; set; }
        public DbSet<Cookle.Models.Receita> Receita { get; set; }
    }
}
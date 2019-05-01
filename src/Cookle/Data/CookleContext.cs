using Cookle.Models;
using Microsoft.EntityFrameworkCore;

namespace Cookle.Data
{
    public class CookleContext : DbContext
    {
        public CookleContext(DbContextOptions<CookleContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
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
        public CookleContext(DbContextOptions<CookleContext> options) : base(options){

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Historico>().HasKey(table => new {
                table.User, table.Receita
            });
            builder.Entity<Frigorifico>().HasKey(table => new {
                table.User, table.Ingrediente
            });
            builder.Entity<IngredienteReceita>().HasKey(table => new {
                table.Ingrediente, table.Receita
            });
            builder.Entity<Morada>().HasKey(table => new {
                table.Rua, table.Cidade, table.Pais, table.CodigoPostal
            });
            builder.Entity<Nota>().HasKey(table => new {
                table.User, table.Receita, table.Id
            });
            builder.Entity<NutrienteReceita>().HasKey(table => new {
                table.Nutriente, table.Receita
            });
            builder.Entity<Passo>().HasKey(table => new {
                table.Ingrediente, table.Numero
            });
            builder.Entity<Plano>().HasKey(table => new {
                table.User, table.Receita
            });
            builder.Entity<PreferenciaIngrediente>().HasKey(table => new {
                table.User, table.Ingrediente
            });
           

        }
        

        public DbSet<Cookle.Models.User> User { get; set; }
        public DbSet<Cookle.Models.Pais> Pais { get; set; }
        public DbSet<Cookle.Models.Admin> Admin { get; set; }
        public DbSet<Cookle.Models.Nutriente> Nutriente { get; set; }
        public DbSet<Cookle.Models.Ingrediente> Ingrediente { get; set; }
        public DbSet<Cookle.Models.Receita> Receita { get; set; }
        public DbSet<Cookle.Models.Historico> Historico { get; set; }
        public DbSet<Cookle.Models.Nota> Nota { get; set; }
        public DbSet<Cookle.Models.Frigorifico> Frigorifico { get; set; }
        public DbSet<Cookle.Models.Plano> Plano { get; set; }
        public DbSet<Cookle.Models.Morada> Morada { get; set; }
        public DbSet<Cookle.Models.Passo> Passo { get; set; }
        public DbSet<Cookle.Models.PreferenciaIngrediente> PreferenciaIngrediente { get; set; }
        public DbSet<Cookle.Models.NutrienteReceita> NutrienteReceita { get; set; }
    }
    
}
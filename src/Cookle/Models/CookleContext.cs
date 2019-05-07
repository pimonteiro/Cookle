using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cookle.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Cookle.Models
{
    public class CookleContext : DbContext
    {
        public CookleContext(DbContextOptions<CookleContext> options) : base(options){

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Historico>().HasKey(table => new {
                table.UserId, table.ReceitaId
            });
            builder.Entity<Frigorifico>().HasKey(table => new {
                table.UserId, table.IngredienteId
            });
            builder.Entity<IngredienteReceita>().HasKey(table => new {
                table.IngredienteId, table.ReceitaId
            });
            builder.Entity<Morada>().HasKey(table => new
            {
                table.Rua, table.Cidade, table.CodigoPostal
            });
            builder.Entity<NutrienteReceita>().HasKey(table => new {
                table.NutrienteId, table.ReceitaId
            });
            builder.Entity<Passo>().HasKey(table => new {
                table.Numero, table.ReceitaId
            });
            builder.Entity<Plano>().HasKey(table => new {
                table.UserId, table.ReceitaId
            });
            builder.Entity<PreferenciaIngrediente>().HasKey(table => new {
                table.UserId, table.IngredienteId
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
        public DbSet<Cookle.Models.IngredienteReceita> IngredienteReceita { get; set; }
    }
    
}
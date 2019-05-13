using System;
using System.Collections.Generic;
using System.Text;
using Cookle.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cookle.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Historico>().HasKey(table => new {
                table.UserId, table.ReceitaId
            });
            builder.Entity<Frigorifico>().HasKey(table => new {
                table.UserId, table.IngredienteId
            });
            builder.Entity<IngredienteReceita>().HasKey(table => new {
                table.IngredienteId, table.ReceitaId
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
    }
}

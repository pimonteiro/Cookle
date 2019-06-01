using System;
using System.Collections.Generic;
using System.Text;
using Cookle.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cookle.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Historico>().HasKey(table => new
            {
                table.UserId, table.ReceitaId
            });
            builder.Entity<Frigorifico>().HasKey(table => new
            {
                table.UserId, table.IngredienteId
            });
            builder.Entity<IngredienteReceita>().HasKey(table => new
            {
                table.IngredienteId, table.ReceitaId
            });
            builder.Entity<NutrienteReceita>().HasKey(table => new
            {
                table.NutrienteId, table.ReceitaId
            });
            builder.Entity<Passo>().HasKey(table => new
            {
                table.Numero, table.ReceitaId
            });
            builder.Entity<Plano>().HasKey(table => new
            {
                table.UserId, table.ReceitaId
            });
            builder.Entity<PreferenciaIngrediente>().HasKey(table => new
            {
                table.UserId, table.IngredienteId
            });


            builder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 1,
                    Email = "admin@admin.com",
                    Password = "admin"
                }
            );

            builder.Entity<Nutriente>().HasData(
                new Nutriente
                {
                    Id = 1,
                    Nome = "Hidratos de carbono",
                    Unidade = 0
                });
            
            builder.Entity<Nutriente>().HasData(
                new Nutriente
                {
                    Id = 2,
                    Nome = "Lípidos",
                    Unidade = 0
                });
            
            builder.Entity<Nutriente>().HasData(
                new Nutriente
                {
                    Id = 3,
                    Nome = "Proteínas",
                    Unidade = 0
                });
            
            builder.Entity<Ingrediente>().HasData(
                new Ingrediente
                {
                    Id = 1,
                    Nome = "Ovos",
                });
            
            builder.Entity<Ingrediente>().HasData(
                new Ingrediente
                {
                    Id = 2,
                    Nome = "Farinha de trigo",
                });
            
            builder.Entity<Ingrediente>().HasData(
                new Ingrediente
                {
                    Id = 3,
                    Nome = "Leite",
                });
            
            builder.Entity<Ingrediente>().HasData(
                new Ingrediente
                {
                    Id = 4,
                    Nome = "Sal",
                });
            
            builder.Entity<Ingrediente>().HasData(
                new Ingrediente
                {
                    Id = 5,
                    Nome = "Oleo vegetal",
                });
        }

        public DbSet<Cookle.Models.Admin> Admin { get; set; }
        public DbSet<Cookle.Models.Frigorifico> Frigorifico { get; set; }
        public DbSet<Cookle.Models.Historico> Historico { get; set; }
        public DbSet<Cookle.Models.Ingrediente> Ingrediente { get; set; }
        public DbSet<Cookle.Models.IngredienteReceita> IngredienteReceita { get; set; }
        public DbSet<Cookle.Models.Nota> Nota { get; set; }
        public DbSet<Cookle.Models.Nutriente> Nutriente { get; set; }
        public DbSet<Cookle.Models.NutrienteReceita> NutrienteReceita { get; set; }
        public DbSet<Cookle.Models.Passo> Passo { get; set; }
        public DbSet<Cookle.Models.Plano> Plano { get; set; }
        public DbSet<Cookle.Models.PreferenciaIngrediente> PreferenciaIngrediente { get; set; }
        public DbSet<Cookle.Models.Receita> Receita { get; set; }
        public DbSet<Cookle.Models.User> User { get; set; }
    }
}
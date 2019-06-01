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
                    Password = "admin",
                    Name = "ADMIN"
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

            builder.Entity<Receita>().HasData(
                new Receita
                {
                    Id = 1,
                    Descricao = "Uma massa simples mas deliciosa.",
                    Dificuldade = 1,
                    Nome = "Massa de panquecas simples",
                    TempoPrep = 15,
                    NumPessoas = 2,
                    Tipo = 0, // SHOULD BE AN ENUM; TOO LATE 
                }
            );

            builder.Entity<NutrienteReceita>().HasData(
                new NutrienteReceita
                {
                    ReceitaId = 1,
                    NutrienteId = 1,
                    Quantidade = 60.3f
                });

            builder.Entity<NutrienteReceita>().HasData(
                new NutrienteReceita
                {
                    ReceitaId = 1,
                    NutrienteId = 2,
                    Quantidade = 13.0f
                });

            builder.Entity<NutrienteReceita>().HasData(
                new NutrienteReceita
                {
                    ReceitaId = 1,
                    NutrienteId = 3,
                    Quantidade = 10.1f
                });

            builder.Entity<IngredienteReceita>().HasData(
                new IngredienteReceita
                {
                    ReceitaId = 1,
                    IngredienteId = 1,
                    Quantidade = 1.0f,
                    Unidade = 0
                });

            builder.Entity<IngredienteReceita>().HasData(
                new IngredienteReceita
                {
                    ReceitaId = 1,
                    IngredienteId = 2,
                    Quantidade = 1.0f,
                    Unidade = 1
                });

            builder.Entity<IngredienteReceita>().HasData(
                new IngredienteReceita
                {
                    ReceitaId = 1,
                    IngredienteId = 3,
                    Quantidade = 1.0f,
                    Unidade = 1
                });

            builder.Entity<IngredienteReceita>().HasData(
                new IngredienteReceita
                {
                    ReceitaId = 1,
                    IngredienteId = 4,
                    Quantidade = 2.0f,
                    Unidade = 2
                });

            builder.Entity<IngredienteReceita>().HasData(
                new IngredienteReceita
                {
                    ReceitaId = 1,
                    IngredienteId = 5,
                    Quantidade = 1.5f,
                    Unidade = 3
                });

            builder.Entity<Passo>().HasData(
                new Passo
                {
                    ReceitaId = 1,
                    Descricao = "Bata todos os ingredientes no liquidificador até obter uma consistência cremosa.",
                    Numero = 1
                });
            
            builder.Entity<Passo>().HasData(
                new Passo
                {
                    ReceitaId = 1,
                    Descricao = "Unte uma frigideira com óleo e despeje uma concha de massa.",
                    Numero = 2
                });
            
            builder.Entity<Passo>().HasData(
                new Passo
                {
                    ReceitaId = 1,
                    Descricao = "Faça movimentos circulares para que a massa se espalhe por toda a frigideira.",
                    Numero = 3
                });
            
            
            builder.Entity<Passo>().HasData(
                new Passo
                {
                    ReceitaId = 1,
                    Descricao = "Espere até a massa se soltar do fundo, vire e deixe fritar do outro lado.",
                    Numero = 4
                });
            
            builder.Entity<Passo>().HasData(
                new Passo
                {
                    ReceitaId = 1,
                    Descricao = "Acrescente o recheio de sua preferência, enrole e está pronta para servir.",
                    Numero = 5
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
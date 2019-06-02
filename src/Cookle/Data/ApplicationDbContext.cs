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

            #region AdminSeed
            builder.Entity<Admin>().HasData(
                new Admin() { Id = 1, Email = "admin@admin.pt", Name = "Admin", Password = "admin123" });
            #endregion

            #region FrigorificoSeed
            builder.Entity<Frigorifico>().HasData(
                new Frigorifico() { UserId = 1, IngredienteId = 1, Data = DateTime.Parse("2019-06-30"), Quantidade= 3});
            #endregion

            #region HistoricoSeed
            builder.Entity<Historico>().HasData(
                new Historico() { UserId = 1, ReceitaId = 1, Numero= 1, UltimaVez = DateTime.Parse("2019-06-30")});
            #endregion

            #region IngredienteSeed

            builder.Entity<Ingrediente>().HasData(
                new Ingrediente() {Id = 1, Nome = "ovos"},
                new Ingrediente() {Id = 2, Nome = "manteiga"},
                new Ingrediente() {Id = 3, Nome = "iogurte natural"},
                new Ingrediente() {Id = 4, Nome = "açúcar"},
                new Ingrediente() {Id = 5, Nome = "óleo"},
                new Ingrediente() {Id = 6, Nome = "fermento em pó"},
                new Ingrediente() {Id = 7, Nome = "farinha"},
                new Ingrediente() {Id = 8, Nome = "açúcar em pó"});

                #endregion


                #region IngredienteReceitaSeed

                builder.Entity<IngredienteReceita>().HasData(
                    new IngredienteReceita() {IngredienteId = 1, ReceitaId = 1, Quantidade = 4, Unidade = 1},
                    new IngredienteReceita() {IngredienteId = 1, ReceitaId = 2, Quantidade = 2, Unidade = 1},
                    new IngredienteReceita() {IngredienteId = 2, ReceitaId = 1, Quantidade = 1, Unidade = 1},
                    new IngredienteReceita() {IngredienteId = 3, ReceitaId = 1, Quantidade = 1, Unidade = 1},
                    new IngredienteReceita() {IngredienteId = 4, ReceitaId = 1, Quantidade = 3, Unidade = 1},
                    new IngredienteReceita() {IngredienteId = 5, ReceitaId = 1, Quantidade = 0.25f, Unidade = 1},
                    new IngredienteReceita() {IngredienteId = 6, ReceitaId = 1, Quantidade = 2, Unidade = 1},
                    new IngredienteReceita() {IngredienteId = 7, ReceitaId = 1, Quantidade = 2, Unidade = 1},
                    new IngredienteReceita() {IngredienteId = 8, ReceitaId = 1, Quantidade = 2, Unidade = 1});

                    #endregion

                    #region NotaSeed

                    builder.Entity<Nota>().HasData(
                        new Nota()
                        {
                            Id = 1, Data = DateTime.Parse("2019-06-01"),
                            Descricao = "Acrescentar mais açucar na próxima confeção.", ReceitaId = 1, UserId = 1
                        }
                    );
            #endregion


            #region NutrienteSeed
            builder.Entity<Nutriente>().HasData(
                new Nutriente() { Id = 1, Nome="Proteína", Unidade=1});
            #endregion

            #region NutrienteReceitaSeed
            builder.Entity<NutrienteReceita>().HasData(
                new NutrienteReceita() { NutrienteId = 1, ReceitaId=1, Quantidade=3});
            #endregion

            #region PassoSeed
            builder.Entity<Passo>().HasData(
                new Passo() { Numero = 1, ReceitaId=1, Descricao="Pre-aqueça o forno a 180º C."});
                builder.Entity<Passo>().HasData(
                new Passo() { Numero = 2, ReceitaId=1, Descricao="Unte uma forma de chaminé com manteiga e reserve."},
                new Passo() { Numero = 3, ReceitaId=1, Descricao="Bata as claras em castelo e reserve numa taça.", SubReceitaId=2},
                new Passo() { Numero = 4, ReceitaId=1, Descricao="Numa taça, adicione o iogurte e as gemas de ovo. Utilize a medida do copo de iogurte e adicione o açúcar, o óleo, a farinha e o fermento."},
                new Passo() { Numero = 5, ReceitaId=1, Descricao="Junte as claras e bata com uma batedeira até a massa estar homogénea."},
                new Passo() { Numero = 6, ReceitaId=1, Descricao="Deite a massa na forma de chaminé, previamente untada, e leve ao forno durante 40 a 45 minutos, ou espete um palito na massa e verifique se sai limpo."},
                new Passo() { Numero = 7, ReceitaId=1, Descricao=" Retire do forno e deixe arrefecer ligeiramente antes de desenformar. Antes de servir, polvilhe com o açúcar em pó."},

                new Passo() { Numero = 1, ReceitaId=2, Descricao="Separe as claras das gemas."});
                builder.Entity<Passo>().HasData(
                new Passo() { Numero = 2, ReceitaId=2, Descricao="Coloque-as no copo da batedeira."},
                new Passo() { Numero = 3, ReceitaId=2, Descricao="Bata em velocidade mínima durante 7 minutos.", SubReceitaId=2},
                new Passo() { Numero = 4, ReceitaId=2, Descricao="Caso seja necessário, bata mais 3 minutos até obter a consistência de neve."},
                new Passo() { Numero = 5, ReceitaId=2, Descricao="Para verificar se as claras estão no ponto, vire o recipiente ao contrário e, se permanecerem no fundo, sem cair, estão perfeitas."});
            #endregion

            #region PlanoReceitaSeed
            builder.Entity<Plano>().HasData(
                new Plano() { UserId = 1, ReceitaId=1});
            #endregion
            
            #region PreferenciaIngredienteSeed
            builder.Entity<PreferenciaIngrediente>().HasData(
                new PreferenciaIngrediente() { UserId = 1, IngredienteId=1, Tipo = Models.Tipo.Pref});
            #endregion

            #region ReceitaSeed
            builder.Entity<Receita>().HasData(
                new Receita() { Id = 1, Descricao="Um dos bolos mais fáceis e saborosos - e uma receita muito indicada para ensinar às crianças. Pode ser feito com iogurte natural ou de qualquer sabor e é óptimo para o lanche.", Dificuldade=1, Imagem="https://www.pingodoce.pt/wp-content/uploads/2016/03/comofazerbolodeiogurte617.jpg", Nome="Bolo de iogurte", NumPessoas=10, TempoPrep=55});
             builder.Entity<Receita>().HasData(
                new Receita() { Id = 2, Descricao="A forma mais fácil de bater claras em castelo, para que os seus bolos fiquem perfeitos.", Dificuldade=1, Imagem="https://i1.wp.com/www.docesregionais.com/wp-content/uploads/2013/02/Como-Bater-Claras-em-NeveCastelo.jpg?w=640", Nome="Claras em Castelo"});
            #endregion



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

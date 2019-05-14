﻿// <auto-generated />
using System;
using Cookle.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cookle.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cookle.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(45);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(45);

                    b.HasKey("Id");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("Cookle.Models.Frigorifico", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("IngredienteId");

                    b.Property<DateTime>("Data");

                    b.Property<int?>("IngredienteId1");

                    b.Property<int>("Quantidade");

                    b.HasKey("UserId", "IngredienteId");

                    b.HasAlternateKey("IngredienteId", "UserId");

                    b.HasIndex("IngredienteId1");

                    b.ToTable("Frigorifico");
                });

            modelBuilder.Entity("Cookle.Models.Historico", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("ReceitaId");

                    b.Property<int>("Numero");

                    b.Property<DateTime>("UltimaVez");

                    b.HasKey("UserId", "ReceitaId");

                    b.HasAlternateKey("ReceitaId", "UserId");

                    b.ToTable("Historico");
                });

            modelBuilder.Entity("Cookle.Models.Ingrediente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(45);

                    b.HasKey("Id");

                    b.ToTable("Ingrediente");
                });

            modelBuilder.Entity("Cookle.Models.IngredienteReceita", b =>
                {
                    b.Property<int>("IngredienteId");

                    b.Property<int>("ReceitaId");

                    b.Property<float>("Quantidade");

                    b.Property<int>("Unidade");

                    b.HasKey("IngredienteId", "ReceitaId");

                    b.HasIndex("ReceitaId");

                    b.ToTable("IngredienteReceita");
                });

            modelBuilder.Entity("Cookle.Models.Nota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("ReceitaId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ReceitaId");

                    b.HasIndex("UserId");

                    b.ToTable("Nota");
                });

            modelBuilder.Entity("Cookle.Models.Nutriente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(45);

                    b.Property<int>("Unidade")
                        .HasMaxLength(2147483647);

                    b.HasKey("Id");

                    b.ToTable("Nutriente");
                });

            modelBuilder.Entity("Cookle.Models.NutrienteReceita", b =>
                {
                    b.Property<int>("NutrienteId");

                    b.Property<int>("ReceitaId");

                    b.Property<int?>("NutrienteId1");

                    b.Property<float>("Quantidade");

                    b.HasKey("NutrienteId", "ReceitaId");

                    b.HasIndex("NutrienteId1");

                    b.HasIndex("ReceitaId");

                    b.ToTable("NutrienteReceita");
                });

            modelBuilder.Entity("Cookle.Models.Passo", b =>
                {
                    b.Property<int>("Numero");

                    b.Property<int>("ReceitaId");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int?>("SubReceitaId");

                    b.HasKey("Numero", "ReceitaId");

                    b.HasIndex("ReceitaId");

                    b.HasIndex("SubReceitaId");

                    b.ToTable("Passo");
                });

            modelBuilder.Entity("Cookle.Models.Plano", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("ReceitaId");

                    b.HasKey("UserId", "ReceitaId");

                    b.HasAlternateKey("ReceitaId", "UserId");

                    b.ToTable("Plano");
                });

            modelBuilder.Entity("Cookle.Models.PreferenciaIngrediente", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("IngredienteId");

                    b.Property<int>("Tipo");

                    b.HasKey("UserId", "IngredienteId");

                    b.HasAlternateKey("IngredienteId", "UserId");

                    b.ToTable("PreferenciaIngrediente");
                });

            modelBuilder.Entity("Cookle.Models.Receita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<int?>("Dificuldade");

                    b.Property<string>("Imagem")
                        .HasMaxLength(45);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(45);

                    b.Property<int?>("NumPessoas");

                    b.Property<int?>("TempoPrep");

                    b.Property<int?>("Tipo");

                    b.Property<string>("Video")
                        .HasMaxLength(45);

                    b.HasKey("Id");

                    b.ToTable("Receita");
                });

            modelBuilder.Entity("Cookle.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<int>("Sexo");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<bool>("Voz");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Cookle.Models.Frigorifico", b =>
                {
                    b.HasOne("Cookle.Models.Ingrediente", "Ingrediente")
                        .WithMany("Frigorificos")
                        .HasForeignKey("IngredienteId1");

                    b.HasOne("Cookle.Models.User", "User")
                        .WithMany("Frigorificos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Cookle.Models.Historico", b =>
                {
                    b.HasOne("Cookle.Models.Receita", "Receita")
                        .WithMany("Historicos")
                        .HasForeignKey("ReceitaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Cookle.Models.User", "User")
                        .WithMany("Historicos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Cookle.Models.IngredienteReceita", b =>
                {
                    b.HasOne("Cookle.Models.Ingrediente", "Ingrediente")
                        .WithMany("IngredienteReceitas")
                        .HasForeignKey("IngredienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Cookle.Models.Receita", "Receita")
                        .WithMany("IngredienteReceitas")
                        .HasForeignKey("ReceitaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Cookle.Models.Nota", b =>
                {
                    b.HasOne("Cookle.Models.Receita", "Receita")
                        .WithMany("Notas")
                        .HasForeignKey("ReceitaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Cookle.Models.User", "User")
                        .WithMany("Notas")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Cookle.Models.NutrienteReceita", b =>
                {
                    b.HasOne("Cookle.Models.Nutriente", "Nutriente")
                        .WithMany("NutrienteReceitas")
                        .HasForeignKey("NutrienteId1");

                    b.HasOne("Cookle.Models.Receita", "Receita")
                        .WithMany("NutrienteReceitas")
                        .HasForeignKey("ReceitaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Cookle.Models.Passo", b =>
                {
                    b.HasOne("Cookle.Models.Receita", "Receita")
                        .WithMany("Passos")
                        .HasForeignKey("ReceitaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Cookle.Models.Receita", "SubReceita")
                        .WithMany("SubReceitas")
                        .HasForeignKey("SubReceitaId");
                });

            modelBuilder.Entity("Cookle.Models.Plano", b =>
                {
                    b.HasOne("Cookle.Models.Receita", "Receita")
                        .WithMany("Planos")
                        .HasForeignKey("ReceitaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Cookle.Models.User", "User")
                        .WithMany("Planos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Cookle.Models.PreferenciaIngrediente", b =>
                {
                    b.HasOne("Cookle.Models.Ingrediente", "Ingrediente")
                        .WithMany("PreferenciaIngredientes")
                        .HasForeignKey("IngredienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Cookle.Models.User", "User")
                        .WithMany("PreferenciaIngredientes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Cookle.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Cookle.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Cookle.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Cookle.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

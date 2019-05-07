using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cookle.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingrediente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingrediente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nutriente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 45, nullable: false),
                    Unidade = table.Column<int>(maxLength: 2147483647, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutriente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Receita",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 45, nullable: false),
                    Descricao = table.Column<string>(maxLength: 150, nullable: false),
                    TempoPrep = table.Column<int>(nullable: true),
                    NumPessoas = table.Column<int>(nullable: true),
                    Dificuldade = table.Column<int>(nullable: true),
                    Tipo = table.Column<int>(nullable: true),
                    Imagem = table.Column<string>(maxLength: 45, nullable: true),
                    Video = table.Column<string>(maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receita", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: false),
                    Username = table.Column<string>(maxLength: 45, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Sexo = table.Column<int>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Voz = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngredienteReceita",
                columns: table => new
                {
                    ReceitaId = table.Column<int>(nullable: false),
                    IngredienteId = table.Column<int>(nullable: false),
                    Quantidade = table.Column<float>(nullable: false),
                    Unidade = table.Column<int>(nullable: false),
                    IngredienteId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredienteReceita", x => new { x.IngredienteId, x.ReceitaId });
                    table.ForeignKey(
                        name: "FK_IngredienteReceita_Ingrediente_IngredienteId1",
                        column: x => x.IngredienteId1,
                        principalTable: "Ingrediente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IngredienteReceita_Receita_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NutrienteReceita",
                columns: table => new
                {
                    ReceitaId = table.Column<int>(nullable: false),
                    NutrienteId = table.Column<int>(nullable: false),
                    Quantidade = table.Column<float>(nullable: false),
                    NutrienteId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutrienteReceita", x => new { x.NutrienteId, x.ReceitaId });
                    table.ForeignKey(
                        name: "FK_NutrienteReceita_Nutriente_NutrienteId1",
                        column: x => x.NutrienteId1,
                        principalTable: "Nutriente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NutrienteReceita_Receita_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Passo",
                columns: table => new
                {
                    Numero = table.Column<int>(nullable: false),
                    ReceitaId = table.Column<int>(nullable: false),
                    SubReceitaId = table.Column<int>(nullable: true),
                    Descricao = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passo", x => new { x.Numero, x.ReceitaId });
                    table.ForeignKey(
                        name: "FK_Passo_Receita_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Passo_Receita_SubReceitaId",
                        column: x => x.SubReceitaId,
                        principalTable: "Receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Frigorifico",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    IngredienteId = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frigorifico", x => new { x.UserId, x.IngredienteId });
                    table.UniqueConstraint("AK_Frigorifico_IngredienteId_UserId", x => new { x.IngredienteId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Frigorifico_Ingrediente_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "Ingrediente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Frigorifico_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Historico",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ReceitaId = table.Column<int>(nullable: false),
                    UltimaVez = table.Column<DateTime>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    ReceitaId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historico", x => new { x.UserId, x.ReceitaId });
                    table.UniqueConstraint("AK_Historico_ReceitaId_UserId", x => new { x.ReceitaId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Historico_Receita_ReceitaId1",
                        column: x => x.ReceitaId1,
                        principalTable: "Receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Historico_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nota",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReceitaId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 50, nullable: false),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nota_Receita_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nota_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plano",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ReceitaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plano", x => new { x.UserId, x.ReceitaId });
                    table.UniqueConstraint("AK_Plano_ReceitaId_UserId", x => new { x.ReceitaId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Plano_Receita_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plano_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PreferenciaIngrediente",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    IngredienteId = table.Column<int>(nullable: false),
                    Tipo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferenciaIngrediente", x => new { x.UserId, x.IngredienteId });
                    table.UniqueConstraint("AK_PreferenciaIngrediente_IngredienteId_UserId", x => new { x.IngredienteId, x.UserId });
                    table.ForeignKey(
                        name: "FK_PreferenciaIngrediente_Ingrediente_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "Ingrediente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreferenciaIngrediente_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Historico_ReceitaId1",
                table: "Historico",
                column: "ReceitaId1");

            migrationBuilder.CreateIndex(
                name: "IX_IngredienteReceita_IngredienteId1",
                table: "IngredienteReceita",
                column: "IngredienteId1");

            migrationBuilder.CreateIndex(
                name: "IX_IngredienteReceita_ReceitaId",
                table: "IngredienteReceita",
                column: "ReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_ReceitaId",
                table: "Nota",
                column: "ReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_UserId",
                table: "Nota",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NutrienteReceita_NutrienteId1",
                table: "NutrienteReceita",
                column: "NutrienteId1");

            migrationBuilder.CreateIndex(
                name: "IX_NutrienteReceita_ReceitaId",
                table: "NutrienteReceita",
                column: "ReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Passo_ReceitaId",
                table: "Passo",
                column: "ReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Passo_SubReceitaId",
                table: "Passo",
                column: "SubReceitaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Frigorifico");

            migrationBuilder.DropTable(
                name: "Historico");

            migrationBuilder.DropTable(
                name: "IngredienteReceita");

            migrationBuilder.DropTable(
                name: "Nota");

            migrationBuilder.DropTable(
                name: "NutrienteReceita");

            migrationBuilder.DropTable(
                name: "Passo");

            migrationBuilder.DropTable(
                name: "Plano");

            migrationBuilder.DropTable(
                name: "PreferenciaIngrediente");

            migrationBuilder.DropTable(
                name: "Nutriente");

            migrationBuilder.DropTable(
                name: "Receita");

            migrationBuilder.DropTable(
                name: "Ingrediente");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}

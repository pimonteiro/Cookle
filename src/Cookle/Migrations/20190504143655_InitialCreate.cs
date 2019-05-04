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
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(maxLength: 45, nullable: false),
                    Password = table.Column<string>(maxLength: 45, nullable: false),
                    Name = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

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
                name: "Pais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Receita",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 45, nullable: false),
                    Descricao = table.Column<string>(maxLength: 150, nullable: false),
                    TempoPrep = table.Column<int>(maxLength: 2147483647, nullable: true),
                    NumPessoas = table.Column<int>(maxLength: 2147483647, nullable: true),
                    Dificuldade = table.Column<int>(maxLength: 2147483647, nullable: true),
                    Tipo = table.Column<int>(maxLength: 2147483647, nullable: true),
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
                    Email = table.Column<string>(maxLength: 45, nullable: false),
                    Username = table.Column<string>(maxLength: 45, nullable: false),
                    Password = table.Column<string>(maxLength: 45, nullable: false),
                    Sexo = table.Column<int>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Voz = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passo",
                columns: table => new
                {
                    Numero = table.Column<int>(nullable: false),
                    Ingrediente = table.Column<int>(nullable: false),
                    SubReceita = table.Column<int>(nullable: true),
                    Descricao = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passo", x => new { x.Ingrediente, x.Numero });
                    table.ForeignKey(
                        name: "FK_Passo_Ingrediente_Ingrediente",
                        column: x => x.Ingrediente,
                        principalTable: "Ingrediente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Morada",
                columns: table => new
                {
                    Rua = table.Column<string>(nullable: false),
                    Cidade = table.Column<string>(nullable: false),
                    CodigoPostal = table.Column<string>(nullable: false),
                    Pais = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Morada", x => new { x.Rua, x.Cidade, x.Pais, x.CodigoPostal });
                    table.UniqueConstraint("AK_Morada_Cidade_CodigoPostal_Pais_Rua", x => new { x.Cidade, x.CodigoPostal, x.Pais, x.Rua });
                    table.ForeignKey(
                        name: "FK_Morada_Pais_Pais",
                        column: x => x.Pais,
                        principalTable: "Pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredienteReceita",
                columns: table => new
                {
                    Receita = table.Column<int>(nullable: false),
                    Ingrediente = table.Column<int>(nullable: false),
                    Quantidade = table.Column<float>(maxLength: 2147483647, nullable: false),
                    Unidade = table.Column<int>(maxLength: 2147483647, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredienteReceita", x => new { x.Ingrediente, x.Receita });
                    table.ForeignKey(
                        name: "FK_IngredienteReceita_Ingrediente_Ingrediente",
                        column: x => x.Ingrediente,
                        principalTable: "Ingrediente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredienteReceita_Receita_Receita",
                        column: x => x.Receita,
                        principalTable: "Receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NutrienteReceita",
                columns: table => new
                {
                    Receita = table.Column<int>(nullable: false),
                    Nutriente = table.Column<int>(nullable: false),
                    Quantidade = table.Column<float>(maxLength: 2147483647, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutrienteReceita", x => new { x.Nutriente, x.Receita });
                    table.ForeignKey(
                        name: "FK_NutrienteReceita_Nutriente_Nutriente",
                        column: x => x.Nutriente,
                        principalTable: "Nutriente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NutrienteReceita_Receita_Receita",
                        column: x => x.Receita,
                        principalTable: "Receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Frigorifico",
                columns: table => new
                {
                    User = table.Column<int>(nullable: false),
                    Ingrediente = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(maxLength: 2147483647, nullable: false),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frigorifico", x => new { x.User, x.Ingrediente });
                    table.UniqueConstraint("AK_Frigorifico_Ingrediente_User", x => new { x.Ingrediente, x.User });
                    table.ForeignKey(
                        name: "FK_Frigorifico_Ingrediente_Ingrediente",
                        column: x => x.Ingrediente,
                        principalTable: "Ingrediente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Frigorifico_User_User",
                        column: x => x.User,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Historico",
                columns: table => new
                {
                    User = table.Column<int>(nullable: false),
                    Receita = table.Column<int>(nullable: false),
                    UltimaVez = table.Column<DateTime>(nullable: false),
                    Numero = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historico", x => new { x.User, x.Receita });
                    table.UniqueConstraint("AK_Historico_Receita_User", x => new { x.Receita, x.User });
                    table.ForeignKey(
                        name: "FK_Historico_Receita_Receita",
                        column: x => x.Receita,
                        principalTable: "Receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Historico_User_User",
                        column: x => x.User,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nota",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Receita = table.Column<int>(nullable: false),
                    User = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 50, nullable: false),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nota", x => new { x.User, x.Receita, x.Id });
                    table.UniqueConstraint("AK_Nota_Id_Receita_User", x => new { x.Id, x.Receita, x.User });
                    table.ForeignKey(
                        name: "FK_Nota_Receita_Receita",
                        column: x => x.Receita,
                        principalTable: "Receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nota_User_User",
                        column: x => x.User,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plano",
                columns: table => new
                {
                    User = table.Column<int>(nullable: false),
                    Receita = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plano", x => new { x.User, x.Receita });
                    table.UniqueConstraint("AK_Plano_Receita_User", x => new { x.Receita, x.User });
                    table.ForeignKey(
                        name: "FK_Plano_Receita_Receita",
                        column: x => x.Receita,
                        principalTable: "Receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plano_User_User",
                        column: x => x.User,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PreferenciaIngrediente",
                columns: table => new
                {
                    User = table.Column<int>(nullable: false),
                    Ingrediente = table.Column<int>(nullable: false),
                    Tipo = table.Column<int>(maxLength: 2147483647, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferenciaIngrediente", x => new { x.User, x.Ingrediente });
                    table.UniqueConstraint("AK_PreferenciaIngrediente_Ingrediente_User", x => new { x.Ingrediente, x.User });
                    table.ForeignKey(
                        name: "FK_PreferenciaIngrediente_Ingrediente_Ingrediente",
                        column: x => x.Ingrediente,
                        principalTable: "Ingrediente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreferenciaIngrediente_User_User",
                        column: x => x.User,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredienteReceita_Receita",
                table: "IngredienteReceita",
                column: "Receita");

            migrationBuilder.CreateIndex(
                name: "IX_Morada_Pais",
                table: "Morada",
                column: "Pais");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_Receita",
                table: "Nota",
                column: "Receita");

            migrationBuilder.CreateIndex(
                name: "IX_NutrienteReceita_Receita",
                table: "NutrienteReceita",
                column: "Receita");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Frigorifico");

            migrationBuilder.DropTable(
                name: "Historico");

            migrationBuilder.DropTable(
                name: "IngredienteReceita");

            migrationBuilder.DropTable(
                name: "Morada");

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
                name: "Pais");

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

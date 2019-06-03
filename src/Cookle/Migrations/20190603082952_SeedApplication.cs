using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cookle.Migrations
{
    public partial class SeedApplication : Migration
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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Sexo = table.Column<int>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Voz = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
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
                name: "Receita",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 500, nullable: false),
                    Descricao = table.Column<string>(maxLength: 500, nullable: false),
                    TempoPrep = table.Column<int>(nullable: true),
                    NumPessoas = table.Column<int>(nullable: true),
                    Dificuldade = table.Column<int>(nullable: true),
                    Tipo = table.Column<int>(nullable: true),
                    Imagem = table.Column<string>(maxLength: 500, nullable: true),
                    Video = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receita", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Frigorifico",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    IngredienteId = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    IngredienteId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frigorifico", x => new { x.UserId, x.IngredienteId });
                    table.UniqueConstraint("AK_Frigorifico_IngredienteId_UserId", x => new { x.IngredienteId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Frigorifico_Ingrediente_IngredienteId1",
                        column: x => x.IngredienteId1,
                        principalTable: "Ingrediente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Frigorifico_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
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
                        name: "FK_PreferenciaIngrediente_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
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
                    Numero = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historico", x => new { x.UserId, x.ReceitaId });
                    table.UniqueConstraint("AK_Historico_ReceitaId_UserId", x => new { x.ReceitaId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Historico_Receita_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Historico_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredienteReceita",
                columns: table => new
                {
                    ReceitaId = table.Column<int>(nullable: false),
                    IngredienteId = table.Column<int>(nullable: false),
                    Quantidade = table.Column<float>(nullable: false),
                    Unidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredienteReceita", x => new { x.IngredienteId, x.ReceitaId });
                    table.ForeignKey(
                        name: "FK_IngredienteReceita_Ingrediente_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "Ingrediente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredienteReceita_Receita_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receita",
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
                        name: "FK_Nota_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
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
                    Descricao = table.Column<string>(maxLength: 500, nullable: false)
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
                        name: "FK_Plano_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 1, "admin@admin.pt", "Admin", "admin123" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataNascimento", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sexo", "TwoFactorEnabled", "UserName", "Voz" },
                values: new object[] { 1, 0, "9e35f6da-236d-4d27-af5a-24b88c072799", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "test@gmail.com", true, false, null, "TEST@GMAIL.COM", "TEST", "AQAAAAEAACcQAAAAEMXE74M7Y0V/YP1TPuLJuZ7gNZ8zFbyzIb1nUzrb5dpVWgOWqaH0YZDipbF3PO2Rng==", null, false, "", 0, false, "Test", false });

            migrationBuilder.InsertData(
                table: "Ingrediente",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 2, "manteiga" },
                    { 12, "oleo vegetal" },
                    { 11, "sal" },
                    { 1, "ovos" },
                    { 8, "açúcar em pó" },
                    { 10, "leite" },
                    { 6, "fermento em pó" },
                    { 5, "óleo" },
                    { 4, "açúcar" },
                    { 3, "iogurte natural" },
                    { 7, "farinha" },
                    { 9, "farinha de trigo" }
                });

            migrationBuilder.InsertData(
                table: "Nutriente",
                columns: new[] { "Id", "Nome", "Unidade" },
                values: new object[,]
                {
                    { 1, "Proteína", 1 },
                    { 2, "Hidratos de carbono", 0 }
                });

            migrationBuilder.InsertData(
                table: "Receita",
                columns: new[] { "Id", "Descricao", "Dificuldade", "Imagem", "Nome", "NumPessoas", "TempoPrep", "Tipo", "Video" },
                values: new object[,]
                {
                    { 3, "Uma massa simples mas deliciosa.", 1, null, "Massa de panquecas simples", 2, 15, null, null },
                    { 1, "Um dos bolos mais fáceis e saborosos.", 2, "https://www.pingodoce.pt/wp-content/uploads/2016/03/comofazerbolodeiogurte617.jpg", "Bolo de iogurte", 10, 55, null, null },
                    { 2, "A forma mais fácil de bater claras em castelo, para que os seus bolos fiquem perfeitos.", 1, "https://i1.wp.com/www.docesregionais.com/wp-content/uploads/2013/02/Como-Bater-Claras-em-NeveCastelo.jpg", "Claras em Castelo", null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Frigorifico",
                columns: new[] { "UserId", "IngredienteId", "Data", "IngredienteId1", "Quantidade" },
                values: new object[] { 1, 1, new DateTime(2019, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3 });

            migrationBuilder.InsertData(
                table: "Historico",
                columns: new[] { "UserId", "ReceitaId", "Numero", "UltimaVez" },
                values: new object[] { 1, 1, 1, new DateTime(2019, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "IngredienteReceita",
                columns: new[] { "IngredienteId", "ReceitaId", "Quantidade", "Unidade" },
                values: new object[,]
                {
                    { 1, 3, 1f, 0 },
                    { 11, 3, 2f, 1 },
                    { 12, 3, 1.5f, 1 },
                    { 1, 2, 2f, 0 },
                    { 9, 3, 1f, 1 },
                    { 1, 1, 4f, 0 },
                    { 5, 1, 0.25f, 2 },
                    { 2, 1, 1f, 1 },
                    { 3, 1, 1f, 1 },
                    { 4, 1, 3f, 1 },
                    { 8, 1, 2f, 1 },
                    { 10, 3, 1f, 2 },
                    { 6, 1, 2f, 1 },
                    { 7, 1, 2f, 1 }
                });

            migrationBuilder.InsertData(
                table: "Nota",
                columns: new[] { "Id", "Data", "Descricao", "ReceitaId", "UserId" },
                values: new object[] { 1, new DateTime(2019, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acrescentar mais açucar na próxima confeção.", 1, 1 });

            migrationBuilder.InsertData(
                table: "NutrienteReceita",
                columns: new[] { "NutrienteId", "ReceitaId", "NutrienteId1", "Quantidade" },
                values: new object[,]
                {
                    { 1, 3, null, 3f },
                    { 2, 3, null, 60.3f },
                    { 2, 1, null, 5f },
                    { 1, 1, null, 3f }
                });

            migrationBuilder.InsertData(
                table: "Passo",
                columns: new[] { "Numero", "ReceitaId", "Descricao", "SubReceitaId" },
                values: new object[,]
                {
                    { 4, 3, "Espere até a massa se soltar do fundo, vire e deixe fritar do outro lado.", null },
                    { 3, 3, "Faça movimentos circulares para que a massa se espalhe por toda a frigideira.", null },
                    { 2, 3, "Unte uma frigideira com óleo e despeje uma concha de massa.", null },
                    { 1, 3, "Bata todos os ingredientes no liquidificador até obter uma consistência cremosa.", null },
                    { 5, 3, "Acrescente o recheio de sua preferência, enrole e está pronta para servir.", null },
                    { 2, 2, "Coloque-as no copo da batedeira.", null },
                    { 4, 2, "Caso seja necessário, bata mais 3 minutos até obter a consistência de neve.", null },
                    { 3, 2, "Bata em velocidade mínima durante 7 minutos.", 2 },
                    { 1, 2, "Separe as claras das gemas.", null },
                    { 3, 1, "Bata as claras em castelo e reserve numa taça.", 2 },
                    { 7, 1, " Retire do forno e deixe arrefecer ligeiramente antes de desenformar. Antes de servir, polvilhe com o açúcar em pó.", null },
                    { 6, 1, "Deite a massa na forma de chaminé, previamente untada, e leve ao forno durante 40 a 45 minutos, ou espete um palito na massa e verifique se sai limpo.", null },
                    { 5, 1, "Junte as claras e bata com uma batedeira até a massa estar homogénea.", null },
                    { 4, 1, "Numa taça, adicione o iogurte e as gemas de ovo. Utilize a medida do copo de iogurte e adicione o açúcar, o óleo, a farinha e o fermento.", null },
                    { 2, 1, "Unte uma forma de chaminé com manteiga e reserve.", null },
                    { 1, 1, "Pre-aqueça o forno a 180º C.", null },
                    { 5, 2, "Para verificar se as claras estão no ponto, vire o recipiente ao contrário e, se permanecerem no fundo, sem cair, estão perfeitas.", null }
                });

            migrationBuilder.InsertData(
                table: "Plano",
                columns: new[] { "UserId", "ReceitaId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "PreferenciaIngrediente",
                columns: new[] { "UserId", "IngredienteId", "Tipo" },
                values: new object[] { 1, 1, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Frigorifico_IngredienteId1",
                table: "Frigorifico",
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
                name: "Admin");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Nutriente");

            migrationBuilder.DropTable(
                name: "Receita");

            migrationBuilder.DropTable(
                name: "Ingrediente");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}

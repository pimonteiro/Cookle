using Microsoft.EntityFrameworkCore.Migrations;

namespace Cookle.Migrations
{
    public partial class FirstSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "54f21e1f-d572-42c6-b1c3-d354496aecc8", "AQAAAAEAACcQAAAAEKQHJYtdg65vcWdsQg554lundBXxA7Nb2VjsBCjj4gQQI0nZRHHkgGmlZtqSQ5JOrA==" });

            migrationBuilder.UpdateData(
                table: "Receita",
                keyColumn: "Id",
                keyValue: 1,
                column: "Descricao",
                value: "Um dos bolos mais fáceis e saborosos.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "33f85e0a-d4f6-401b-9fd2-c6297c4b10ed", "AQAAAAEAACcQAAAAEPWOgRifs/YHzKH+zzGNZ4BM1jPyAY5V1/SNbwV3E3tK8wz91bnocF2ndkQcCzgHFQ==" });

            migrationBuilder.UpdateData(
                table: "Receita",
                keyColumn: "Id",
                keyValue: 1,
                column: "Descricao",
                value: "Um dos bolos mais fáceis e saborosos - e uma receita muito indicada para ensinar às crianças. Pode ser feito com iogurte natural ou de qualquer sabor e é óptimo para o lanche.");
        }
    }
}

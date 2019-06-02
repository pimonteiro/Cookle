using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cookle.Migrations
{
    public partial class FirstSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataNascimento", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sexo", "TwoFactorEnabled", "UserName", "Voz" },
                values: new object[] { 1, 0, "33f85e0a-d4f6-401b-9fd2-c6297c4b10ed", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "test@gmail.com", true, false, null, "TEST@GMAIL.COM", "TEST", "AQAAAAEAACcQAAAAEPWOgRifs/YHzKH+zzGNZ4BM1jPyAY5V1/SNbwV3E3tK8wz91bnocF2ndkQcCzgHFQ==", null, false, "", 0, false, "Test", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

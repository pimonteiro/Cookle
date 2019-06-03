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
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "3e15a845-2afc-4473-b592-0ed57274fc36", "test@gmail.com", "test@gmail.com", "AQAAAAEAACcQAAAAEFlbOOj1LhAyQr4/mN8GZIsC1D8etvvISS2pHWzNTbhjFQaLhS1JfucX4vHz2U/Cmw==", "test@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "9e35f6da-236d-4d27-af5a-24b88c072799", "TEST@GMAIL.COM", "TEST", "AQAAAAEAACcQAAAAEMXE74M7Y0V/YP1TPuLJuZ7gNZ8zFbyzIb1nUzrb5dpVWgOWqaH0YZDipbF3PO2Rng==", "Test" });
        }
    }
}

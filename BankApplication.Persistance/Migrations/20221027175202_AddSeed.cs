using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApplication.Persistance.Migrations
{
    public partial class AddSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BankAccounts",
                columns: new[] { "Id", "AccountBalance" },
                values: new object[] { 1, 7654m });

            migrationBuilder.InsertData(
                table: "CashMachines",
                columns: new[] { "Id", "Banknote10", "Banknote100", "Banknote20", "Banknote200", "Banknote50" },
                values: new object[] { 1, 5, 5, 5, 5, 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BankAccounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CashMachines",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

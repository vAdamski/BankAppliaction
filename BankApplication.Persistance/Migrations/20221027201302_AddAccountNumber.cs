using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApplication.Persistance.Migrations
{
    public partial class AddAccountNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "BankAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "BankAccounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "AccountNumber",
                value: "3019075149919263436240");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "BankAccounts");
        }
    }
}

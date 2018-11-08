using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class UpdateEmp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Patronymic",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Employees",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Patronymic",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Employees");
        }
    }
}

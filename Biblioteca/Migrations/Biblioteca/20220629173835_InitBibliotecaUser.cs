using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.Migrations.Biblioteca
{
    public partial class InitBibliotecaUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DNI",
                table: "AspNetUsers",
                maxLength: 9,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NombreApellido",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DNI",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NombreApellido",
                table: "AspNetUsers");
        }
    }
}

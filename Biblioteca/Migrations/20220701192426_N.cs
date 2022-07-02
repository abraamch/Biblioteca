using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.Migrations
{
    public partial class N : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AutorLibro",
                table: "LibrosDeUsuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TapaLibro",
                table: "LibrosDeUsuarios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutorLibro",
                table: "LibrosDeUsuarios");

            migrationBuilder.DropColumn(
                name: "TapaLibro",
                table: "LibrosDeUsuarios");
        }
    }
}

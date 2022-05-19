using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsempioEreditarietaFA.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Reporto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroDipendenti = table.Column<int>(type: "int", nullable: true),
                    AnniServizio = table.Column<int>(type: "int", nullable: true),
                    Eta = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persona");
        }
    }
}

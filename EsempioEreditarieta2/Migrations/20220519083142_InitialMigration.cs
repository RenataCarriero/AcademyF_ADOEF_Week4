using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsempioEreditarieta2.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dirigente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Reporto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDipendenti = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dirigente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dirigente_People_Id",
                        column: x => x.Id,
                        principalTable: "People",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Impiegato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AnniServizio = table.Column<int>(type: "int", nullable: false),
                    Eta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Impiegato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Impiegato_People_Id",
                        column: x => x.Id,
                        principalTable: "People",
                        principalColumn: "Id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dirigente");

            migrationBuilder.DropTable(
                name: "Impiegato");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}

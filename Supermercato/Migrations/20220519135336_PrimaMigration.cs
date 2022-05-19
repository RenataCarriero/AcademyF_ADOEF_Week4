using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Supermercato.Migrations
{
    public partial class PrimaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reparto",
                columns: table => new
                {
                    NumeroReparto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reparto", x => x.NumeroReparto);
                });

            migrationBuilder.CreateTable(
                name: "Dipendente",
                columns: table => new
                {
                    Codice = table.Column<string>(type: "nchar(5)", fixedLength: true, maxLength: 5, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RepartoNumero = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dipendente", x => x.Codice);
                    table.ForeignKey(
                        name: "FK_Dipendente_Reparto_RepartoNumero",
                        column: x => x.RepartoNumero,
                        principalTable: "Reparto",
                        principalColumn: "NumeroReparto");
                });

            migrationBuilder.CreateTable(
                name: "Prodotto",
                columns: table => new
                {
                    Codice = table.Column<string>(type: "nchar(5)", fixedLength: true, maxLength: 5, nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezzo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RepartoNumero = table.Column<int>(type: "int", nullable: false),
                    prodotto_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataScadenza = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Marchio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodotto", x => x.Codice);
                    table.ForeignKey(
                        name: "FK_Prodotto_Reparto_RepartoNumero",
                        column: x => x.RepartoNumero,
                        principalTable: "Reparto",
                        principalColumn: "NumeroReparto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendita",
                columns: table => new
                {
                    NumeroVendita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantita = table.Column<int>(type: "int", nullable: false),
                    DataVendita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodiceProdotto = table.Column<string>(type: "nchar(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendita", x => x.NumeroVendita);
                    table.ForeignKey(
                        name: "FK_Vendita_Prodotto_CodiceProdotto",
                        column: x => x.CodiceProdotto,
                        principalTable: "Prodotto",
                        principalColumn: "Codice",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dipendente_RepartoNumero",
                table: "Dipendente",
                column: "RepartoNumero");

            migrationBuilder.CreateIndex(
                name: "IX_Prodotto_RepartoNumero",
                table: "Prodotto",
                column: "RepartoNumero");

            migrationBuilder.CreateIndex(
                name: "IX_Vendita_CodiceProdotto",
                table: "Vendita",
                column: "CodiceProdotto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dipendente");

            migrationBuilder.DropTable(
                name: "Vendita");

            migrationBuilder.DropTable(
                name: "Prodotto");

            migrationBuilder.DropTable(
                name: "Reparto");
        }
    }
}

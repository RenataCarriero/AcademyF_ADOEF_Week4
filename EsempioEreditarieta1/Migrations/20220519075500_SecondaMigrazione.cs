using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsempioEreditarieta1.Migrations
{
    public partial class SecondaMigrazione : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Eta",
                table: "People",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Eta",
                table: "People");
        }
    }
}

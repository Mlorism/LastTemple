using Microsoft.EntityFrameworkCore.Migrations;

namespace LastTemple.Migrations
{
    public partial class Strengthmisspelledcorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Strenght",
                table: "Spells");

            migrationBuilder.AddColumn<int>(
                name: "Strength",
                table: "Spells",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Strength",
                table: "Spells");

            migrationBuilder.AddColumn<int>(
                name: "Strenght",
                table: "Spells",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

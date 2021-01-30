using Microsoft.EntityFrameworkCore.Migrations;

namespace LastTemple.Migrations
{
    public partial class modelsimprovement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Strength",
                table: "Spells");

            migrationBuilder.AddColumn<int>(
                name: "ActionCost",
                table: "Spells",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Strenght",
                table: "Spells",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActionCost",
                table: "Items",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionCost",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "Strenght",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "ActionCost",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "Strength",
                table: "Spells",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

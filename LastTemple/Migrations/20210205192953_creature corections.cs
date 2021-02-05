using Microsoft.EntityFrameworkCore.Migrations;

namespace LastTemple.Migrations
{
    public partial class creaturecorections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Damage",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "BaseDamage",
                table: "Creatures");

            migrationBuilder.AddColumn<int>(
                name: "BaseDamage",
                table: "Weapons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxHP",
                table: "Creatures",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxMana",
                table: "Creatures",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseDamage",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "MaxHP",
                table: "Creatures");

            migrationBuilder.DropColumn(
                name: "MaxMana",
                table: "Creatures");

            migrationBuilder.AddColumn<int>(
                name: "Damage",
                table: "Weapons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BaseDamage",
                table: "Creatures",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

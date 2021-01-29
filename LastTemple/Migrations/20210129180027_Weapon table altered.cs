using Microsoft.EntityFrameworkCore.Migrations;

namespace LastTemple.Migrations
{
    public partial class Weapontablealtered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseActionCost",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "BaseDamage",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "BaseHitChance",
                table: "Weapons");

            migrationBuilder.AddColumn<int>(
                name: "ActionCost",
                table: "Weapons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Damage",
                table: "Weapons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HitChance",
                table: "Weapons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MagicDamage",
                table: "Weapons",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionCost",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "Damage",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "HitChance",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "MagicDamage",
                table: "Weapons");

            migrationBuilder.AddColumn<int>(
                name: "BaseActionCost",
                table: "Weapons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BaseDamage",
                table: "Weapons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BaseHitChance",
                table: "Weapons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

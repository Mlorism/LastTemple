using Microsoft.EntityFrameworkCore.Migrations;

namespace LastTemple.Migrations
{
    public partial class deletesupplies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Supplies",
                table: "Creatures");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Supplies",
                table: "Creatures",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

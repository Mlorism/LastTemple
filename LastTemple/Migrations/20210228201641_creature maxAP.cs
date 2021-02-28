using Microsoft.EntityFrameworkCore.Migrations;

namespace LastTemple.Migrations
{
    public partial class creaturemaxAP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxAP",
                table: "Creatures",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxAP",
                table: "Creatures");
        }
    }
}

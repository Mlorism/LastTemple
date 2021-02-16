using Microsoft.EntityFrameworkCore.Migrations;

namespace LastTemple.Migrations
{
    public partial class manytomanycreaturesitemsspells : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Creatures_CreatureId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Spells_Creatures_CreatureId",
                table: "Spells");

            migrationBuilder.DropIndex(
                name: "IX_Spells_CreatureId",
                table: "Spells");

            migrationBuilder.DropIndex(
                name: "IX_Items_CreatureId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CreatureId",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "CreatureId",
                table: "Items");

            migrationBuilder.CreateTable(
                name: "CreatureItem",
                columns: table => new
                {
                    CreaturesId = table.Column<int>(type: "int", nullable: false),
                    ItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureItem", x => new { x.CreaturesId, x.ItemsId });
                    table.ForeignKey(
                        name: "FK_CreatureItem_Creatures_CreaturesId",
                        column: x => x.CreaturesId,
                        principalTable: "Creatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreatureItem_Items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreatureSpell",
                columns: table => new
                {
                    CreaturesId = table.Column<int>(type: "int", nullable: false),
                    MagicBookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureSpell", x => new { x.CreaturesId, x.MagicBookId });
                    table.ForeignKey(
                        name: "FK_CreatureSpell_Creatures_CreaturesId",
                        column: x => x.CreaturesId,
                        principalTable: "Creatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreatureSpell_Spells_MagicBookId",
                        column: x => x.MagicBookId,
                        principalTable: "Spells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreatureItem_ItemsId",
                table: "CreatureItem",
                column: "ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureSpell_MagicBookId",
                table: "CreatureSpell",
                column: "MagicBookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreatureItem");

            migrationBuilder.DropTable(
                name: "CreatureSpell");

            migrationBuilder.AddColumn<int>(
                name: "CreatureId",
                table: "Spells",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatureId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Spells_CreatureId",
                table: "Spells",
                column: "CreatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CreatureId",
                table: "Items",
                column: "CreatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Creatures_CreatureId",
                table: "Items",
                column: "CreatureId",
                principalTable: "Creatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Spells_Creatures_CreatureId",
                table: "Spells",
                column: "CreatureId",
                principalTable: "Creatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

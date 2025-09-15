using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTLayer.Migrations
{
    /// <inheritdoc />
    public partial class gitinital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "specilzeations",
                columns: table => new
                {
                    specilizeId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    specilizeName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specilzeations", x => x.specilizeId);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    itemID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    specilizeID = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.itemID);
                    table.ForeignKey(
                        name: "FK_items_specilzeations_specilizeID",
                        column: x => x.specilizeID,
                        principalTable: "specilzeations",
                        principalColumn: "specilizeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_items_specilizeID",
                table: "items",
                column: "specilizeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "specilzeations");
        }
    }
}

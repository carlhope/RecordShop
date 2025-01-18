using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecordShop.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MusicGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "MusicProducts");

            migrationBuilder.AddColumn<string>(
                name: "Genres",
                table: "Albums",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumId = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "inventoryItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusicProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventoryItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventoryItems_MusicProducts_MusicProductId",
                        column: x => x.MusicProductId,
                        principalTable: "MusicProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_inventoryItems_MusicProductId",
                table: "inventoryItems",
                column: "MusicProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "inventoryItems");

            migrationBuilder.DropColumn(
                name: "Genres",
                table: "Albums");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "MusicProducts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}

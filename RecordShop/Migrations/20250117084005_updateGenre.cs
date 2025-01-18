using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecordShop.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateGenre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Genres_AlbumId",
                table: "Genres",
                column: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Albums_AlbumId",
                table: "Genres",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Albums_AlbumId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_AlbumId",
                table: "Genres");
        }
    }
}

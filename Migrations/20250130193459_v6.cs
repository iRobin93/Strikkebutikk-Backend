using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StrikkebutikkBackend.Migrations
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sizesJSON",
                table: "Products",
                newName: "sizes");

            migrationBuilder.RenameColumn(
                name: "productAlbumJSON",
                table: "Products",
                newName: "productAlbum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sizes",
                table: "Products",
                newName: "sizesJSON");

            migrationBuilder.RenameColumn(
                name: "productAlbum",
                table: "Products",
                newName: "productAlbumJSON");
        }
    }
}

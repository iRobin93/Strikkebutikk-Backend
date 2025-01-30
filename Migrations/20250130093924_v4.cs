using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StrikkebutikkBackend.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Products_patternId",
                table: "Products",
                column: "patternId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Patterns_patternId",
                table: "Products",
                column: "patternId",
                principalTable: "Patterns",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Patterns_patternId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_patternId",
                table: "Products");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StrikkebutikkBackend.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Patterns_patternId",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Patterns_patternId",
                table: "Products",
                column: "patternId",
                principalTable: "Patterns",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Patterns_patternId",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Patterns_patternId",
                table: "Products",
                column: "patternId",
                principalTable: "Patterns",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

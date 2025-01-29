using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StrikkebutikkBackend.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assortments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    yarnId = table.Column<int>(type: "int", nullable: false),
                    colorIds = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assortments", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assortments");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceProject.Migrations
{
    /// <inheritdoc />
    public partial class adjustCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CaetgoryName",
                table: "Categories",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "CaetgoryDescription",
                table: "Categories",
                newName: "CategoryDescription");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_CaetgoryName",
                table: "Categories",
                newName: "IX_Categories_CategoryName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "CaetgoryName");

            migrationBuilder.RenameColumn(
                name: "CategoryDescription",
                table: "Categories",
                newName: "CaetgoryDescription");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_CategoryName",
                table: "Categories",
                newName: "IX_Categories_CaetgoryName");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceProject.Migrations
{
    /// <inheritdoc />
    public partial class imageProductRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProductID",
                table: "Images",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductID",
                table: "Images",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Products_ProductID",
                table: "Images",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Products_ProductID",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ProductID",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Images");
        }
    }
}

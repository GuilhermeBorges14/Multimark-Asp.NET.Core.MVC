using Microsoft.EntityFrameworkCore.Migrations;

namespace Multimark.Migrations
{
    public partial class CategoriesForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Categories_CategorieId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategorieId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategorieId",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "CategoriesId",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoriesId",
                table: "Product",
                column: "CategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Categories_CategoriesId",
                table: "Product",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Categories_CategoriesId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoriesId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategoriesId",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "CategorieId",
                table: "Product",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategorieId",
                table: "Product",
                column: "CategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Categories_CategorieId",
                table: "Product",
                column: "CategorieId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

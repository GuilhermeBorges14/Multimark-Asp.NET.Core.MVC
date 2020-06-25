using Microsoft.EntityFrameworkCore.Migrations;

namespace Multimark.Migrations
{
    public partial class new12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemSales_Sales_SalesId",
                table: "ItemSales");

            migrationBuilder.DropIndex(
                name: "IX_ItemSales_SalesId",
                table: "ItemSales");

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "SalesRecords",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "SalesRecords");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSales_SalesId",
                table: "ItemSales",
                column: "SalesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSales_Sales_SalesId",
                table: "ItemSales",
                column: "SalesId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

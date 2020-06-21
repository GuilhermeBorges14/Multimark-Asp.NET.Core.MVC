using Microsoft.EntityFrameworkCore.Migrations;

namespace Multimark.Migrations
{
    public partial class Itemsales1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "SubTotal",
                table: "ItemSale",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubTotal",
                table: "ItemSale");
        }
    }
}

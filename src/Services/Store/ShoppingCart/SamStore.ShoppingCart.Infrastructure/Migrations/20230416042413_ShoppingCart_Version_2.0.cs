using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamStore.ShoppingCart.Infrastructure.Migrations
{
    public partial class ShoppingCart_Version_20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "total",
                table: "cart");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "total",
                table: "cart",
                type: "DECIMAL(65,4)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamStore.Order.Infrastructure.Migrations
{
    public partial class Order_Version_20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_active",
                table: "voucher");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "voucher",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamStore.ShoppingCart.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingCart_Version_40 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IDX_Costumer",
                table: "cart",
                newName: "ix_cart_costumer_id");

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "cart_item",
                type: "DECIMAL(65,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(65,4)");

            migrationBuilder.AddColumn<decimal>(
                name: "voucher_discount",
                table: "cart",
                type: "DECIMAL(10,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "voucher_discount_type",
                table: "cart",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "voucher_key",
                table: "cart",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "voucher_used",
                table: "cart",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "voucher_discount",
                table: "cart");

            migrationBuilder.DropColumn(
                name: "voucher_discount_type",
                table: "cart");

            migrationBuilder.DropColumn(
                name: "voucher_key",
                table: "cart");

            migrationBuilder.DropColumn(
                name: "voucher_used",
                table: "cart");

            migrationBuilder.RenameIndex(
                name: "ix_cart_costumer_id",
                table: "cart",
                newName: "IDX_Costumer");

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "cart_item",
                type: "DECIMAL(65,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(65,2)");
        }
    }
}

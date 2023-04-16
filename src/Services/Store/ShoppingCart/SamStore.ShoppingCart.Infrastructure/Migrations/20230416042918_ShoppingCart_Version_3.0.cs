using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamStore.ShoppingCart.Infrastructure.Migrations
{
    public partial class ShoppingCart_Version_30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "image",
                table: "cart_item",
                type: "VARCHAR(100)",
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "cart_item",
                keyColumn: "image",
                keyValue: null,
                column: "image",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "image",
                table: "cart_item",
                type: "VARCHAR(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldNullable: true,
                oldDefaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}

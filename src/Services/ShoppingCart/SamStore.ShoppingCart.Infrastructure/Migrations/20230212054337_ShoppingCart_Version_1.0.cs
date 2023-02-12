using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamStore.ShoppingCart.Infrastructure.Migrations
{
    public partial class ShoppingCart_Version_10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "shopping_cart_costumer",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    costumer_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    total = table.Column<decimal>(type: "DECIMAL(65,4)", nullable: false),
                    created_at = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    altered_at = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    removed = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_shopping_cart_costumer", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "shopping_cart_items",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    product_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    shopping_cart_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    name = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "DECIMAL(65,4)", nullable: false),
                    image = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    altered_at = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    removed = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_shopping_cart_items", x => x.id);
                    table.ForeignKey(
                        name: "fk_shopping_cart_items_shopping_cart_costumers_shopping_cart_id",
                        column: x => x.shopping_cart_id,
                        principalTable: "shopping_cart_costumer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IDX_Costumer",
                table: "shopping_cart_costumer",
                column: "costumer_id");

            migrationBuilder.CreateIndex(
                name: "ix_shopping_cart_items_shopping_cart_id",
                table: "shopping_cart_items",
                column: "shopping_cart_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shopping_cart_items");

            migrationBuilder.DropTable(
                name: "shopping_cart_costumer");
        }
    }
}

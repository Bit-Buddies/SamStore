using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamStore.Order.Infrastructure.Migrations
{
    public partial class Order_Version_10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    created_at = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    altered_at = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    removed = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "voucher",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    key = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    voucher_discount_type = table.Column<int>(type: "int", nullable: false),
                    voucher_type = table.Column<int>(type: "int", nullable: false),
                    discount = table.Column<decimal>(type: "DECIMAL(65,4)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    quantity_used = table.Column<int>(type: "int", nullable: false),
                    expire_at = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    created_at = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    altered_at = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    removed = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_voucher", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "vouchers_orders",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    voucher_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    order_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    created_at = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    altered_at = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    removed = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vouchers_orders", x => x.id);
                    table.ForeignKey(
                        name: "fk_vouchers_orders_order_order_id",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vouchers_orders_vouchers_voucher_id",
                        column: x => x.voucher_id,
                        principalTable: "voucher",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "ix_voucher_key",
                table: "voucher",
                column: "key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_vouchers_orders_order_id",
                table: "vouchers_orders",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "ix_vouchers_orders_voucher_id",
                table: "vouchers_orders",
                column: "voucher_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vouchers_orders");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "voucher");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamStore.Catalog.API.Migrations
{
    public partial class Catalog_Version_30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("370e46af-9e46-4691-8482-788a10ca6e1d"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("4c8419c0-17fa-4f88-9b41-e74d4a1d1e67"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("8433b7da-f9a3-4528-9ca0-34c114a835c8"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("8fc34042-dc07-4afa-a0fb-db5b44abc556"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("a30f2b54-c049-4736-9823-120ca90f557f"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("d56f3525-27ef-40af-a234-50e5703acee1"));

            migrationBuilder.DropColumn(
                name: "image",
                table: "product");

            migrationBuilder.CreateTable(
                name: "product_image",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    product_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    name = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    path = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    order = table.Column<int>(type: "int", nullable: false),
                    hash = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    altered_at = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    removed = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_image", x => x.id);
                    table.ForeignKey(
                        name: "fk_product_image_products_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "altered_at", "created_at", "description", "name", "quantity", "removed", "value" },
                values: new object[,]
                {
                    { new Guid("1da9ab98-ce07-43a4-91dc-c99dec79deb9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição", "Vilé Toustã", 0, false, 229.99m },
                    { new Guid("58f4441c-b9e0-4d8d-8148-9b11b1fb0b66"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição", "Omêga", 0, false, 259.99m },
                    { new Guid("643a94a4-c5e9-4d01-ae3c-acd22fa2170e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição", "Frankfourd Stoitelle", 0, false, 129.99m },
                    { new Guid("77b5a0ae-3255-4d48-b2e3-45f4551d7c1b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição", "Fiarrut", 0, false, 349.99m },
                    { new Guid("b1e3b390-f8b4-4788-9d01-52e7fb8e3727"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição", "Scarlatte", 0, false, 629.99m },
                    { new Guid("c5a9c4df-f29c-4f82-ad30-d4e7d435f626"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição", "Gonjour Lamari", 0, false, 559.99m }
                });

            migrationBuilder.CreateIndex(
                name: "ix_product_image_product_id",
                table: "product_image",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_image_product_id_name",
                table: "product_image",
                columns: new[] { "product_id", "name" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product_image");

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("1da9ab98-ce07-43a4-91dc-c99dec79deb9"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("58f4441c-b9e0-4d8d-8148-9b11b1fb0b66"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("643a94a4-c5e9-4d01-ae3c-acd22fa2170e"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("77b5a0ae-3255-4d48-b2e3-45f4551d7c1b"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("b1e3b390-f8b4-4788-9d01-52e7fb8e3727"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("c5a9c4df-f29c-4f82-ad30-d4e7d435f626"));

            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "product",
                type: "VARCHAR(100)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "altered_at", "created_at", "description", "image", "name", "quantity", "removed", "value" },
                values: new object[,]
                {
                    { new Guid("370e46af-9e46-4691-8482-788a10ca6e1d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição", "", "Gonjour Lamari", 0, false, 559.99m },
                    { new Guid("4c8419c0-17fa-4f88-9b41-e74d4a1d1e67"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição", "", "Frankfourd Stoitelle", 0, false, 129.99m },
                    { new Guid("8433b7da-f9a3-4528-9ca0-34c114a835c8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição", "", "Omêga", 0, false, 259.99m },
                    { new Guid("8fc34042-dc07-4afa-a0fb-db5b44abc556"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição", "", "Vilé Toustã", 0, false, 229.99m },
                    { new Guid("a30f2b54-c049-4736-9823-120ca90f557f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição", "", "Fiarrut", 0, false, 349.99m },
                    { new Guid("d56f3525-27ef-40af-a234-50e5703acee1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição", "", "Scarlatte", 0, false, 629.99m }
                });
        }
    }
}

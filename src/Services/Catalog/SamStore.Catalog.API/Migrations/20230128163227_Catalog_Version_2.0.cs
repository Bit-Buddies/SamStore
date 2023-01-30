using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamStore.Catalog.API.Migrations
{
    public partial class Catalog_Version_20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamStore.Costumer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Customer_Version_20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_customer_cpf",
                table: "customer",
                column: "cpf",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_customer_cpf",
                table: "customer");
        }
    }
}

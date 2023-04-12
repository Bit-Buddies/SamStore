using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SamStore.Catalog.API.Domain.Products;

namespace SamStore.Catalog.API.Data.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("VARCHAR(250)");

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnType("VARCHAR(500)");

            builder.HasData(new[] {
                new Product("Omêga", "Descrição", 259.99m, ""),
                new Product("Scarlatte", "Descrição", 629.99m, ""),
                new Product("Fiarrut", "Descrição", 349.99m, ""),
                new Product("Gonjour Lamari", "Descrição", 559.99m, ""),
                new Product("Vilé Toustã", "Descrição", 229.99m, ""),
                new Product("Frankfourd Stoitelle", "Descrição", 129.99m, "")
            });
        }
    }
}

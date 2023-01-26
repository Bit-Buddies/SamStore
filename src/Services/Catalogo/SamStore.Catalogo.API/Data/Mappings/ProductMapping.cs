using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SamStore.Catalogo.API.Domain.Products;

namespace SamStore.Catalogo.API.Data.Mappings
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
        }
    }
}

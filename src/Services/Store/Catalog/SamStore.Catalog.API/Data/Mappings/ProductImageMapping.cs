using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SamStore.Catalog.API.Domain.Products;

namespace SamStore.Catalog.API.Data.Mappings
{
    public class ProductImageMapping : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable("product_image");

            builder.Property(x => x.Path)
                .HasColumnType("VARCHAR(255)");

            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR(100)");

            builder.HasOne(x => x.Product)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.ProductId);
            builder.HasIndex(x => new { x.ProductId, x.Name });
        }
    }
}

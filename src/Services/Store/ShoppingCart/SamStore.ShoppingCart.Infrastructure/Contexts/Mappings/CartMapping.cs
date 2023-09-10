using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SamStore.ShoppingCart.Domain.ShoppingCarts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.ShoppingCart.Infrastructure.Contexts.Mappings
{
    public class CartMapping : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("cart");

            builder.HasMany(x => x.Items)
                .WithOne(x => x.Cart)
                .HasForeignKey(x => x.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Ignore(x => x.Voucher)
                .OwnsOne(cart => cart.Voucher, voucher =>
                {
                    voucher.Property(x => x.Key)
                        .HasMaxLength(50);

                    voucher.Property(x => x.Discount)
                        .HasColumnType("DECIMAL(10,2)");
                });

            builder.HasIndex(c => c.CostumerId);
        }
    }
}

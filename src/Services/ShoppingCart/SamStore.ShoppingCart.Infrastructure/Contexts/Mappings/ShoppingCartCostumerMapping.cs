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
    public class ShoppingCartCostumerMapping : IEntityTypeConfiguration<ShoppingCartCostumer>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartCostumer> builder)
        {
            builder.ToTable("shopping_cart_costumer");

            builder.HasMany(x => x.Items)
                .WithOne(x => x.ShoppingCart)
                .HasForeignKey(x => x.ShoppingCartId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(c => c.CostumerId)
                .HasDatabaseName("IDX_Costumer");
        }
    }
}

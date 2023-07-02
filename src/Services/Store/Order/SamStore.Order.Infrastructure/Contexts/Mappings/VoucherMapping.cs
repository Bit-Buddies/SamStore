using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SamStore.Order.Domain.Vouchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.Order.Infrastructure.Contexts.Mappings
{
    public class VoucherMapping : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            builder.ToTable("voucher");

            builder.Property(x => x.Key)
                .IsRequired()
                .HasColumnType("VARCHAR(100)");

            builder.HasMany(x => x.VoucherOrders)
                .WithOne(x => x.Voucher);

            builder.HasIndex(x => x.Key)
                .IsUnique();
        }
    }
}

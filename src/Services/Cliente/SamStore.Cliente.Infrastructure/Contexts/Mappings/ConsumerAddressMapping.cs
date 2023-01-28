using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SamStore.Cliente.Domain.Consumers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.Cliente.Infrastructure.Contexts.Mappings
{
    internal class ConsumerAddressMapping : IEntityTypeConfiguration<ConsumerAddress>
    {
        public void Configure(EntityTypeBuilder<ConsumerAddress> builder)
        {
            builder.ToTable("consumer_address");
        }
    }
}

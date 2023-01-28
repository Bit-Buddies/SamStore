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
    public class ConsumerMapping : IEntityTypeConfiguration<Consumer>
    {
        public void Configure(EntityTypeBuilder<Consumer> builder)
        {
            builder.ToTable("consumer");

            builder.Property(x => x.Name).IsRequired();

            builder.OwnsOne(x => x.Phone, phone =>
            {
                phone.Property(c => c.PrincipalPhone)
                    .IsRequired()
                    .HasColumnName("phone1")
                    .HasColumnType("VARCHAR(20)");

                phone.Property(c => c.SecundaryPhone)
                    .HasColumnName("phone2")
                    .HasColumnType("VARCHAR(20)");
            });

            builder.OwnsOne(x => x.CPF, cpf =>
            {
                cpf.Property(c => c.Number)
                    .IsRequired()
                    .HasColumnName("cpf")
                    .HasColumnType("VARCHAR(11)");
            });

            builder.OwnsOne(x => x.Email, email =>
            {
                email.Property(c => c.Address)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("VARCHAR(100)");
            });

            builder.HasOne(x => x.ConsumerAddress)
                .WithOne(x => x.Consumer)
                .HasForeignKey<ConsumerAddress>(x => x.ConsumerId);
        }
    }
}

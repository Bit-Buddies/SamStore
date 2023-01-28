using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SamStore.Cliente.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.Cliente.Infrastructure.Contexts.Mappings
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customer");

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

            builder.HasOne(x => x.CustomerAddress)
                .WithOne(x => x.Customer)
                .HasForeignKey<CustomerAddress>(x => x.CustomerId);
        }
    }
}

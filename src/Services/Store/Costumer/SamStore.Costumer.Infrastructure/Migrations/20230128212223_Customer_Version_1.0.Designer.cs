﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SamStore.Costumer.Infrastructure.Contexts;

#nullable disable

namespace SamStore.Costumer.Infrastructure.Migrations
{
    [DbContext(typeof(CostumerDbContext))]
    [Migration("20230128212223_Customer_Version_1.0")]
    partial class Customer_Version_10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SamStore.Costumer.Domain.Customers.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("char(36)")
                        .HasColumnName("address_id");

                    b.Property<DateTime>("AlteredAt")
                        .HasColumnType("DATETIME")
                        .HasColumnName("altered_at");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DATETIME")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("name");

                    b.Property<bool>("Removed")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("removed");

                    b.HasKey("Id")
                        .HasName("pk_customer");

                    b.ToTable("customer", (string)null);
                });

            modelBuilder.Entity("SamStore.Costumer.Domain.Customers.CustomerAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<DateTime>("AlteredAt")
                        .HasColumnType("DATETIME")
                        .HasColumnName("altered_at");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("country");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DATETIME")
                        .HasColumnName("created_at");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("char(36)")
                        .HasColumnName("customer_id");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("district");

                    b.Property<string>("Line1")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("line1");

                    b.Property<string>("Line2")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("line2");

                    b.Property<int>("Number")
                        .HasColumnType("int")
                        .HasColumnName("number");

                    b.Property<bool>("Removed")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("removed");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("state");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("zip_code");

                    b.HasKey("Id")
                        .HasName("pk_customer_address");

                    b.HasIndex("CustomerId")
                        .IsUnique()
                        .HasDatabaseName("ix_customer_address_customer_id");

                    b.ToTable("customer_address", (string)null);
                });

            modelBuilder.Entity("SamStore.Costumer.Domain.Customers.Customer", b =>
                {
                    b.OwnsOne("SamStore.Core.Domain.ValueObjects.CPF", "CPF", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("char(36)")
                                .HasColumnName("id");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("VARCHAR(11)")
                                .HasColumnName("cpf");

                            b1.HasKey("CustomerId");

                            b1.ToTable("customer");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId")
                                .HasConstraintName("fk_customer_customer_id");
                        });

                    b.OwnsOne("SamStore.Core.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("char(36)")
                                .HasColumnName("id");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("VARCHAR(100)")
                                .HasColumnName("email");

                            b1.HasKey("CustomerId");

                            b1.ToTable("customer");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId")
                                .HasConstraintName("fk_customer_customer_id");
                        });

                    b.OwnsOne("SamStore.Core.Domain.ValueObjects.Phone", "Phone", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("char(36)")
                                .HasColumnName("id");

                            b1.Property<string>("PrincipalPhone")
                                .IsRequired()
                                .HasColumnType("VARCHAR(20)")
                                .HasColumnName("phone1");

                            b1.Property<string>("SecundaryPhone")
                                .IsRequired()
                                .HasColumnType("VARCHAR(20)")
                                .HasColumnName("phone2");

                            b1.HasKey("CustomerId");

                            b1.ToTable("customer");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId")
                                .HasConstraintName("fk_customer_customer_id");
                        });

                    b.Navigation("CPF")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Phone")
                        .IsRequired();
                });

            modelBuilder.Entity("SamStore.Costumer.Domain.Customers.CustomerAddress", b =>
                {
                    b.HasOne("SamStore.Costumer.Domain.Customers.Customer", "Customer")
                        .WithOne("CustomerAddress")
                        .HasForeignKey("SamStore.Costumer.Domain.Customers.CustomerAddress", "CustomerId")
                        .IsRequired()
                        .HasConstraintName("fk_customer_address_customers_customer_id");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("SamStore.Costumer.Domain.Customers.Customer", b =>
                {
                    b.Navigation("CustomerAddress")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

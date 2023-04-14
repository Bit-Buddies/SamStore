﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SamStore.Catalog.API.Data.Contexts;

#nullable disable

namespace SamStore.Catalog.API.Migrations
{
    [DbContext(typeof(CatalogDbContext))]
    [Migration("20230414153412_Catalog_Version_3.0")]
    partial class Catalog_Version_30
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SamStore.Catalog.API.Domain.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<DateTime>("AlteredAt")
                        .HasColumnType("DATETIME")
                        .HasColumnName("altered_at");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DATETIME")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR(500)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasColumnName("name");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<bool>("Removed")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("removed");

                    b.Property<decimal>("Value")
                        .HasColumnType("DECIMAL(65,4)")
                        .HasColumnName("value");

                    b.HasKey("Id")
                        .HasName("pk_product");

                    b.ToTable("product", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("58f4441c-b9e0-4d8d-8148-9b11b1fb0b66"),
                            AlteredAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Descrição",
                            Name = "Omêga",
                            Quantity = 0,
                            Removed = false,
                            Value = 259.99m
                        },
                        new
                        {
                            Id = new Guid("b1e3b390-f8b4-4788-9d01-52e7fb8e3727"),
                            AlteredAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Descrição",
                            Name = "Scarlatte",
                            Quantity = 0,
                            Removed = false,
                            Value = 629.99m
                        },
                        new
                        {
                            Id = new Guid("77b5a0ae-3255-4d48-b2e3-45f4551d7c1b"),
                            AlteredAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Descrição",
                            Name = "Fiarrut",
                            Quantity = 0,
                            Removed = false,
                            Value = 349.99m
                        },
                        new
                        {
                            Id = new Guid("c5a9c4df-f29c-4f82-ad30-d4e7d435f626"),
                            AlteredAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Descrição",
                            Name = "Gonjour Lamari",
                            Quantity = 0,
                            Removed = false,
                            Value = 559.99m
                        },
                        new
                        {
                            Id = new Guid("1da9ab98-ce07-43a4-91dc-c99dec79deb9"),
                            AlteredAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Descrição",
                            Name = "Vilé Toustã",
                            Quantity = 0,
                            Removed = false,
                            Value = 229.99m
                        },
                        new
                        {
                            Id = new Guid("643a94a4-c5e9-4d01-ae3c-acd22fa2170e"),
                            AlteredAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Descrição",
                            Name = "Frankfourd Stoitelle",
                            Quantity = 0,
                            Removed = false,
                            Value = 129.99m
                        });
                });

            modelBuilder.Entity("SamStore.Catalog.API.Domain.Products.ProductImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<DateTime>("AlteredAt")
                        .HasColumnType("DATETIME")
                        .HasColumnName("altered_at");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DATETIME")
                        .HasColumnName("created_at");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("hash");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("name");

                    b.Property<int>("Order")
                        .HasColumnType("int")
                        .HasColumnName("order");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("path");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("char(36)")
                        .HasColumnName("product_id");

                    b.Property<bool>("Removed")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("removed");

                    b.HasKey("Id")
                        .HasName("pk_product_image");

                    b.HasIndex("ProductId")
                        .HasDatabaseName("ix_product_image_product_id");

                    b.HasIndex("ProductId", "Name")
                        .HasDatabaseName("ix_product_image_product_id_name");

                    b.ToTable("product_image", (string)null);
                });

            modelBuilder.Entity("SamStore.Catalog.API.Domain.Products.ProductImage", b =>
                {
                    b.HasOne("SamStore.Catalog.API.Domain.Products.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_product_image_products_product_id");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SamStore.Catalog.API.Domain.Products.Product", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}

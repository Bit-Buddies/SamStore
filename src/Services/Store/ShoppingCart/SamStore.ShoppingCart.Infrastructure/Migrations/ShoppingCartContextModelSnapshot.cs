﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SamStore.ShoppingCart.Infrastructure.Contexts;

#nullable disable

namespace SamStore.ShoppingCart.Infrastructure.Migrations
{
    [DbContext(typeof(ShoppingCartContext))]
    partial class ShoppingCartContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SamStore.ShoppingCart.Domain.ShoppingCarts.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<DateTime>("AlteredAt")
                        .HasColumnType("DATETIME")
                        .HasColumnName("altered_at");

                    b.Property<Guid>("CostumerId")
                        .HasColumnType("char(36)")
                        .HasColumnName("costumer_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DATETIME")
                        .HasColumnName("created_at");

                    b.Property<bool>("Removed")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("removed");

                    b.HasKey("Id")
                        .HasName("pk_cart");

                    b.HasIndex("CostumerId")
                        .HasDatabaseName("ix_cart_costumer_id");

                    b.ToTable("cart", (string)null);
                });

            modelBuilder.Entity("SamStore.ShoppingCart.Domain.ShoppingCarts.CartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<DateTime>("AlteredAt")
                        .HasColumnType("DATETIME")
                        .HasColumnName("altered_at");

                    b.Property<Guid>("CartId")
                        .HasColumnType("char(36)")
                        .HasColumnName("cart_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DATETIME")
                        .HasColumnName("created_at");

                    b.Property<string>("Image")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("VARCHAR(100)")
                        .HasDefaultValue("")
                        .HasColumnName("image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(65,2)")
                        .HasColumnName("price");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("char(36)")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<bool>("Removed")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("removed");

                    b.HasKey("Id")
                        .HasName("pk_cart_item");

                    b.HasIndex("CartId")
                        .HasDatabaseName("ix_cart_item_cart_id");

                    b.ToTable("cart_item", (string)null);
                });

            modelBuilder.Entity("SamStore.ShoppingCart.Domain.ShoppingCarts.Cart", b =>
                {
                    b.OwnsOne("SamStore.ShoppingCart.Domain.Vouchers.Voucher", "Voucher", b1 =>
                        {
                            b1.Property<Guid>("CartId")
                                .HasColumnType("char(36)")
                                .HasColumnName("id");

                            b1.Property<decimal?>("Discount")
                                .HasColumnType("DECIMAL(10,2)")
                                .HasColumnName("voucher_discount");

                            b1.Property<int?>("DiscountType")
                                .HasColumnType("int")
                                .HasColumnName("voucher_discount_type");

                            b1.Property<string>("Key")
                                .HasMaxLength(50)
                                .HasColumnType("VARCHAR(100)")
                                .HasColumnName("voucher_key");

                            b1.Property<bool>("Used")
                                .HasColumnType("tinyint(1)")
                                .HasColumnName("voucher_used");

                            b1.HasKey("CartId");

                            b1.ToTable("cart");

                            b1.WithOwner()
                                .HasForeignKey("CartId")
                                .HasConstraintName("fk_cart_cart_id");
                        });

                    b.Navigation("Voucher")
                        .IsRequired();
                });

            modelBuilder.Entity("SamStore.ShoppingCart.Domain.ShoppingCarts.CartItem", b =>
                {
                    b.HasOne("SamStore.ShoppingCart.Domain.ShoppingCarts.Cart", "Cart")
                        .WithMany("Items")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_cart_item_carts_cart_id");

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("SamStore.ShoppingCart.Domain.ShoppingCarts.Cart", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}

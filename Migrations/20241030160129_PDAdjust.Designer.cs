﻿// <auto-generated />
using System;
using ECommerceProject.src.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ECommerceProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241030160129_PDAdjust")]
    partial class PDAdjust
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ECommerceProject.src.Models.Category", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("CategoryDescription")
                        .HasColumnType("text");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("ID");

                    b.HasIndex("CategoryName")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ECommerceProject.src.Models.Inventory", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("InventoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("NumberOfItems")
                        .HasColumnType("integer");

                    b.Property<Guid>("StoreID")
                        .HasColumnType("uuid");

                    b.Property<int>("TotalQuantity")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("ID");

                    b.HasIndex("ID");

                    b.HasIndex("StoreID")
                        .IsUnique();

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("ECommerceProject.src.Models.Order", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("StoreID")
                        .HasColumnType("uuid");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.HasKey("ID");

                    b.HasIndex("OrderNumber")
                        .IsUnique();

                    b.HasIndex("StoreID");

                    b.HasIndex("UserID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ECommerceProject.src.Models.OrderDetail", b =>
                {
                    b.Property<Guid>("OrderID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uuid");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("integer");

                    b.HasKey("OrderID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("ECommerceProject.src.Models.Product", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid>("CategoryID")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<Guid>("InventoryID")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("ProductDescription")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<Guid>("StoreID")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("InventoryID");

                    b.HasIndex("StoreID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ECommerceProject.src.Models.Role", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("RoleDescription")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("ID");

                    b.HasIndex("RoleName")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ECommerceProject.src.Models.Store", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.HasKey("ID");

                    b.HasIndex("ID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("ECommerceProject.src.Models.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<Guid>("RoleID")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("ID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("E_CommerceWebsiteProject.src.Models.Image", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("ImageName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("E_CommerceWebsiteProject.src.Models.Payment", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<Guid?>("OrderID")
                        .HasColumnType("uuid");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TransactionID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("ID");

                    b.HasIndex("OrderID")
                        .IsUnique();

                    b.HasIndex("TransactionID")
                        .IsUnique();

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("ECommerceProject.src.Models.Inventory", b =>
                {
                    b.HasOne("ECommerceProject.src.Models.Store", "AssociatedStore")
                        .WithOne("AssociatedInventory")
                        .HasForeignKey("ECommerceProject.src.Models.Inventory", "StoreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssociatedStore");
                });

            modelBuilder.Entity("ECommerceProject.src.Models.Order", b =>
                {
                    b.HasOne("ECommerceProject.src.Models.Store", "AssociatedStore")
                        .WithMany("OrdersList")
                        .HasForeignKey("StoreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerceProject.src.Models.User", "AssociatedUser")
                        .WithMany("OrdersList")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssociatedStore");

                    b.Navigation("AssociatedUser");
                });

            modelBuilder.Entity("ECommerceProject.src.Models.OrderDetail", b =>
                {
                    b.HasOne("ECommerceProject.src.Models.Order", "AssociatedOrder")
                        .WithMany("OrderDetailsList")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerceProject.src.Models.Product", "AssociatedProduct")
                        .WithMany("OrderDetailsList")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssociatedOrder");

                    b.Navigation("AssociatedProduct");
                });

            modelBuilder.Entity("ECommerceProject.src.Models.Product", b =>
                {
                    b.HasOne("ECommerceProject.src.Models.Category", "AssociatedCategory")
                        .WithMany("ProductsList")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerceProject.src.Models.Inventory", "AssociatedInventory")
                        .WithMany("ProductsList")
                        .HasForeignKey("InventoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerceProject.src.Models.Store", "AssociatedStore")
                        .WithMany("ProductsList")
                        .HasForeignKey("StoreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssociatedCategory");

                    b.Navigation("AssociatedInventory");

                    b.Navigation("AssociatedStore");
                });

            modelBuilder.Entity("ECommerceProject.src.Models.Store", b =>
                {
                    b.HasOne("ECommerceProject.src.Models.User", "AssociatedUser")
                        .WithOne("StoreOwner")
                        .HasForeignKey("ECommerceProject.src.Models.Store", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssociatedUser");
                });

            modelBuilder.Entity("ECommerceProject.src.Models.User", b =>
                {
                    b.HasOne("ECommerceProject.src.Models.Role", "AssociatedRole")
                        .WithMany("UsersList")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssociatedRole");
                });

            modelBuilder.Entity("E_CommerceWebsiteProject.src.Models.Image", b =>
                {
                    b.HasOne("ECommerceProject.src.Models.Product", "AssociatedProduct")
                        .WithMany("ImageList")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssociatedProduct");
                });

            modelBuilder.Entity("E_CommerceWebsiteProject.src.Models.Payment", b =>
                {
                    b.HasOne("ECommerceProject.src.Models.Order", "AssociatedOrder")
                        .WithOne("AssociatedPayment")
                        .HasForeignKey("E_CommerceWebsiteProject.src.Models.Payment", "OrderID");

                    b.Navigation("AssociatedOrder");
                });

            modelBuilder.Entity("ECommerceProject.src.Models.Category", b =>
                {
                    b.Navigation("ProductsList");
                });

            modelBuilder.Entity("ECommerceProject.src.Models.Inventory", b =>
                {
                    b.Navigation("ProductsList");
                });

            modelBuilder.Entity("ECommerceProject.src.Models.Order", b =>
                {
                    b.Navigation("AssociatedPayment");

                    b.Navigation("OrderDetailsList");
                });

            modelBuilder.Entity("ECommerceProject.src.Models.Product", b =>
                {
                    b.Navigation("ImageList");

                    b.Navigation("OrderDetailsList");
                });

            modelBuilder.Entity("ECommerceProject.src.Models.Role", b =>
                {
                    b.Navigation("UsersList");
                });

            modelBuilder.Entity("ECommerceProject.src.Models.Store", b =>
                {
                    b.Navigation("AssociatedInventory")
                        .IsRequired();

                    b.Navigation("OrdersList");

                    b.Navigation("ProductsList");
                });

            modelBuilder.Entity("ECommerceProject.src.Models.User", b =>
                {
                    b.Navigation("OrdersList");

                    b.Navigation("StoreOwner");
                });
#pragma warning restore 612, 618
        }
    }
}

using ECommerceProject.src.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System;
using System.Collections.Generic;
using E_CommerceWebsiteProject.src.Models;

namespace ECommerceProject.src.DB
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<User>(entity =>
            {
                entity.HasKey(user => user.ID);
                entity.Property(user => user.ID).HasDefaultValueSql("uuid_generate_v4()");
                entity.Property(user => user.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(user => user.LastName).IsRequired().HasMaxLength(100);
                entity.Property(user => user.Email).IsRequired();
                entity.HasIndex(user => user.Email).IsUnique();
                entity.Property(user => user.PhoneNumber).IsRequired().HasMaxLength(20);
                entity.Property(user => user.Password).IsRequired().HasMaxLength(200);
                entity.Property(user => user.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(user => user.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(user => user.StoreOwner)
                .WithOne(store => store.AssociatedUser)
                .HasForeignKey<Store>(store => store.UserID);

                entity.HasMany(user => user.OrdersList)
                .WithOne(order => order.AssociatedUser)
                .HasForeignKey(order => order.UserID);
            });
            builder.Entity<Role>(entity =>
            {
                entity.HasKey(role => role.ID);
                entity.Property(role => role.ID).HasDefaultValueSql("uuid_generate_v4()");
                entity.Property(role => role.RoleName).IsRequired().HasMaxLength(100);
                entity.HasIndex(role => role.RoleName).IsUnique();
                entity.Property(role => role.RoleDescription).HasMaxLength(300);
                entity.Property(role => role.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(role => role.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasMany(role => role.UsersList)
                .WithOne(user => user.AssociatedRole)
                .HasForeignKey(user => user.RoleID);
            });
            builder.Entity<Product>(entity =>
            {
                entity.HasKey(product => product.ID);
                entity.Property(product => product.ID).HasDefaultValueSql("uuid_generate_v4()");
                entity.Property(product => product.ProductName).IsRequired().HasMaxLength(100);
                entity.Property(product => product.ProductDescription).HasMaxLength(300);
                entity.Property(product => product.Price).IsRequired();
                entity.Property(product => product.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(product => product.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasMany(product => product.ImageList)
                .WithOne(image => image.AssociatedProduct)
                .HasForeignKey(image => image.ProductID);
            });
            builder.Entity<Category>(entity =>
            {
                entity.HasKey(category => category.ID);
                entity.Property(category => category.ID).HasDefaultValueSql("uuid_generate_v4()");
                entity.Property(category => category.CategoryName).IsRequired().HasMaxLength(100);
                entity.HasIndex(category => category.CategoryName).IsUnique();
                entity.Property(category => category.CategoryName);
                entity.Property(category => category.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(category => category.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasMany(category => category.ProductsList)
                .WithOne(product => product.AssociatedCategory)
                .HasForeignKey(product => product.CategoryID);
            });
            builder.Entity<Store>(entity =>
            {
                entity.HasIndex(store => store.ID);
                entity.Property(store => store.ID).HasDefaultValueSql("uuid_generate_v4()");
                entity.Property(store => store.StoreName).IsRequired().HasMaxLength(100);
                entity.Property(store => store.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(store => store.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasMany(store => store.ProductsList)
                .WithOne(product => product.AssociatedStore)
                .HasForeignKey(product => product.StoreID);

                entity.HasOne(Store => Store.AssociatedInventory)
                .WithOne(inventory => inventory.AssociatedStore)
                .HasForeignKey<Inventory>(inventory => inventory.StoreID);

                entity.HasMany(store => store.OrdersList)
                .WithOne(orders => orders.AssociatedStore)
                .HasForeignKey(order => order.StoreID);
            });
            builder.Entity<Inventory>(entity =>
            {
                entity.HasIndex(inventory => inventory.ID);
                entity.Property(inventory => inventory.ID).HasDefaultValueSql("uuid_generate_v4()");
                entity.Property(inventory => inventory.InventoryName).IsRequired().HasMaxLength(100);
                entity.Property(inventory => inventory.NumberOfItems).IsRequired();
                entity.Property(inventory => inventory.TotalQuantity).IsRequired();
                entity.Property(inventory => inventory.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(inventory => inventory.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasMany(inventory => inventory.ProductsList)
                .WithOne(product => product.AssociatedInventory)
                .HasForeignKey(product => product.InventoryID);
            });
            builder.Entity<Image>(entity =>
            {
                entity.HasKey(image => image.ID);
                entity.Property(image => image.ID).HasDefaultValueSql("uuid_generate_v4()");
                entity.Property(image => image.ImageName).HasMaxLength(100);
                entity.Property(image => image.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(image => image.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
            builder.Entity<Payment>(entity =>
            {
                entity.HasKey(payment => payment.ID);
                entity.Property(payment => payment.ID).HasDefaultValueSql("uuid_generate_v4()");
                entity.Property(payment => payment.TransactionID).IsRequired();
                entity.HasIndex(payment => payment.TransactionID).IsUnique();
                entity.Property(payment => payment.PaymentMethod).IsRequired().HasMaxLength(50);
                entity.Property(payment => payment.Amount).IsRequired();
                entity.Property(payment => payment.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(payment => payment.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(payment => payment.AssociatedOrder)
                .WithOne(order => order.AssociatedPayment)
                .HasForeignKey<Payment>(payment => payment.OrderID);
            });
            builder.Entity<Order>(entity =>
            {
                entity.HasKey(order => order.ID);
                entity.Property(order => order.ID).HasDefaultValueSql("uuid_generate_v4()");
                entity.Property(order => order.OrderNumber).IsRequired();
                entity.HasIndex(order => order.OrderNumber).IsUnique();
                entity.Property(order => order.Status).IsRequired();
                entity.Property(order => order.TotalAmount).IsRequired();
                entity.Property(order => order.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(order => order.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
            builder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(orderDetail => new { orderDetail.OrderID, orderDetail.ProductID });
                entity.Property(orderDetail => orderDetail.ProductQuantity).IsRequired();

                entity.HasOne(orderDetail => orderDetail.AssociatedOrder)
                .WithMany(order => order.OrderDetailsList)
                .HasForeignKey(orderDetail => orderDetail.OrderID);

                entity.HasOne(orderDetail => orderDetail.AssociatedProduct)
                .WithMany(product => product.OrderDetailsList)
                .HasForeignKey(orderDetail => orderDetail.ProductID);
            });
        }
    }
}
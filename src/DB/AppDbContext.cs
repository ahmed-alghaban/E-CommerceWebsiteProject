using ECommerceProject.src.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System;
using System.Collections.Generic;

namespace ECommerceProject.src.DB
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Inventory> Inventories{ get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){} 

        protected override void OnModelCreating(ModelBuilder builder){

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
            });

            builder.Entity<Category>(entity => 
            {
                entity.HasKey(category => category.ID);
                entity.Property(category => category.ID).HasDefaultValueSql("uuid_generate_v4()");
                entity.Property(category => category.CaetgoryName).IsRequired().HasMaxLength(100);
                entity.HasIndex(category => category.CaetgoryName).IsUnique();
                entity.Property(category => category.CaetgoryDescription);
                entity.Property(category => category.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(category => category.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                
                entity.HasMany(category => category.ProductsList)
                .WithOne(product => product.AssocitedCategory)
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
            });

        }
    }
}
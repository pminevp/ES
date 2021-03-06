﻿using ES.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ES.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Building> Building { get; set; }
        public DbSet<BuildingFloor> BuildingFloor { get; set; }
        public DbSet<Apartament> Apartament { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<DocumentFile> DocumentFile { get; set; }
        public DbSet<DocumentDataType> DocumentDataType { get; set; }



        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>().Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Entity<Customer>().HasIndex(c => c.Name);
            builder.Entity<Customer>().Property(c => c.Email).HasMaxLength(100);
            builder.Entity<Customer>().Property(c => c.PhoneNumber).IsUnicode(false).HasMaxLength(30);
            builder.Entity<Customer>().Property(c => c.City).HasMaxLength(50);
            builder.Entity<Customer>().ToTable($"App{nameof(this.Customers)}");

            builder.Entity<ProductCategory>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Entity<ProductCategory>().Property(p => p.Description).HasMaxLength(500);
            builder.Entity<ProductCategory>().ToTable($"App{nameof(this.ProductCategories)}");

            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Entity<Product>().HasIndex(p => p.Name);
            builder.Entity<Product>().Property(p => p.Description).HasMaxLength(500);
            builder.Entity<Product>().Property(p => p.Icon).IsUnicode(false).HasMaxLength(256);
            builder.Entity<Product>().HasOne(p => p.Parent).WithMany(p => p.Children).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Product>().ToTable($"App{nameof(this.Products)}");

            builder.Entity<Order>().Property(o => o.Comments).HasMaxLength(500);
            builder.Entity<Order>().ToTable($"App{nameof(this.Orders)}");

            builder.Entity<OrderDetail>().ToTable($"App{nameof(this.OrderDetails)}");

            builder.Entity<Building>().ToTable($"App{nameof(this.Building)}");
            builder.Entity<BuildingFloor>().ToTable($"App{nameof(this.BuildingFloor)}");
            builder.Entity<Apartament>().ToTable($"App{nameof(this.Apartament)}");

            builder.Entity<Notification>().ToTable($"App{nameof(this.Notification)}");

            builder.Entity<DocumentFile>().ToTable($"App{nameof(this.DocumentFile)}");

            builder.Entity<DocumentDataType>().Property(s => s.DataTypeId).IsRequired();
            builder.Entity<DocumentDataType>().ToTable($"App{nameof(this.DocumentDataType)}");

        }
    }
}

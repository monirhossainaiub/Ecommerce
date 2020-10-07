﻿using System;
using System.Collections.Generic;
using System.Text;
using Ecom.App.EntityMapping;
using Ecom.App.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecom.App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductNote> ProductNotes { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<ProductPublisher> ProductPublishers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<OrderNote> OrderNotes { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Banner> Banners { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.ApplyConfiguration(new CategoryConfiguration());

            builder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            builder.Entity<OrderStatus>().HasIndex(c => c.Name).IsUnique();
            builder.Entity<PaymentMethod>().HasIndex(c => c.Name).IsUnique();
            builder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            builder.Entity<City>().HasIndex(c => c.Name).IsUnique();
            builder.Entity<Customer>().HasIndex(c =>new { c.Email, c.Phone}).IsUnique();
            builder.Entity<Banner>().HasIndex(b =>new {b.Title}).IsUnique();

            builder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Writer>()
                .HasMany(w => w.Products)
                .WithOne(p => p.Writer)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Language>()
                .HasMany(l => l.Products)
                .WithOne(p => p.Language)
                .HasForeignKey(p => p.LanguageId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ProductPublisher>()
                .HasMany(p => p.Photos)
                .WithOne(ph => ph.ProductPublisher)
                .HasForeignKey(p => p.ProductPublisherId)
                .HasPrincipalKey(pp => pp.Id)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Product>(entity => {
                entity.HasIndex(p => p.Name).IsUnique();
            });

            builder.Entity<ProductPublisher>(entity => {
                entity.HasIndex(p => p.SKU).IsUnique();
            });
            builder.Entity<Writer>(entity => {
                entity.HasIndex(p => p.Name).IsUnique();
            });

            builder.Entity<Publisher>()
                .HasIndex(p => p.Name).IsUnique();
            builder.Entity<Language>()
                .HasIndex(p => p.Name).IsUnique();

            builder.Entity<ProductPublisher>()
                .HasKey(pp => new { pp.ProductId, pp.PublisherId, pp.Id});

            builder.Entity<ProductPublisher>()
                .HasOne(pp => pp.Product)
                .WithMany(p => p.ProductPublishers)
                .HasForeignKey(pp => pp.ProductId);

            builder.Entity<ProductPublisher>()
                .HasOne(pp => pp.Publisher)
                .WithMany(p => p.ProductPublishers)
                .HasForeignKey(pp => pp.PublisherId);

            builder.Entity<Banner>()
                .HasMany(b => b.ProductPublishers)
                .WithOne(p => p.Banner)
                .HasForeignKey(b => b.BannerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}

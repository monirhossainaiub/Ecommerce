using System;
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
        public DbSet<Writer> Writers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.ApplyConfiguration(new CategoryConfiguration());

            builder.Entity<Category>().HasIndex(c => c.Name).IsUnique();

            builder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .OnDelete(DeleteBehavior.Restrict);

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

            builder.Entity<ProductPublisher>()
                .HasKey(pp => new { pp.ProductId, pp.PublisherId});

            builder.Entity<ProductPublisher>()
                .HasOne(pp => pp.Product)
                .WithMany(p => p.ProductPublishers)
                .HasForeignKey(pp => pp.ProductId);

            builder.Entity<ProductPublisher>()
                .HasOne(pp => pp.Publisher)
                .WithMany(p => p.ProductPublishers)
                .HasForeignKey(pp => pp.PublisherId);
        }
    }
}

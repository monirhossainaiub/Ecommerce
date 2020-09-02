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


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.ApplyConfiguration(new CategoryConfiguration());

            builder.Entity<Category>().HasIndex(c => c.Name).IsUnique();

            builder.Entity<Product>(entity => {
                entity.HasIndex(p => p.SKU).IsUnique();
                entity.HasIndex(p => p.Name).IsUnique();
            });
                

            builder.Entity<Publisher>()
                .HasIndex(p => p.Name).IsUnique();
        }
    }
}

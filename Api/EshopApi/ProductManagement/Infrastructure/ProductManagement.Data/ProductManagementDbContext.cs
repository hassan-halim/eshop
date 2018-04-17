using Microsoft.EntityFrameworkCore;
using ProductManagement.Core.Models;
using System;

namespace ProductManagement.Data
{
    public class ProductManagementDbContext : DbContext
    {
        public ProductManagementDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductFeature>()
                .HasKey(t => new { t.FeatureID, t.ProductId });
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<ProductFeature> ProductFeatures{ get; set; }
        public DbSet<Cart> Carts { get; set; }
    }
}

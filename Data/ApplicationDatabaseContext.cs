using Microsoft.EntityFrameworkCore;
using Склад.Models;

namespace Склад.Data
{
    public class ApplicationDatabaseContext: DbContext
    {
        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Data для Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Electronics"},
                new Category { CategoryId = 2, Name = "Books"}
            );

            // Seed Data для Suppliers
            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { SupplierId = 1, Name = "Acme Corp", Email = "john.doe@acmecorp.com" },
                new Supplier { SupplierId = 2, Name = "Beta Inc", Email = "jane.smith@betainc.com" }
            );

            // Seed Data для Products
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Laptop", Price = 1200.00M, Quantity = 2, CategoryId = 1, SupplierId = 1 },
                new Product { ProductId = 2, Name = "Smartphone",  Price = 800.00M, Quantity = 2, CategoryId = 1, SupplierId = 1 },
                new Product { ProductId = 3, Name = "The Lord of the Rings", Price = 25.00M, Quantity = 2, CategoryId = 2, SupplierId = 2 }
            );

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Склад.Models;

namespace Склад.Data
{
    public class ApplicationDatabaseContext: DbContext
    {
        public ApplicationDatabaseContext(DbContextOptions<Sclad> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }
    }
}

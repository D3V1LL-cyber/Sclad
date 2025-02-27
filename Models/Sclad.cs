using Microsoft.EntityFrameworkCore;

namespace Склад.Models
{
    public class Sclad: DbContext
    {
        public Sclad(DbContextOptions<Sclad> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using Склад.Models;
using Склад.Models.Auth;

namespace Склад.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<AuthUser> AuthUsers { get; set; }
    }
}

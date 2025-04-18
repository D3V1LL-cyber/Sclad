using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Склад.Models;

namespace Склад.Pages
{
    public class ProductsListModel : PageModel
    {
        private readonly Data.ApplicationDatabaseContext _context;

        public ProductsListModel(Data.ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public List<Product> Products { get; set; }

        public void OnGet()
        {
            Products = new List<Product>
            {
                new Product { ProductId = 1, Name = "Laptop", Price = 1200.00M, Quantity = 2, CategoryId = 1, SupplierId = 1 },
                new Product { ProductId = 2, Name = "Smartphone",  Price = 800.00M, Quantity = 2, CategoryId = 1, SupplierId = 1 },
                new Product { ProductId = 3, Name = "The Lord of the Rings", Price = 25.00M, Quantity = 2, CategoryId = 2, SupplierId = 2 }
            };
        }

    }
}

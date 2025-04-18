using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Склад.Data;
using Склад.Models;

namespace Склад.Pages
{
    public class EditPageModel : PageModel
    {
        private readonly ApplicationDatabaseContext _context;

        public EditPageModel(ApplicationDatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }


        public void OnGet(int id)
        {
            //Product = GetProductById(id);
            //Products = new Product { ProductId = id, Name = "", Price = 1200.00M, Quantity = 2, CategoryId = 1, SupplierId = 1 };
            Product = _context.Products.Find(id);
        }

        public IActionResult OnPost(int id) 
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("./ProductsList");
        }

        private Product GetProductById(int id)
        {
            return new Product { ProductId = id, Name = "Имя", Price = 0, Quantity = 0 };
        }

        private void UpdateProduct(Product product)
        {
            var existingProduct = _context.Products.Find(product.ProductId);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Quantity = product.Quantity;
                _context.SaveChanges();
            }
        }
    }
}

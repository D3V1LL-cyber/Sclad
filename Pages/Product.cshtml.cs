using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Склад.Data;
using Склад.Models;

namespace Склад.Pages
{
    public class ProductModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public ProductModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }
        public void OnGet(int id)
        {
            if (id > 0)
            {
                Product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            }
            else
            {
                Product = new Product() { Name = "", Price = 0, Quantity = 0, CategoryId = 0, SupplierId = 0 };
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Product.ProductId == 0)
            {
                _context.Products.Add(Product);
            }
            else
            {
                _context.Products.Update(Product);
            }
            _context.SaveChanges();
            return RedirectToPage("ProductsList");
        }
    }
}

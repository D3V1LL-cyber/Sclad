using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Склад.Models;

namespace Склад.Pages
{
    public class ProductsListModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public ProductsListModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Product> Products { get; set; }

        public void OnGet()
        {
            Products = _context.Products.ToList();
        }

        public IActionResult OnPostDelete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToPage();
        }

    }
}

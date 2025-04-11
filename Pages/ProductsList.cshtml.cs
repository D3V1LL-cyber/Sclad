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
        public IList<Product> Products { get; set; }

        public async Task OnGet()
        {
            Products = _context.Products.ToList();
        }

    }
}

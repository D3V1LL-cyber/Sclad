using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Склад.Hubs;
using Склад.Models;
using Склад.Data;

namespace Склад.Pages
{
    public class ProductsListModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<ProductHub> _hubContext;

        public ProductsListModel(ApplicationDbContext context, IHubContext<ProductHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }
        public List<Product> Products { get; set; }

        public void OnGet()
        {
            Products = _context.Products.ToList();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                await _hubContext.Clients.All.SendAsync("ReceiveProductUpdate");
            }
            return RedirectToPage();
        }

    }
}

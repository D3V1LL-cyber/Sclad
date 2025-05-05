using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Склад.Data;
using Склад.Hubs;
using Склад.Models;

namespace Склад.Pages
{
    public class ProductModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<ProductHub> _hubContext;
        public ProductModel(ApplicationDbContext context, IHubContext<ProductHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        [BindProperty]
        public Product Product { get; set; }
        public List<SelectListItem> CategoryList { get; set; }
        public List<SelectListItem> SupplierList { get; set; }
        public void OnGet(int id)
        {
            CategoryList = _context.Categories.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(), 
                Text = c.Name
            }).ToList();

            SupplierList = _context.Suppliers.Select(s => new SelectListItem
            {
                Value = s.SupplierId.ToString(),
                Text = s.Name
            }).ToList();

            if (id > 0)
            {
                Product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            }
            else
            {
                Product = new Product() { Name = "", Price = 0, Quantity = 0, CategoryId = 0, SupplierId = 0 };
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                CategoryList = _context.Categories.Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.Name
                }).ToList();

                SupplierList = _context.Suppliers.Select(s => new SelectListItem
                {
                    Value = s.SupplierId.ToString(),
                    Text = s.Name
                }).ToList();

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

            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("ReceiveProductUpdate");
            return RedirectToPage("ProductsList");
        }
    }
}

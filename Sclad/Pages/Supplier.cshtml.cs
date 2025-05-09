using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Склад.Data;
using Склад.Models;

namespace Склад.Pages
{
    [Authorize(Roles = "Admin")]
    public class SupplierModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public SupplierModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(string supplierName, string email)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var supplier = new Supplier
            {
                Name = supplierName,
                Email = email
            };

            _context.Suppliers.Add(supplier);
            _context.SaveChanges();

            return RedirectToPage("Product");
        }
    }
}

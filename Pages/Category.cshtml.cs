using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Склад.Data;
using Склад.Models;

namespace Склад.Pages
{

    [Authorize(Roles = "Admin")]
    public class CategoryModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CategoryModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(string categoryName)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var category = new Category
            {
                Name = categoryName
            };

            _context.Categories.Add(category);
            _context.SaveChanges();

            return RedirectToPage("Product");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Northwind;
using Microsoft.AspNetCore.Mvc;

namespace NorthwindWeb.Pages
{
    public class ProductsModel : PageModel
    {
        private Northwind.Northwind db;

        public ProductsModel(Northwind.Northwind injectedContext)
        {
            db = injectedContext;
        }
        public IEnumerable<string> Products { get; set; }
        public Product ProductsAll { get; set; }
        public IEnumerable<string> Categories { get; set; }
        public void OnGet()
        {
            ViewData["Title"] = "Products";
            Products = db.Products.Select(s => s.ProductName).ToArray();
            Categories = db.Categories.Select(s => s.CategoryName).ToArray();
        }
        [BindProperty]
        public Product Product { get; set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(Product);
                db.SaveChanges();
                return RedirectToPage("/suppliers");
            }
            return Page();
        }
    }
}
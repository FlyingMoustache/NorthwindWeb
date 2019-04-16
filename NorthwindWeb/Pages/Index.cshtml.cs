using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NorthwindWeb.Pages
{
    public class IndexModel : PageModel
    {
        private Northwind.Northwind db;

        public IndexModel(Northwind.Northwind injectedContext)
        {
            db = injectedContext;
        }
        public IEnumerable<string> Categories { get; set; }
        public string Cat;
      
        public void OnGet()
        {
            ViewData["Title"] = "Home page";
            Categories = db.Categories.Select(s => s.CategoryName).ToArray();
             
        }
    }
}
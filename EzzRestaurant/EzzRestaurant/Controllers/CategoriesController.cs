using System.Collections.Generic;
using System.Linq;
using EzzRestaurant.Data;
using EzzRestaurant.Models;
using Microsoft.AspNetCore.Mvc;
using EzzRestaurant.Models;
using Microsoft.Extensions.DependencyInjection;

namespace EzzRestaurant.Controllers
{
    public class CategoriesController : Controller
    {

        private ApplicationDbContext _db;

        [ActivatorUtilitiesConstructor]
        public CategoriesController(ApplicationDbContext ctx)
        {
            _db = ctx;
        }
        public CategoriesController()
        {
         
        }
        // GET
        public IActionResult Index()
        {
            ViewData["Categories"] = _db.Categories.ToList();
            return View();
        }
        
        
        public IActionResult Products(int id)
        {
            ViewData["Category"] = _db.Categories.Where(cat => cat.Id == id).ToList().First();
            ViewData["Products"] = _db.Products.Where(p => p.CategoryId == id).ToList();
            return View();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using EzzRestaurant.Data;
using EzzRestaurant.Models;
using Microsoft.AspNetCore.Mvc;
using EzzRestaurant.Models;
namespace EzzRestaurant.Controllers
{
    public class CategoriesController : Controller
    {

        private ApplicationDbContext _db;

        public CategoriesController(ApplicationDbContext ctx)
        {
            _db = ctx;
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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pets_Houses.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets_Houses.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductsController(ApplicationDbContext context)
        {
            _db = context;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var Products = _db.Products.ToList();
            ViewBag.Products = Products;
            return View();
        }
        [AllowAnonymous]
        public IActionResult Type(string type)
        {            
            var Products = _db.Products.ToList();
            ViewBag.Products = Products;
            if (type == "food")
            {
                ViewData["type"]="Food";
            }
            else if (type == "toys")
            {
                ViewData["type"] = "Toy";
            }
            return View();
        }

    }
}

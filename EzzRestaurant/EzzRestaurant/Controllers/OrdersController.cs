using System.Collections.Generic;
using System.Linq;
using EzzRestaurant.Data;
using EzzRestaurant.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EzzRestaurant.Controllers
{
    public class OrdersController : Controller
    {
        private ApplicationDbContext _db;
        private UserManager<IdentityUser> _userManager;

        public OrdersController(ApplicationDbContext ctx , UserManager<IdentityUser> userManager)
        {
            _db = ctx;
            var userStore = userManager;
        }

        public IActionResult Index(string id)
        {
            var orders = _db.Orders.Where(o => o.UserId == id).ToList();
            if (id == null )
            {
                return View("_NotFound");
            }
            ViewBag.Orders = orders;
            return View();
        }
        
        public IActionResult Details(int id)
        {
            var order = _db.Orders.First(o => o.Id == id);
            var ordprd = _db.OrderProduct.Where(p => p.OrderId == id).ToList();
            var AllProducts = _db.Products.ToList();
            if (id == null || order == null || AllProducts.Count == 0)
            {
                return View("_NotFound");
            }

            List<ProductModel> Products = new List<ProductModel>();
            foreach (var prd in AllProducts)
            {
                foreach (var op in ordprd)
                {
                    if(prd.Id == op.ProductId)
                    {
                        Products.Add(prd);
                        break;
                    }
                }
            }
            ViewBag.Order = order;
            ViewBag.Products = Products;
            return View();
        }
    }
}
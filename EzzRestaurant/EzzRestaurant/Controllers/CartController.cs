using System.Collections.Generic;
using System.Linq;
using EzzRestaurant.Data;
using EzzRestaurant.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace EzzRestaurant.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext _db;
        private UserManager<IdentityUser> _userManager;

        public CartController(ApplicationDbContext ctx , UserManager<IdentityUser> userManager)
        {
            _db = ctx;
            _userManager = userManager;
        }
        // GET
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var cart = _db.Cart.First(c => c.UserId == userId);
            var cartProduct = _db.CartProcucts.Where(p => p.Cart == cart).ToList();
            
            var allProducts = _db.Products.ToList();
            if (userId == null || cart == null || allProducts.Count == 0)
            {
                return View("_NotFound");
            }

            List<ProductModel> Products = new List<ProductModel>();
            foreach (var prd in allProducts)
            {
                foreach (var cp in cartProduct)
                {
                    if(prd.Id == cp.Product.Id)
                    {
                        Products.Add(prd);
                        break;
                    }
                }
            }

            ViewBag.Products = Products;
            ViewBag.Cart = cart;
            return View();
        }
        
        [Authorize]
        [HttpPost]
        public IActionResult DeleteItem( int? id)
        {
            var userId = _userManager.GetUserId(User);
            var product = _db.Products.First(p => p.Id == id);
            var cart = _db.Cart.First(c => c.UserId == userId);
            
            if (id == null || product == null)
            {
                return View("_NotFound");
            }

            var cartprd = _db.CartProcucts.First(cp => cp.Product == product);
            _db.CartProcucts.Remove(cartprd);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
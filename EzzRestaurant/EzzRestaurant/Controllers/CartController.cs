using System.Collections.Generic;
using System.Linq;
using EzzRestaurant.Data;
using EzzRestaurant.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EzzRestaurant.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext _db;
        private UserManager<IdentityUser> _userManager;

        [ActivatorUtilitiesConstructor]
        public CartController(ApplicationDbContext ctx , UserManager<IdentityUser> userManager)
        {
            _db = ctx;
            _userManager = userManager;
        }
        public CartController()
        {
        }
        // GET
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var cart = _db.Cart.First(c => c.UserId == userId);
            var cartProduct = _db.CartProcucts.Where(p => p.Cart == cart)
                .Include(pr => pr.Product).ToList();
            
            var allProducts = _db.Products.ToList();
            if (userId == null || cart == null || allProducts.Count == 0)
            {
                return View("_NotFound");
            }

            List<ProductModel> Products = new List<ProductModel>();
            foreach (var cp in cartProduct)
            {
                Products.Add(cp.Product);
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
            cart.TotalPrice -= product.Price;
            
            _db.CartProcucts.Remove(cartprd);
            _db.Cart.Update(cart);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [Authorize]
        [HttpPost]
        public IActionResult SubmitOrder()
        {
            var userId = _userManager.GetUserId(User);
            var cart = _db.Cart.FirstOrDefault(c => c.UserId == userId);
            var cartProduct = _db.CartProcucts.Where(p => p.Cart == cart)
                .Include(pr => pr.Product).ToList();
            if (cart != null)
            {
                OrderModel order = new OrderModel() {UserId = userId, TotalPrice = cart.TotalPrice};
                order.Products = new List<ProductModel>();
                foreach (var cp in cartProduct) order.Products.Add(cp.Product);
                _db.Orders.Add(order);
                _db.SaveChanges();

                List<OrderProductsModel> ordprd = new List<OrderProductsModel>();
                foreach (var cp in cartProduct)
                {
                    ordprd.Add(new OrderProductsModel(){OrderId = order.Id , Product = cp.Product});
                }
                foreach (var op in ordprd)
                {
                    _db.OrderProduct.Add(op);
   
                }
                _db.SaveChanges();
                foreach (var cp in cartProduct)
                {
                    _db.CartProcucts.Remove(cp);
                }

                cart.TotalPrice = 0;
                _db.Cart.Update(cart);
                _db.SaveChanges();
            }


            // var cartprd = _db.CartProcucts.First(cp => cp.Product == product);
            // _db.CartProcucts.Remove(cartprd);
            
            return RedirectToAction("Index");
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pets_Houses.Data;
using Pets_Houses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets_Houses.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CartController(ApplicationDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            var Cart = _db.Cart.ToList();
            ViewBag.Cart = Cart;
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(int Pid, string u)
        {
            var product = _db.Products.ToList().Find(p => p.Id == Pid);
            var exist = _db.Cart.ToList().Find(p => p.ProductId == Pid);
            if (exist != null)
            {
                exist.Quantity += 1;
                exist.Price += product.Price;
                _db.Cart.Update(exist);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                if ( product == null)
                {
                    return View("_NotFound");
                }
                CartModel cart = new CartModel
                {
                    ProductId = product.Id,
                    ProductName = product.ProductName,
                    Description = product.Description,
                    Image = product.Image,
                    Price = product.Price,
                    Quantity = 1,
                    UserId = u
                };
                _db.Cart.Add(cart);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var product = _db.Cart.ToList().Find(p => p.Id == id);
            if (id == null && product == null)
            {
                return View("_NotFound");
            }
            _db.Cart.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Create_Order([Bind("UserId", "Address", "TotalPrice")] OrderModel Order)
        {
            DateTime localDate = DateTime.Now;
            Order.Date_Time = localDate.ToString();
            if (ModelState.IsValid)
            {
                _db.Orders.Add(Order);
                _db.SaveChanges();
                var Carts = _db.Cart.ToList().FindAll(p => p.UserId == Order.UserId);
                foreach (var cart in Carts)
                {
                    Orders_ProductsModel datails = new Orders_ProductsModel
                    {
                        OrderId = Order.Id,
                        ProductId = cart.ProductId
                    };
                    _db.Orders_Products.Add(datails);
                    _db.SaveChanges();
                    _db.Cart.Remove(cart);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public void Deletex(int id)
        {
            var product = _db.Cart.ToList().Find(p => p.Id == id);
            _db.Cart.Remove(product);
            _db.SaveChanges();
        }
        public int count()
        {
            return _db.Cart.ToList().Count();
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using EzzRestaurant.Data;
using EzzRestaurant.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EzzRestaurant.Controllers
{
    public class ProductsController : Controller
    {
      

        private ApplicationDbContext _db;
        private UserManager<IdentityUser> _userManager;

        public ProductsController(ApplicationDbContext ctx , UserManager<IdentityUser> userManager)
        {
            _db = ctx;
            _userManager = userManager;
        }
        
        
        
        // GET
        public IActionResult Index()
        {
            ViewData["Products"] = _db.Products.ToList();
            return View();
        }
        
        
        // GET : products/Details/id
        public IActionResult Details(int id)
        {
           var product  = _db.Products.First(p => p.Id == id);
            if (id == null || product == null)
            {
                return View("_NotFound");
            }

            ViewBag.Product = product;
            ViewBag.Category = _db.Categories.First(c => c.Id == product.CategoryId);
            return View();
        }

        
        // GET : products/Create
        public IActionResult Create()
        {
            return View();
        }
        
        // POST : products/Create
        [HttpPost]
        public IActionResult Create([Bind("Name" , "Description", "img" ,"CategoryId", "Price")]ProductModel product)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Add(product);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }
        
        // GET : products/Edit/id
        public IActionResult Edit(int? id)
        {
            var product = _db.Products.ToList().Find(p => p.Id == id);
            if (id == null || product == null)
            {
                return View("_NotFound");
            }

            ViewBag.Product = product;
            return View();
        }
        
        // POST : products/Edit/id
        [HttpPost]
        public IActionResult Edit( [Bind("Id","Name" , "Description", "img" ,"CategoryId", "Price")]ProductModel prd)
        {
            _db.Products.Update(prd);
            _db.SaveChanges();
            
            return RedirectToAction("Index");
        }
        
        // POST : products/Delete/id
        [HttpPost]
        public IActionResult Delete( int? id)
        {
            var product = _db.Products.ToList().FirstOrDefault(p => p.Id == id);
            
            if (id == null || product == null)
            {
                return View("_NotFound");
            }
            
            _db.Products.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [Authorize]
        [HttpPost]
        public IActionResult AddToCart( int? id)
        {
            var userId = _userManager.GetUserId(User);
            var product = _db.Products.First(p => p.Id == id);
            var cart = _db.Cart.First(c => c.UserId == userId);
            
            if (id == null || product == null)
            {
                return View("_NotFound");
            }

            var prdCart = new CartProductsModel() {Cart = cart, Product = product};
            cart.TotalPrice += product.Price;
            _db.CartProcucts.Add(prdCart);
            _db.Cart.Update(cart);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
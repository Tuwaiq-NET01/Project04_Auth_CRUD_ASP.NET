using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenLifeStore.Models;
using Microsoft.AspNetCore.Mvc;
using GreenLifeStore.Data;
using Microsoft.EntityFrameworkCore;

namespace GreenLifeStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductsController(ApplicationDbContext db)
        {
            _db = db;
        }


        // GET: /products
        public IActionResult Index()
        {
            var Products = _db.Products.ToList();
            ViewData["Products"] = Products;
            return View();
        }

        // GET: /products/id
        public IActionResult Details(int? id)
        {
            var Product = _db.Products.ToList().Find(product => product.ProductId == id);
            if (id == null || Product == null)
            {
                return View("_NotFound");
            }
            ViewData["Product"] = Product;
            return View(Product);

        }



        //GET - /products/create
        public IActionResult Create()
        {
            return View();
        }

        //POST - /proudcts/create
        [HttpPost]
        public IActionResult Create([Bind("Name", "Price", "Image")] ProductModel product)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Add(product);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }


        //GET- /products/edit/id
        public IActionResult Edit(int? id)
        {
            var Product = _db.Products.ToList().Find(p => p.ProductId == id);
            if (id == null || Product == null)
            {
                return View("_NotFound");
            }
            ViewData["Product"] = Product;
            return View();
        }

        //POST - /products/edit/id
        [HttpPost]
        public IActionResult Edit(int id, [Bind("ProductId", "Name", "Price")] ProductModel product)
        {
            var Product = _db.Products.ToList().Find(p => p.ProductId == id);
            Product.Name = product.Name;
            Product.Price = product.Price;

            _db.Products.Update(Product);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // POST - /products/delete/id
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var Product = _db.Products.ToList().FirstOrDefault(p => p.ProductId == id);
            if (id == null || Product == null)
            {
                return View("_NotFound");
            }
            _db.Products.Remove(Product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details2(int? id)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "GreenLifeStoreTestDB").Options;
            var db = new ApplicationDbContext(options);

            var Product = db.Products.ToList().Find(product => product.ProductId == id);
            if (id == null || Product == null)
            {
                return View("_NotFound");
            }
            ViewData["Product"] = Product;
            return View(Product);

        }
    }
}

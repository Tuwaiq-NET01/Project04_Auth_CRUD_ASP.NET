using Keraa.Data;
using Keraa.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keraa.Controllers
{
    public class ProductsController : Controller
    {

        private readonly ApplicationDbContext _db;

        public ProductsController(ApplicationDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            ViewData["products"] = _db.Products.ToList();
            return View();
        }

        // GET: /products/id
        public IActionResult Details(int? id)
        {
            var Product = _db.Products.ToList().Find(product => product.Id == id);
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
        public async Task<IActionResult> Create([Bind("Name", "ShortDesc", "CoverImage", "Catagory")] ProductModel product)
        {
            if (ModelState.IsValid) //check the state of model
            {
                List<string> Coordinate = await Utilities.GetCurrentCoordinates();
                product.LocationLat = Coordinate[0];
                product.LocationLng = Coordinate[1];
                _db.Products.Add(product);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }


        //GEt - /products/edit/id
        public IActionResult Edit(int? id)
        {
            var Product = _db.Products.ToList().Find(p => p.Id == id);
            if (id == null || Product == null)
            {
                return View("_NotFound");
            }
            ViewData["Product"] = Product;
            return View();
        }

        //POST - /products/edit/id
        [HttpPost]
        public IActionResult Edit([Bind("Id", "Name", "ShortDesc", "CoverImage")] ProductModel prod)
        {
            //var Product = _db.Products.ToList().Find(p => p.Id == id);
            //Product.Name = prod.Name;
            //Product.Description = prod.Description;
            //Product.Price = prod.Price;

            //_db.Products.Update(Product);
            //_db.SaveChanges();
            _db.Products.Update(prod);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // POST - /products/delete/id
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var Product = _db.Products.ToList().FirstOrDefault(p => p.Id == id);
            if (id == null || Product == null)
            {
                return View("_NotFound");
            }
            _db.Products.Remove(Product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

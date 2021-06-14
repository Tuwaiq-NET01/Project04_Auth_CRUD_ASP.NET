using Adoption.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adoption.Data;

namespace Adoption.Controllers
{
    public class AdopterController : Controller
    {
       
            private ApplicationDbContext _db;
            public AdopterController(ApplicationDbContext context)
            {
                _db = context;
            }
            public IActionResult Index(int id)
            {
                var Adopters = _db.adopter.ToList();
                ViewData["Adopters"] = Adopters;
                return View();
            }
            //GET - /Products/create
            public IActionResult Create()
            {
                return View();
            }
            //POST - /Products/create
            [HttpPost]
            public IActionResult Create([Bind("name", "age", "gender", "occupation", "email", "phone")] AdopterModel adopter)
            {
                _db.adopter.Add(adopter);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            //GET- /Products/edit/id
            public IActionResult Edit(int id)
            {
                var adopter = _db.adopter.First(adopter => adopter.id == id);
                if (id == null || adopter == null)
                {
                    return View("Not_Found");
                }
                ViewData["adopter"] = adopter;
                return View();
            }
            // POST
            [HttpPost]
            public IActionResult Edit([Bind("id", "name", "age", "gender", "occupation", "email", "phone")] AdopterModel adopt)
            {
                // if i used this header and passed the id through the URL Edit(int id , [Bind("ProductId", "Name", "Price", "Description")] Product prod)


                /* var Product = _db.Products.ToList().Find(product => product.ProductId == id);
                 Product.Name = prod.Name;
                 Product.Description = prod.Description;
                 Product.Price = prod.Price;

                 _db.Products.Update(Product);
                 _db.SaveChanges();*/

                _db.adopter.Update(adopt);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            //POST /products/delete/id
            public IActionResult Delete(int id)
            {
                var adopter = _db.adopter.First(product => product.id == id);
                _db.adopter.Remove(adopter);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        
    }
}

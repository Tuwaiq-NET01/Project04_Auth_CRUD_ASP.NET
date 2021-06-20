using MaNodelz.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaNodelz.Models;

namespace MaNodelz.Controllers
{
    [AllowAnonymous]
    public class FoodController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FoodController(ApplicationDbContext dp)
        {
            _db = dp;
        }
        public IActionResult Index()
        {
            var food = _db.Food.ToList();
            ViewData["Food"] = food;
            return View(food);
            
        }

        // GET: /Food/Type/?type=""
        public IActionResult Type (string? type="")
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentException($"'{nameof(type)}' cannot be null or whitespace.", nameof(type));
            }
            var TypeMatchs = _db.Food.ToList().Find(details => details.FoodType == type);
            if (type == null || TypeMatchs == null)
            {
                return View("_NotFound");
            }
            ViewData["TypeMatchs"] = TypeMatchs;

            var TypeMatch = _db.Food.ToList().FindAll(details => details.FoodType == type);
            if (type == null || TypeMatch == null)
            {
                return View("_NotFound");
            }
            ViewData["TypeMatch"] = TypeMatch;
            return View(TypeMatch);
        }

        // GET: /Food/id
        public IActionResult Details(int? id)
        {
            var commentsDetails = _db.Comments.ToList().Find(commentsDetails => commentsDetails.Id == id);
            var details = _db.Food.ToList().Find(details => details.Id == id);
            if (id == null || details == null)
            {
                return View("_NotFound");
            }
            var comments = _db.Comments.ToList().FindAll(commentsDetails => commentsDetails.FoodId == id);
            ViewData["comments"] = comments;
            ViewData["CDetails"] = commentsDetails;
            ViewData["Details"] = details;
            return View(details);
        }
        //GET - /Food/create
        public IActionResult Create()
        {
            return View();
        }
        //POST - /Food/create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FoodName,FoodDescription,FoodImage,FoodTobePrepared,FoodType")] FoodModel food)
        {
            if (ModelState.IsValid)
            {
               await _db.Food.AddAsync(food);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }
        //GET - /Food/edit/id
        public IActionResult Edit(int? id)
        {
            var food = _db.Food.ToList().Find(a => a.Id == id);
            if (id == null || food == null)
            {
                return View("_NotFound");
            }
            ViewData["Edit"] = food;
            return View();
        }


        //POST - /Food/edit/id
        [HttpPost]
        public IActionResult Edit([Bind( "FoodName", "FoodDescription", "FoodImage"
                                         ,"FoodTobePrepared","FoodType")] FoodModel food)
        {
            _db.Food.Update(food);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST - /Food/delete/id
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var food = _db.Food.ToList().Find(a => a.Id == id);
            _db.Food.Remove(food);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
       

    }
}

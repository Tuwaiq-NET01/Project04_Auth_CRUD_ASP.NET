using _Platform_.Data;
using _Platform_.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _Platform_.Controllers
{
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public NewsController(ApplicationDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            var News = _db.News.ToList();
            ViewData["News"] = News;
            return View();
        }
        public IActionResult settings()
        {
            var News = _db.News.ToList();
            ViewData["News"] = News;
            return View();
        }
        public IActionResult Details(int? id = 1)
        {
            var News = _db.News.ToList().Find(a => a.Id == id);
            ViewData["News"] = News;

            if (News == null)
            {
                return Content("Not found");
            }
            else
            {
                ViewData["News"] = News;
                return View();
            }
        }
        //GET - /News/Create
        public IActionResult Create()
        {
           /* ViewData["CharityId"] = CharityId;*/
            return View();
        }

        //POST - /News/Create
        [HttpPost]
        public IActionResult Create([Bind("Id", "Subject", "Description", "Image", "CharityId")] News News)
        {
            if (ModelState.IsValid) //check the state of model
            {
                _db.News.Add(News);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(News);
        }
        //GEt - /Charities/Edit/id
        public IActionResult Edit(int? id)
        {
            var News = _db.News.ToList().Find(p => p.Id == id);
            if (id == null || News == null)
            {
                return View("_NotFound");
            }
            ViewData["News"] = News;
            return View();
        }

        //POST - /News/edit/id
        [HttpPost]
        public IActionResult Edit([Bind("Id", "Subject", "Description", "Image", "CharityId")] News News)
        {

            _db.News.Update(News);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // POST - /News/delete/id
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var News = _db.News.ToList().FirstOrDefault(d => d.Id == id);
            if (id == null || News == null)
            {
                return View("_NotFound");
            }
            _db.News.Remove(News);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

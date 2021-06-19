using Final_Project.Data;
using Final_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Controllers
{
    [Authorize]
    public class LessorsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public LessorsController(ApplicationDbContext context)
        {
            _db = context;
        }

        /*public LessorsController()
        {
        }
*/
        public ViewResult Index1()
        {
            return View();
        }

        public IActionResult Index()
        {
            var lessors = _db.Lessors.ToList();
            ViewData["Lessors"] = lessors;

            return View();
        }


        public IActionResult Details(int? id)
        {
            var lessors = _db.Lessors.ToList().Find(lessors => lessors.Id == id);
            ViewData["Lessors"] = lessors;
            return View(lessors);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("Id", "Name","Email" , "PhoneNum")] LessorModel lessors)
        {
            _db.Lessors.Add(lessors); ;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var lessors = _db.Lessors.ToList().Find(p => p.Id == id);
            return View(lessors);
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id", "Name", "Email", "PhoneNum")] LessorModel lessors)
        {
            _db.Lessors.Update(lessors);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var lessors = _db.Lessors.ToList().Find(p => p.Id == id);
            _db.Lessors.Remove(lessors);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

using finalProject.Data;
using finalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace finalProject.Controllers
{
    public class InformationController : Controller
    {
        private readonly ApplicationDbContext _db;
        private object routes;

        public InformationController(ApplicationDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            
            var Information = _db.Information.ToList();
            ViewData["Information"] = Information;
            return View();
        }

        // GET: /Information/details/id
        public IActionResult Details(int? id)
        {
            var Information = _db.Information.Where(c => c.course_id == id).ToList();
            ViewData["Information"] = Information;
            return View();
        }

        //GET: /Information/create
        public IActionResult Create(int ? id)
        {

            ViewData["course_id"] = id;
            return View();
        }

        //POST: /Information/create/course_id
        [HttpPost]
        public IActionResult Create(int id , [Bind( "title", "url", "about")] InfoModel Information)
        {
            Information.course_id = id;

            _db.Information.Add(Information);
                _db.SaveChanges();
                return RedirectToAction("details", "courses", new { id = Information.course_id });
        }
 
        //GET: /Information/edit/id
        public IActionResult Edit(int id)
        {
            var Information = _db.Information.ToList().Find(I => I.id == id);
           // if (Information == null) return NotFound("Invalid course info ID");
            ViewData["Information"] = Information;
            return View();
        }

        //POST:  /Information/edit/id
        [HttpPost]
        public IActionResult Edit(int ID , [Bind( "title", "url", "about" , "course_id")] InfoModel Information)
        {
            var info = _db.Information.ToList().Find(I => I.id == ID);
            info.title = Information.title;
            info.url = Information.url;
            info.about = Information.about;
            info.course_id = Information.course_id;

            _db.Information.Update(info);
            _db.SaveChanges();
            return RedirectToAction("details", "courses" , new { id = info.course_id });
        }

        // POST : /Information/delete/id

        public IActionResult Delete(int? ID)
        {
            var information = _db.Information.ToList().Find(I => I.id == ID);

            if (ID == null || information == null )
            {

                return Content("Not Found");
            }

            _db.Information.Remove(information);
            _db.SaveChanges();
            return RedirectToAction("details", "courses", new { id = information.course_id });
        }
        //For Testing
        public IActionResult EditTest(int? id)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
             .UseInMemoryDatabase(databaseName: "TestInfo").Options;
            var db = new ApplicationDbContext(options);


            var Information = db.Information.ToList().Find(I => I.id == id);
            if (id == null || Information == null) { return View("_NotFound"); }
            else
            {
                ViewData["Information"] = Information;
                return View("Index");
            }
        }
    }
}

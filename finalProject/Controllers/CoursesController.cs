using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using finalProject.Data;
using finalProject.Models;
using System.Security.Claims;

namespace finalProject.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CoursesController(ApplicationDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            var userId = User.FindFirst(ClaimTypes.Email);
            var Profile = _db.Profiles.FirstOrDefault(u => u.email == userId.Value);

            var courses = _db.Courses.Where(p => p.Profiles.id == Profile.id).ToList();
            if (courses == null)
            {
                return NotFound("There is no such course");
            }
            ViewData["courses"] = courses;

            /*  var courses = _db.Courses.ToList();
              ViewData["courses"] = courses;*/
            var Information = _db.Information.ToList();
            ViewData["Information"] = Information;
            return View();
        }

        // GET - /courses/details/id
        public IActionResult Details(int? id)
        {

            var course = _db.Courses.First(c => c.id == id);

            if (course == null) return NotFound("There is no such course");

            ViewData["course"] = course;
            var Information = _db.Information.Where(Info => Info.course_id == id ).ToList();
            ViewData["Information"] = Information;

            return View();
        }

        //GET: /courses/create
        public IActionResult Create()
        {
            var userId = User.FindFirst(ClaimTypes.Email);
            var Profile = _db.Profiles.FirstOrDefault(p => p.email == userId.Value);
            ViewData["Profile"] = Profile.id;
            return View();
        }

        //POST: /courses/create 
        [HttpPost]
        public IActionResult Create([Bind("subject" , "imgurl" , "ProfileId")] CoursesModel course)
        {

                _db.Courses.Add(course);
                _db.SaveChanges();
                return RedirectToAction("Index");
           
        }
        //GET: /courses/edit/id
        public IActionResult Edit(int id)
        {
            var course = _db.Courses.First(c => c.id == id);

            if (course == null) return NotFound("There is no such course");

            ViewData["course"] = course;
            return View();
        }

        //POST:  /courses/edit/id
        [HttpPost]
        public IActionResult Edit(int ID , [Bind("subject" , "imgurl" )] CoursesModel course)
        {
            var Course = _db.Courses.First(c => c.id == ID);
            Course.subject = course.subject;
            Course.imgurl = course.imgurl;

            _db.Courses.Update(Course);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST : /courses/delete/id
        public IActionResult Delete(int? id)
        {
            var course = _db.Courses.First(c => c.id == id);
            if (id == null || course == null)
            {
                return NotFound("There is no such course");
            }
            _db.Courses.Remove(course);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IList<CoursesModel> Execute()
        {
            return _db.Courses.ToList();
        }

    }
}

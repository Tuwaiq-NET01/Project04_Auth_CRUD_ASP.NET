using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechME_Dashboard.Data;
using TechME_Dashboard.Models;

namespace TechME_Dashboard.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize/*(Roles = "User")*/]

    public class TraineesController : Controller
    {
        private readonly TechMEDbContext _db;

        public TraineesController(TechMEDbContext context)
        {
            _db = context;
        }
        public IActionResult Index(int ID = 1) // هل لازم  زم يكون فية Id او لا
        {
            var Trainee = _db.Trainee.ToList();
            ViewData["Trainee"] = Trainee;
            ViewData["ID"] = ID;

            return View();
        }
        // GET: Trainee/ID
        [HttpGet]
        public IActionResult Details(int? ID)
        {
            var Trainee = _db.Trainee.ToList().Find(Trainee => Trainee.Trainee_ID == ID);
            if (ID == null || Trainee == null)
            {
                return View("_NotFound");
            }
            ViewData["Trainee"] = Trainee;
            return View(Trainee);
        }
        // Create
        //GET - /Trainee/create
        public IActionResult Create()
        {
            return View();
        }
        //POST - /Trainee/create
        [HttpPost]
        public IActionResult Create([Bind("Trainee_Name", "Trainee_BIO","Trainee_Image")] TraineeModel Trainees)
        {
            if (ModelState.IsValid) //check the state of modelSS
            {
                _db.Trainee.Add(Trainees);
                _db.SaveChanges();

            }
            return View(Trainees);


        }
        //GEt - /Trainee/edit/id
        public IActionResult Edit(int? ID)
        {
            var Trainee = _db.Trainee.ToList().Find(T => T.Trainee_ID == ID);
            if (ID == null || Trainee == null)
            {
                return View("_NotFound");
            }
            ViewData["Trainee"] = Trainee;
            return View();
        }
        //POST - /Trainee/edit/id
        [HttpPost]
        public IActionResult Edit(int ID, [Bind("Trainee_ID", "Trainee_Name", "Trainee_BIO", "Trainee_Image")] TraineeModel Trainee)
        {
            _db.Trainee.Update(Trainee);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }



        // POST - /Trainee/delete/id
        [HttpPost]
        public IActionResult Delete(int ID)
        {
            var Trainee = _db.Trainee.ToList().FirstOrDefault(T => T.Trainee_ID == ID);
      
            _db.Trainee.Remove(Trainee);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

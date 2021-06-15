using Microsoft.AspNetCore.Mvc;
using Musicify.Data;
using Musicify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicify.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProfilesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var Profiles = _db.Profiles.ToList();
            ViewData["Profiles"] = Profiles;
            return View();
        }

        // GET: /Profiles/id
        public IActionResult Details(int? id)
        {
            var Profiles = _db.Profiles.ToList().Find(Profiles => Profiles.Id == id);
            if (id == null || Profiles == null)
            {
                return View("_NotFound");
            }
            ViewData["Profiles"] = Profiles;
            return View(Profiles);

        }

        // Create

        // GET: /Profiles/create
        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }

        /*// Post: /Profiles/create
        [HttpPost]
        public IActionResult Create([Bind("Id", "Name", "Bio", "Photo", "UserId")] ProfileModel Profiles)
        {
            // if for validations
            if (ModelState.IsValid)
            {
                _db.Profiles.Add(Profiles);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Profiles);
        }*/

        // Updte

        // GET: /Profiles/edit/id
        public IActionResult Edit(int? id)
        {
            var Profiles = _db.Profiles.ToList().Find(p => p.Id == id);
            if (id == null || Profiles == null)
            {
                return View("_NotFound");
            }
            ViewData["Profiles"] = Profiles;
            return View();
        }

        // POST: /Profiles/edit/id
        [HttpPost]
        public IActionResult Edit([Bind("Id", "Name", "Bio", "Photo", "UserId")] ProfileModel Profiles)
        {
            _db.Profiles.Update(Profiles);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: /Singers/delete/id
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var Profiles = _db.Profiles.ToList().Find(p => p.Id == id);
            if (id == null || Profiles == null)
            {
                return View("_NotFound");
            }
            _db.Profiles.Remove(Profiles);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

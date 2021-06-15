using HealthChoice_Final_crud_auth.Data;
using HealthChoice_Final_crud_auth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthChoice_Final_crud_auth.Controllers
{
   
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ServicesController(ApplicationDbContext context)
        {
            _db = context;
        }

        //<<Read>>
        //Get: /Services
        public IActionResult Index()
        {
            if (true)
            {

            }
            var Services = _db.Services.ToList();
            ViewData["Services"] = Services;
            return View();
        }

        //Get: /Artists/details/id


        public IActionResult Details(int? id)
        {
            var Services = _db.Services.ToList().Find(s=>s.Id == id);
            if (id == null || Services == null)
            {
                return View("_NotFound");
            }
            ViewData["Services"] = Services;

            return View();
        }

        //<<Create>>
        //GET: /services/create
        public IActionResult Create()
        {
            return View("Create");

        }

        [Authorize]
        //Post -/services/create
        [HttpPost]
        public IActionResult Create([Bind("servName", "servOverview", "servLogo", "servWebsite", "servLocation", "servType")] ServicesModel service)
        {
            if (ModelState.IsValid) //validation check the state of the model
            {
                _db.Services.Add(service);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }



            return View(service);
        }
        [Authorize]

        //GEt: /services/edit/id
        public IActionResult Edit(int? id)
        {
            var Service = _db.Services.ToList().Find(s => s.Id == id);
            if (id == null || Service == null)
            {
                return View("_NotFound");
            }
            ViewData["Service"] = Service;
            return View();
        }

        //Post: /services/edit/id
        [HttpPost] 
        public IActionResult Edit(int id, [Bind("servName", "servOverview", "servLogo", "servWebsite", "servLocation", "servType")] ServicesModel service)
        {
            var Service = _db.Services.ToList().Find(s => s.Id == id);
            // update new vals
            Service.servName = service.servName;
            Service.servOverview = service.servOverview;
            Service.servLogo = service.servLogo;
            Service.servWebsite = service.servWebsite;
            Service.servLocation = service.servLocation;
            Service.servType = service.servType;



            _db.Services.Update(Service);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }

        [Authorize]

        //POST - /services/delete/id
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var service = _db.Services.ToList().FirstOrDefault(s => s.Id == id);


            _db.Services.Remove(service);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }


    }
}




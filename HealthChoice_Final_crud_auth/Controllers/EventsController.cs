using HealthChoice_Final_crud_auth.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthChoice_Final_crud_auth.Controllers
{
    public class EventsController : Controller
    {

        private readonly ApplicationDbContext _db;

        public EventsController(ApplicationDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            var Events = _db.Events.ToList();
      
            ViewData["Events"] = Events;
         

            return View();
        }

        //Get: /Events/details/id


        public IActionResult Details(int? id)
        {
            var Events = _db.Events.ToList().Find(e => e.Id == id);
            if (id == null || Events == null)
            {
                return View("_NotFound");
            }
            ViewData["Events"] = Events;
         
            return View();
        }
    }
}

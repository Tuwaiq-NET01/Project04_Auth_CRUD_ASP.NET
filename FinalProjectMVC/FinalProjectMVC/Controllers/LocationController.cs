using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectMVC.Controllers
{
    public class LocationController : Controller
    {
        
        // GET: /Location/ 
        public IActionResult Index()
        {
            return View("Index");
        }
        public ActionResult Details()
        {
            return View();
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Final_project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Controllers
{
    public class ParkingController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ParkingController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            var Parking = _db.Parkings.ToList();
            ViewData["Parking"] = Parking;
            return View();
        }

    }
}

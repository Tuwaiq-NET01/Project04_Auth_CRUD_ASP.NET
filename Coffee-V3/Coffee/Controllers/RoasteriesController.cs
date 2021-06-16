using Coffee.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.Controllers
{
    public class RoasteriesController : Controller
    {
        private readonly AppDbContext _db;

        public RoasteriesController(AppDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            var Roasteries = _db.Roasteries.ToList();
            ViewData["Roasteries"] = Roasteries;
            return View();
        }
        public IActionResult Details(int? id)
        {
            var Roastery = _db.Roasteries.ToList().Find(a => a.ID == id);
            ViewData["Roastery"] = Roastery;

            var Bean = _db.Beans.Where(b => b.RoasterID == id).ToList();
            ViewData["Bean"] = Bean;

            return View();
        }
     
    }
}

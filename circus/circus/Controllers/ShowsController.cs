using circus.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace circus.Controllers
{
    public class ShowsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ShowsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            ViewData["shows"] = _db.Shows.ToList();
            ViewData["performers"] = _db.Performers.ToList();
            ViewData["venues"] = _db.Venues.ToList();

            return View();
        }
        public IActionResult Details(int? id)
        {
            ViewData["show"] = _db.Shows.ToList().Find(x=> x.Id == id);
            ViewData["performers"] = _db.Performers.ToList();
            ViewData["venues"] = _db.Venues.ToList();
            return View();
        }

    }
}

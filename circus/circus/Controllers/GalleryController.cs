using circus.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace circus.Controllers
{
    public class GalleryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public GalleryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            ViewData["performers"] = _db.Performers.ToList();
            ViewData["venues"] = _db.Venues.ToList();
            return View();
        }
    }
}

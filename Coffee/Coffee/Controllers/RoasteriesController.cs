using Coffee.Data;
using Microsoft.AspNetCore.Mvc;
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
    }
}

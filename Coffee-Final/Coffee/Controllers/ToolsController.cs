using Coffee.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.Controllers
{
    public class ToolsController : Controller
    {
        private readonly AppDbContext _db;

        public ToolsController(AppDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            var Tools = _db.Tools.ToList();
            ViewData["Tools"] = Tools;
            return View();
        }
        public IActionResult Search(string txt)
        {
            var aa = _db.Tools.Where(ID => ID.Name.Contains(txt)).ToList();
            ViewBag.Tools = aa;
            return View("Index");
        }
    }
}

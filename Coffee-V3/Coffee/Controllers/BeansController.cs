using Coffee.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.Controllers
{
    public class BeansController : Controller
    {
        private readonly AppDbContext _db;

        public BeansController(AppDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            var Beans = _db.Beans.ToList();
            ViewData["Beans"] = Beans;
            return View();
        }
       
    }
}

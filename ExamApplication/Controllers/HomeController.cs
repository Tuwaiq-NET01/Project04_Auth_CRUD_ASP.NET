using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamApplication.Data;
using ExamApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDbContext _db;

        public HomeController()
        {
            _db = new MyDbContext();
        }
        public IActionResult Index()
        {
            return View("Index");
        }

    }
}

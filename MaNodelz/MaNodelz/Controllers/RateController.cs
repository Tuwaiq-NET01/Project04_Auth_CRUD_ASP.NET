using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaNodelz.Controllers
{
    public class RateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaNodelz.Models;
using MaNodelz.Data;

namespace MaNodelz.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Details", "Food");
        }
    }
}

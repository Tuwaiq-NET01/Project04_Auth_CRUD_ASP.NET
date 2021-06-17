using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamApplication.Controllers
{
    [Authorize]
    public class AuthorizeStudentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
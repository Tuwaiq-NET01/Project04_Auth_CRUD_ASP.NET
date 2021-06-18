using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenLifeStore.Controllers
{
    public class PrivacyController : Controller
    {


        [AllowAnonymous]
        public IActionResult Index()
        {

            return View("Index");

        }

    }
}
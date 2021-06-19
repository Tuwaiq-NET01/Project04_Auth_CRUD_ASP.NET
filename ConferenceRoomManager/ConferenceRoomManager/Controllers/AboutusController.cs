using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceRoomManager.Controllers
{
    [AllowAnonymous]
    public class AboutusController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}

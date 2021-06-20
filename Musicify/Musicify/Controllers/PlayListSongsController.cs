using Microsoft.AspNetCore.Mvc;
using Musicify.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicify.Controllers
{
    public class PlayListSongsController : Controller
    {
        private readonly ApplicationDbContext _db;
        

        public PlayListSongsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            return View();

        }
    }
}

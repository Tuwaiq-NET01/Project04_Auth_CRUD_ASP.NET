using GreenLifeStore.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenLifeStore.Controllers
{
    public class BranchesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BranchesController(ApplicationDbContext db)
        {
            _db = db;
        }


        [AllowAnonymous]
        public IActionResult Index()
        {
            var Branches = _db.Branches.ToList();
            ViewData["Branches"] = Branches;
            return View();
        }



    }
}

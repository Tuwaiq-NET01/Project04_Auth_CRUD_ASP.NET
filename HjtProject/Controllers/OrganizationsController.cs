using HjtProject.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HjtProject.Controllers
{
    [Authorize]
    public class OrganizationsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public OrganizationsController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: /Organizations
        public IActionResult Index()
        {
            var organizations = _db.Organizations.ToList();
            ViewData["organizations"] = organizations;
            return View();
        }

        // GET: /Organizations/id
        public IActionResult Details(int? id)
        {
            var organization = _db.Organizations.ToList().Find(organization => organization.Id == id);
            if (id == null || organization == null)
            {
                return View("_NotFound");
            }
            ViewData["organization"] = organization;
            return View(organization);

        }
    }
}

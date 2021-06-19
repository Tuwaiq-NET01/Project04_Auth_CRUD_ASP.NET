using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pets_Houses.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets_Houses.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext context)
        {
            _db = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Posts()
        {
            var PetsInfo = _db.Pets.ToList();
            ViewData["PetsInfo"] = PetsInfo;
            return View();
        }
        [Authorize]
        public IActionResult Orders()
        {
            var Orders = _db.Orders.ToList();
            ViewData["Orders"] = Orders;
            return View();
        }
        public IActionResult OrderDetails(int order)
        {
            var details = _db.Orders_Products.ToList().FindAll(p => p.OrderId == order);
            ViewData["details"] = details;
            return View();
        }
    }
}

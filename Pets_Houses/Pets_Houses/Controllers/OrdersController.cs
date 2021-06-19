using Microsoft.AspNetCore.Mvc;
using Pets_Houses.Data;
using Pets_Houses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets_Houses.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public OrdersController(ApplicationDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            return View("Index");
        }
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var Order = _db.Orders.ToList().Find(p => p.Id == id);
            if (id == null && Order == null)
            {
                return View("_NotFound");
            }
            _db.Orders.Remove(Order);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

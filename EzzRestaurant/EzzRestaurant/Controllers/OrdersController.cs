using System.Linq;
using EzzRestaurant.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EzzRestaurant.Controllers
{
    public class OrdersController : Controller
    {
        private ApplicationDbContext _db;
        UserManager<IdentityUser> userManager;

        public OrdersController(ApplicationDbContext ctx)
        {
            _db = ctx;
            var userStore = new UserStore<IdentityUser>(_db);
        }

        public IActionResult Index(string id)
        {
            var orders = _db.Orders.Where(o => o.UserId == id).ToList();
            if (id == null )
            {
                return View("_NotFound");
            }
            ViewBag.Orders = orders;
            return View();
        }
    }
}
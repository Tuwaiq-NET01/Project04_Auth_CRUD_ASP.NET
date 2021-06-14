using EzzRestaurant.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EzzRestaurant.Controllers
{
    public class OrderController
    {
        private ApplicationDbContext _db;

        public OrderController(ApplicationDbContext ctx)
        {
            _db = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
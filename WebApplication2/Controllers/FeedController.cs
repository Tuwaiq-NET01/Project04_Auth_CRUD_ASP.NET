using Microsoft.AspNetCore.Mvc;
using WebApplication2.Helpers;

namespace WebApplication2.Controllers
{
    public class FeedController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return Ok("success");
        }
    }
}
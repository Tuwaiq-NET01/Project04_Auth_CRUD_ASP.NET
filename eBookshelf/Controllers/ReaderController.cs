using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using eBookshelf.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eBookshelf.Controllers
{
    public class ReaderController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ReaderController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("ebook/reader/{id:int}")]
        // GET: /<controller>/
        public async Task<IActionResult> Index(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ebookModel = await _context.eBooks
                     .Include(e => e.Owner)
                     .Where(e => e.Owner.Id == User.FindFirstValue(ClaimTypes.NameIdentifier))
                     .FirstOrDefaultAsync(m => m.Id == id);

            if (ebookModel == null)
            {
                return NotFound();
            }

            ViewBag.path = ebookModel.ContentUrl;
            return View();
        }
        
    }
}

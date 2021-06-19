using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBv3.Data;
using WEBv3.Models;

namespace WEBv3.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AllToursController : ControllerBase
    {

        private readonly ApplicationDbContext _db;


        public AllToursController(ApplicationDbContext context)
        {
            _db = context;

        }

        /* // GET: api/Tours
         [HttpGet]
         public async Task<ActionResult<IEnumerable<Tour>>> GetTours()
         {
             return await _db.Tours.ToListAsync();

         }*/

        // GET: api/Tours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tour>>> GetTours()
        {
            return await _db.Tours.Select(x => new Tour()
            {
                TourId = x.TourId,
                Place = x.Place,
                Description = x.Description,
                ImageSrc = String.Format("{0}://{1}{2}/TourImages/{3}", Request.Scheme, Request.Host, Request.PathBase, x.Image)
            }).ToListAsync();
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Tour>> GetOne([FromRoute] int id)
        {

            var tour = await _db.Tours.Include(i => i.Included).FirstOrDefaultAsync(t => t.TourId == id);
            //   IQueryable<Tour> tours = _db.Tours.Where(t => t.TourId == id);
            tour.ImageSrc = String.Format("{0}://{1}{2}/TourImages/{3}", Request.Scheme, Request.Host, Request.PathBase, tour.Image);

            if (tour == null)
            {
                return NotFound();
            }

            return tour;
        }
    }
}










 
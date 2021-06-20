using WEBv3.Data;
using WEBv3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace WEBv3.Controllers
{

   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TourBookings : ControllerBase
    {

        private readonly ApplicationDbContext _db;
        public TourBookings(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBooking([FromRoute] int id)
        {
            return await _db.Bookings.Where(t => t.TourId == id).ToListAsync();
        }

    }





}

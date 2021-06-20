using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TuwaiqCVMaker.Data;
using TuwaiqCVMaker.Models;

namespace TuwaiqCVMaker.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BillsController : ControllerBase
    {
        private ApplicationDbContext _db;

        public BillsController(ApplicationDbContext db)
        {
            this._db = db;
        }
        
        // GET: api/v1/Bills
        [HttpGet]
        public async Task<ActionResult<List<Bill>>> Get()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await this._db.Bills.Where(bill => bill.UserId == userId).ToListAsync());
        }

        // GET: api/v1/Bills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bill>> Get(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var bill = await this._db.Bills.FirstOrDefaultAsync(bill => bill.UserId == userId && bill.Id == id);
            
            if (bill == null)
                return NotFound();
            
            return Ok(bill);
        }

        /*// POST: api/v1/Bills
        [HttpPost]
        public void Post([FromBody] Bill bill)
        {
        }

        // PUT: api/v1/Bills/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Bill bill)
        {
        }

        // DELETE: api/v1/Bills/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}

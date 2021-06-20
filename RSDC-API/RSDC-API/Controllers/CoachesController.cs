using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RSDC_API.Data;

namespace RSDC_API.Controllers
{
    [Route("api/[controller]")] // api/Coaches
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CoachesController : ControllerBase
    {
        private readonly RSDCContext _context;

        public CoachesController(RSDCContext context)
        {   
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCoaches()
        {
            var members = await _context.Coaches.ToListAsync();
            return Ok(members);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoach(Coach data)
        {
            if(ModelState.IsValid)
            {
                await _context.Coaches.AddAsync(data);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCoach", new {data.Id}, data);
            }

            return new JsonResult("Something went wrong") {StatusCode = 500};
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoach(int id)
        {
            var member = await _context.Coaches.FirstOrDefaultAsync(x => x.Id == id);

            if(member == null)
                return NotFound();

            return Ok(member);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCoach(int id, Coach member)
        {
            if(id != member.Id)
                return BadRequest();

            var existCoach = await _context.Coaches.FirstOrDefaultAsync(x => x.Id == id);

            if(existCoach == null)
                return NotFound();

            existCoach.FirstName = member.FirstName;
            existCoach.LastName = member.LastName;
            existCoach.Username = member.Username;
            existCoach.Email = member.Email;
            existCoach.Password = member.Password;
            existCoach.Phone = member.Phone;
            existCoach.StartDate = member.StartDate;
            existCoach.Gender = member.Gender;
            existCoach.Image = member.Image;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoach(int id)
        {
            var existCoach = await _context.Coaches.FirstOrDefaultAsync(x => x.Id == id);

            if(existCoach == null)
                return NotFound();

            _context.Coaches.Remove(existCoach);
            await _context.SaveChangesAsync();

            return Ok(existCoach);
        }
    }
}
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RSDC_API.Data;

namespace RSDC_API.Controllers
{
    [Route("api/[controller]")] // api/Tournaments
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TournamentsController : ControllerBase
    {
        private readonly RSDCContext _context;

        public TournamentsController(RSDCContext context)
        {   
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTournaments()
        {
            var members = await _context.Tournaments.ToListAsync();
            return Ok(members);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTournament(Tournament data)
        {
            if(ModelState.IsValid)
            {
                await _context.Tournaments.AddAsync(data);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetTournament", new {data.Id}, data);
            }

            return new JsonResult("Something went wrong") {StatusCode = 500};
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTournament(int id)
        {
            var member = await _context.Tournaments.FirstOrDefaultAsync(x => x.Id == id);

            if(member == null)
                return NotFound();

            return Ok(member);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTournament(int id, Tournament member)
        {
            if(id != member.Id)
                return BadRequest();

            var existTournament = await _context.Tournaments.FirstOrDefaultAsync(x => x.Id == id);

            if(existTournament == null)
                return NotFound();

            existTournament.TourName = member.TourName;
            existTournament.Year = member.Year;
            existTournament.TourType = member.TourType;
            existTournament.MemberId = member.MemberId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournament(int id)
        {
            var existTournament = await _context.Tournaments.FirstOrDefaultAsync(x => x.Id == id);

            if(existTournament == null)
                return NotFound();

            _context.Tournaments.Remove(existTournament);
            await _context.SaveChangesAsync();

            return Ok(existTournament);
        }
    }
}
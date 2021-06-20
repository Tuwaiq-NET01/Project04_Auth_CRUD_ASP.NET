using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RSDC_API.Data;

namespace RSDC_API.Controllers
{
    [Route("api/[controller]")] // api/Members
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MembersController : ControllerBase
    {
        private readonly RSDCContext _context;

        public MembersController(RSDCContext context)
        {   
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetMembers()
        {
            var members = await _context.Members.ToListAsync();
            return Ok(members);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMember(Member data)
        {
            if(ModelState.IsValid)
            {
                await _context.Members.AddAsync(data);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetMember", new {data.Id}, data);
            }

            return new JsonResult("Something went wrong") {StatusCode = 500};
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMember(int id)
        {
            var member = await _context.Members.FirstOrDefaultAsync(x => x.Id == id);

            if(member == null)
                return NotFound();

            return Ok(member);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMember(int id, Member member)
        {
            if(id != member.Id)
                return BadRequest();

            var existMember = await _context.Members.FirstOrDefaultAsync(x => x.Id == id);

            if(existMember == null)
                return NotFound();

            existMember.FirstName = member.FirstName;
            existMember.LastName = member.LastName;
            existMember.Username = member.Username;
            existMember.Email = member.Email;
            existMember.Password = member.Password;
            existMember.Phone = member.Phone;
            existMember.StartDate = member.StartDate;
            existMember.Gender = member.Gender;
            existMember.Image = member.Image;
            existMember.CoachId = member.CoachId;
            existMember.TypeId = member.TypeId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var existMember = await _context.Members.FirstOrDefaultAsync(x => x.Id == id);

            if(existMember == null)
                return NotFound();

            _context.Members.Remove(existMember);
            await _context.SaveChangesAsync();

            return Ok(existMember);
        }
    }
}
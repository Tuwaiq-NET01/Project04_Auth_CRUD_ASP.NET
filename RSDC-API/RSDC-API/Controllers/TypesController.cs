using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RSDC_API.Data;

namespace RSDC_API.Controllers
{
    [Route("api/[controller]")] // api/Types
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TypesController : ControllerBase
    {
        private readonly RSDCContext _context;

        public TypesController(RSDCContext context)
        {   
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTypes()
        {
            var members = await _context.Types.ToListAsync();
            return Ok(members);
        }

        [HttpPost]
        public async Task<IActionResult> CreateType(Type data)
        {
            if(ModelState.IsValid)
            {
                await _context.Types.AddAsync(data);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetType", new {data.Id}, data);
            }

            return new JsonResult("Something went wrong") {StatusCode = 500};
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetType(int id)
        {
            var member = await _context.Types.FirstOrDefaultAsync(x => x.Id == id);

            if(member == null)
                return NotFound();

            return Ok(member);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateType(int id, Type member)
        {
            if(id != member.Id)
                return BadRequest();

            var existType = await _context.Types.FirstOrDefaultAsync(x => x.Id == id);

            if(existType == null)
                return NotFound();

            existType.Fee = member.Fee;
            existType.DivingType = member.DivingType;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteType(int id)
        {
            var existType = await _context.Types.FirstOrDefaultAsync(x => x.Id == id);

            if(existType == null)
                return NotFound();

            _context.Types.Remove(existType);
            await _context.SaveChangesAsync();

            return Ok(existType);
        }
    }
}
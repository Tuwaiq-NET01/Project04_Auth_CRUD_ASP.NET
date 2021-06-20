using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RSDC_API.Data;

namespace RSDC_API.Controllers
{
    [Route("api/[controller]")] // api/Stores
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class StoresController : ControllerBase
    {
        private readonly RSDCContext _context;

        public StoresController(RSDCContext context)
        {   
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetStores()
        {
            var members = await _context.Stores.ToListAsync();
            return Ok(members);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStore(Store data)
        {
            if(ModelState.IsValid)
            {
                await _context.Stores.AddAsync(data);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetStore", new {data.Id}, data);
            }

            return new JsonResult("Something went wrong") {StatusCode = 500};
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStore(int id)
        {
            var member = await _context.Stores.FirstOrDefaultAsync(x => x.Id == id);

            if(member == null)
                return NotFound();

            return Ok(member);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStore(int id, Store member)
        {
            if(id != member.Id)
                return BadRequest();

            var existStore = await _context.Stores.FirstOrDefaultAsync(x => x.Id == id);

            if(existStore == null)
                return NotFound();

            existStore.Title = member.Title;
            existStore.Image = member.Image;
            existStore.Description = member.Description;
            existStore.Price = member.Price;
            existStore.TypeId = member.TypeId;
        
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore(int id)
        {
            var existStore = await _context.Stores.FirstOrDefaultAsync(x => x.Id == id);

            if(existStore == null)
                return NotFound();

            _context.Stores.Remove(existStore);
            await _context.SaveChangesAsync();

            return Ok(existStore);
        }
    }
}
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
    public class ResumesController : ControllerBase
    {
        private ApplicationDbContext _db;

        public ResumesController(ApplicationDbContext db)
        {
            this._db = db;
        }
        
        // GET: api/v1/Resumes
        [HttpGet]
        public async Task<ActionResult<List<Resume>>> Get()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await this._db.Resumes.Where(v => v.UserId == userId).Include(resume => resume.Skills).ToListAsync());
        }

        // GET: api/v1/Resumes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Resume>> Get(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var resume = await this._db.Resumes.Include(resume => resume.Skills).FirstOrDefaultAsync(v => v.Id == id);

            if (resume == null)
                return NotFound();
            
            if (resume.UserId != userId)
                return Unauthorized();
            
            return Ok(resume);
        }

        // POST: api/v1/Resumes
        [HttpPost]
        public async Task<ActionResult<Resume>> Post([FromBody] Resume resume)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await this._db.Users.FirstOrDefaultAsync(user => user.Id == userId);
            user.Resumes.Add(resume);
            resume.UserId = user.Id;
            await this._db.Resumes.AddAsync(resume);
            await this._db.SaveChangesAsync();
            return Created($"api/v1/resumes", resume);
        }

        // PUT: api/v1/Resumes/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Resume>> Put(int id, [FromBody] Resume input)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var resume = await this._db.Resumes.Include(v => v.Skills).FirstOrDefaultAsync(v => v.Id == id);

            if (resume == null)
                return NotFound();
            
            if (resume.UserId != userId)
                return Unauthorized();

            resume.Copy(input);
            await this._db.SaveChangesAsync();
            return Ok(resume);
        }

        // DELETE: api/v1/Resumes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var resume = await this._db.Resumes.FirstOrDefaultAsync(v => v.Id == id);
            
            if (resume == null)
                return NotFound();
            
            if (resume.UserId != userId)
                return Unauthorized();

            this._db.Resumes.Remove(resume);
            await this._db.SaveChangesAsync();
            return Ok();
        }
    }
}

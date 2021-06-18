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
    [Route("api/v1/resumes/{resumeId:int}/[controller]")]
    public class SkillsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _db;
        
        public SkillsController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            this._db = db;
            this._userManager = userManager;
        }
        
        // GET: api/v1/Resumes/{resumeId}/Skills
        [HttpGet]
        public async Task<ActionResult<List<Skill>>> Get([FromRoute] int resumeId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var resume = await this._db.Resumes.Include(value => value.Skills)
                .FirstOrDefaultAsync(value => value.Id == resumeId);

            if (resume == null)
                return NotFound();

            if (resume.UserId != userId)
                return Unauthorized();
            
            return Ok(resume.Skills.ToList());
        }

        // GET: api/v1/Resumes/{resumeId}/Skills/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Skill>> Get([FromRoute] int resumeId, int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var resume = await this._db.Resumes.FirstOrDefaultAsync(value => value.Id == resumeId);

            if (resume == null)
                return NotFound();

            if (resume.UserId != userId)
                return Unauthorized();

            var skill = await this._db.Skills.FirstOrDefaultAsync(value => value.Id == id);

            if (skill == null)
                return NotFound();

            return Ok(skill);
        }

        // POST: api/v1/Resumes/{resumeId}/Skills
        [HttpPost]
        public async Task<ActionResult<Skill>> Post([FromRoute] int resumeId, [FromBody] Skill skill)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var resume = await this._db.Resumes.FirstOrDefaultAsync(value => value.Id == resumeId);

            if (resume == null)
                return NotFound();

            if (resume.UserId != userId)
                return Unauthorized();
            
            resume.Skills.Add(skill);
            await this._db.SaveChangesAsync();
            return CreatedAtRoute($"api/v1/resumes/{resumeId}/skills", skill);
        }

        // PUT: api/v1/Resumes/{resumeId}/Skills/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Skill>> Put([FromRoute] int resumeId, [FromRoute] int id, [FromBody] Skill value)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var resume = await this._db.Resumes.FirstOrDefaultAsync(v => v.Id == resumeId);

            if (resume == null)
                return NotFound();

            if (resume.UserId != userId)
                return Unauthorized();

            var skill = await this._db.Skills.FirstOrDefaultAsync(v => v.Id == id);

            if (skill == null)
                return NotFound();

            skill.Name = value.Name;
            await this._db.SaveChangesAsync();
            return Ok(skill);
        }

        // DELETE: api/v1/Resumes/{resumeId}/Skills/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int resumeId, [FromRoute] int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var resume = await this._db.Resumes.FirstOrDefaultAsync(v => v.Id == resumeId);

            if (resume == null)
                return NotFound();

            if (resume.UserId != userId)
                return Unauthorized();

            var skill = await this._db.Skills.FirstOrDefaultAsync(v => v.Id == id);

            if (skill == null)
                return NotFound();
            
            this._db.Skills.Remove(skill);
            await this._db.SaveChangesAsync();
            return Ok();
        }
    }
}

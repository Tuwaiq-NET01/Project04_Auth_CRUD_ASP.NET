using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPlatform.Data;
using BlogPlatform.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TagsController(AppDbContext context)
        {
            _context = context;
        }

        // get all tags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tag>>> GetTags(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return await _context.Tags.ToListAsync();
            }

            return await _context.Tags.Where(t => t.Name.Contains(search)).ToListAsync();
        }

        // get articles by tag
        [HttpGet("{id}")]
        public async Task<ActionResult<Tag>> GetTag(int id)
        {
            var tag = await _context.Tags.Include(t => t.ArticleTags)
                .ThenInclude(a => a.Article).FirstOrDefaultAsync(t => t.TagId == id);
            if (tag == null)
            {
                return NotFound();
            }

            return tag;
        }
        
        
        // get articles by tag
        
        // post tag
        // put tag
    }
}
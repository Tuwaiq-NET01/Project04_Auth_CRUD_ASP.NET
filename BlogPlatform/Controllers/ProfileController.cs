using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPlatform.Data;
using BlogPlatform.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProfileController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<object>> GetProfile()
        {
           return await _context.Users.Where(u => u.UserName == User.Identity.Name)
                    .Select(x => new
                    {
                        UserId = x.Id,
                        Username = x.UserName,
                        Bio = x.Bio,
                        DisplayName = x.DisplayName,
                        DateJoined = x.DateJoined,
                        ImageUrl = x.ImageUrl
                    })
                    .FirstAsync();
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<object>> EditProfile(Person updatedUser)
        {
            var user = await _context.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound();
            }

            user.ImageUrl = string.IsNullOrEmpty(updatedUser.ImageUrl) ? user.ImageUrl : updatedUser.ImageUrl;
            user.Bio = string.IsNullOrEmpty(updatedUser.Bio) ? user.Bio : updatedUser.Bio;
            user.DisplayName = string.IsNullOrEmpty(updatedUser.DisplayName) ? user.DisplayName : updatedUser.DisplayName;
            _context.Users.Update(user);
             await _context.SaveChangesAsync();
             return CreatedAtAction(nameof(GetProfile), user);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<object>> GetProfileByUsername(string username)
        {
            return await _context.Users.Include(a=>a.Articles)
                .ThenInclude(t=>t.ArticleTags)
                .ThenInclude(t=>t.Tag)
                .Where(u => u.UserName == username)
                .Select(x => new
                {
                    Username = x.UserName,
                    Bio = x.Bio,
                    DisplayName = x.DisplayName,
                    DateJoined = x.DateJoined,
                    ImageUrl = x.ImageUrl,
                    Articles = x.Articles
                })
                .FirstAsync();
        }
    }
}
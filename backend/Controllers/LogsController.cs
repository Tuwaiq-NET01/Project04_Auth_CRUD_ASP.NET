using backend.Data;
using backend.Models.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public LogsController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);

            if(user != null)
            {
                var userLogs = await _db.Logs.Where(log => log.UserId == Id).ToListAsync();
                return Ok(new { Status = "Success", Logs = userLogs });
            }

            return NotFound(new Response { Status = "Error", Message = "The user was not found!" });
        }
    }
}

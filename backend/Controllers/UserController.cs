using backend.Data;
using backend.Models;
using backend.Models.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _db.Users.ToListAsync();
            return Ok(new { users });
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if(user != null)
                return Ok(new { Status = "Success", User = user });

            return NotFound(new Response { Status = "Error", Message = "The user was not found!" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, UserDTO userDto)
        {
            if (id != userDto.Id)
            {
                return BadRequest(new Response { Status = "Error", Message = "The user ids do not match!" });
            }

            ApplicationUser model = await _userManager.FindByIdAsync(userDto.Id);

            if (model != null)
            {
                model.Email = userDto.Email != null ? userDto.Email : model.Email;
                model.Name = userDto.Name != null ? userDto.Name : model.Name;
                model.AccountType = userDto.AccountType != null ? userDto.AccountType : model.AccountType;
                model.CurrentQuota = userDto.CurrentQuota > 0 ? userDto.CurrentQuota : model.CurrentQuota;
                model.TotalQuota = userDto.TotalQuota > 0 ? userDto.TotalQuota : model.TotalQuota;
                if (userDto.CurrentPassword != null && userDto.NewPassword != null)
                    await _userManager.ChangePasswordAsync(model, userDto.CurrentPassword, userDto.NewPassword);
                await _userManager.UpdateAsync(model);
                return Ok(new { Status = "Updated", Message = "The user has been updated successfully!", UserId = id });
            }

            return NotFound(new Response { Status = "Error", Message = "The user was not found!" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user != null)
            {
                await _userManager.DeleteAsync(user);
                return Ok(new { Status = "Deleted", Message = "The user has been deleted successfully!", UserId = id });
            }
            return NotFound(new Response { Status = "Error", Message = "The user was not found!" });
        }
    }
}

using System;
using System.Linq;
using System.Threading.Tasks;
using BlogPlatform.Models;
using BlogPlatform.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<Person> _userManager;
        private readonly IAuthManager _authManager;

        public AccountController(UserManager<Person> userManager, IAuthManager authManager)
        {
            _userManager = userManager;
            _authManager = authManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                person.UserName = person.Email;
                person.DisplayName = person.Email;
                person.DateJoined = DateTime.Now;
                
                var result = await _userManager.CreateAsync(person, person.Password);
                if (!result.Succeeded)
                {
                    return BadRequest($"Something went wrong in {nameof(Register)}");
                }

                return Accepted();
            }
            catch (Exception e)
            {
                return Problem($"Something went wrong in {nameof(Register)}", statusCode: 500);
            }
        }
        
        
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] Person user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (!await _authManager.ValidateUser(user))
                {
                    return Unauthorized();
                }
                
                var token = await _authManager.CreateToken();
                
                Response.Cookies.Append("X-Access-Token", token,
                    new CookieOptions()
                    {
                        HttpOnly = true, SameSite = SameSiteMode.Strict, Expires = DateTime.Now.AddMinutes(60)
                    });
                Response.Cookies.Append("X-Username", user.Email,
                    new CookieOptions() {HttpOnly = true, SameSite = SameSiteMode.Strict,
                        Expires = DateTime.Now.AddMinutes(60)
                    });
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem($"Something Went Wrong in the {nameof(Login)}", statusCode: 500);
            }
        }

        [HttpGet]
        [Route("user")]
        public async Task<ActionResult> GetUser()
        {
            try
            {
                var jwt = Request.Cookies["X-Access-Token"];

                var token = _authManager.VerifyToken(jwt);

                var username = token.Claims.First().Value.ToUpper();
                var user = await _userManager.Users
                    .Include(a => a.Articles)
                    .FirstOrDefaultAsync(u => u.NormalizedUserName == username);
                return Ok(new
                {
                    isAuthenticated = true,
                    Username = user.UserName,
                    DisplayName = user.DisplayName,
                    Bio = user.Bio,
                    Articles = user.Articles.Select(x=> new {Title=x.Title, Body = x.Body}),
                    ImageUrl = user.ImageUrl
                });
            }
            catch (Exception ex)
            {
                return Ok(new {isAuthenticated = false, Username = ""});
            }

        }

    }
}
using System;
using System.Threading.Tasks;
using BlogPlatform.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<Person> _userManager;
        //private readonly SignInManager<Person> _signInManager;

        public AccountController(UserManager<Person> userManager)
        {
            _userManager = userManager;
           // _signInManager = signInManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                person.UserName = person.Email;
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
    }
}
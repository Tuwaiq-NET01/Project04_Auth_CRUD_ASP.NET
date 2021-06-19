using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Induction.Repositories;
using Induction.Dtos;
using Induction.Models;
using Induction.Helpers;
using Microsoft.AspNetCore.Http;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Induction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly IJwtService _jwtService;

        public AuthController(IUserRepository repository, IJwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
        }

        // POST api/values
        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var user = new UserModel
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            return Created("Success",_repository.Create(user));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(RegisterDto dto)
        {
            var user = await _repository.GetUserByEmail(dto.Email);

            if (user == null)
                return BadRequest(new { message = "Invalid Email Address!" });

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                return BadRequest(new { message = "Invalid Credentials!" });

            var jwt = _jwtService.Generate(user.Id);

            Response.Cookies.Append("jwt", jwt, new CookieOptions { HttpOnly= true}) ;

            return Ok("success");
        }

        [HttpGet("user")]
        public IActionResult User()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                var user_id = int.Parse(token.Issuer);

                var user = _repository.GetUserById(user_id);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }

        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return Ok(new { message= "success" });
        }
    }


}

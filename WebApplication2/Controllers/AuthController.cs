using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.DataTransferObjects;
using WebApplication2.Helpers;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly JwtService _jwtService;

        public AuthController(IUserRepository repository, JwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
        }
        
        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var student = new StudentModel()
            {
                Username = dto.Username,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword( dto.Password ),
                Gender = dto.Gender
            };

            return Created("success", _repository.Create(student));
        }
        
        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var student = _repository.GetByEmail(dto.Email);
            if (student == null)
            {
                Console.WriteLine("email");
                return BadRequest(new {Message = "Invalid Credentials"});
            }

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, student.Password))
            {
                Console.WriteLine("password");
                return BadRequest(new {Message = "Invalid Credentials"});
            }

            var jwt = _jwtService.Generate(student.Id);
            Response.Cookies.Append("Ask-A-jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });
            
            return Ok(new
            {
                message = "success"
            });
        }

        [HttpGet("user")]
        public IActionResult User()
        {
            try
            {
                var jwt = Request.Cookies["Ask-A-jwt"];
                var token = _jwtService.VerifyToken(jwt);
                int studentId = int.Parse(token.Issuer);

                Console.WriteLine("right");

                var student = _repository.GetById(studentId);
                return Ok(student);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("Ask-A-jwt");
            
            return Ok("success");
        }
    }
}
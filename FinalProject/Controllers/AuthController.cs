using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Dtos;
using FinalProject.Helpers;
using FinalProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly JwtService _jwtService;

        public AuthController(AppDbContext context, JwtService jwtService)
        {
            _db = context;
            _jwtService = jwtService;
        }
        
        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            _db.Users.Add(user);
            _db.SaveChanges();
            
            var userFromDb = _db.Users.FirstOrDefault(u => u.Email == dto.Email);
            
            return Created("success", userFromDb);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _db.Users.FirstOrDefault(u => u.Email == dto.Email);

            if (user == null)
            {
                return BadRequest(new {message = "Invalid Credentials"});
            }

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            {
                return BadRequest(new {message = "Invalid Credentials"});
            }

            var profile = _db.Profiles.FirstOrDefault(p => p.UserId == user.Id);
            
            var jwt = _jwtService.Generate(user.Id);
            
            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });

            if (profile == null)
            {
                var newProfile = new Profile()
                {
                    UserId = user.Id,
                    User = user,
                    JoinedDateTime = DateTime.Now
                };
                _db.Profiles.Add(newProfile);
                _db.SaveChanges();
                
                return Ok(new
                {
                    message = "success",
                    user
                });
            }
            else
            {
                var movies = _db.Movies.Where(m => m.ProfileId == profile.Id).ToList();
                var tvShow = _db.TvShows.Where(t => t.ProfileId == profile.Id).ToList();
                var favoriteMovies = _db.FavoriteMovies.Where(fav => fav.ProfileId == profile.Id).ToList();
                var favoriteTvShows = _db.FavoriteTvShows.Where(fav => fav.ProfileId == profile.Id).ToList();
            
                return Ok(new
                {
                    message = "success",
                    user
                });
            }
        }

        [HttpGet("user")]
        public IActionResult User()
        {
            
            try
            {
                // Console.WriteLine("asd");
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var user = _db.Users.FirstOrDefault(u => u.Id == userId);

                var profile = _db.Profiles.FirstOrDefault(p => p.UserId == userId);
                var movies = _db.Movies.Where(m => m.ProfileId == profile.Id).ToList();
                var tvShow = _db.TvShows.Where(t => t.ProfileId == profile.Id).ToList();
                var favoriteMovies = _db.FavoriteMovies.Where(fav => fav.ProfileId == profile.Id).ToList();
                var favoriteTvShows = _db.FavoriteTvShows.Where(fav => fav.ProfileId == profile.Id).ToList();
                
                return Ok(user);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }
    
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            
            return Ok(new
            {
                message = "success"
            });
        }
    }
}
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
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteMoviesController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly JwtService _jwtService;

        public FavoriteMoviesController(AppDbContext context, JwtService jwtService)
        {
            _db = context;
            _jwtService = jwtService;
        }
        
        // GET: api/FavoriteMovies
        [HttpGet]
        public IActionResult GetFavMovie()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                //var user = _db.Users.FirstOrDefault(u => u.Id == userId);

                var profile = _db.Profiles.FirstOrDefault(p => p.UserId == userId);

                var favMovie = _db.FavoriteMovies.Where(f => f.ProfileId == profile.Id).Include(f => f.Movie).ToList();
                
                // var movieLists = _db.Movies.
                    
                if (favMovie.Count < 1)
                {
                    return NotFound();
                }
                
                return Ok(favMovie[0].Profile.FavoriteMovie);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }

        // // GET: api/FavoriteMovies/5
        // [HttpGet("{id}", Name = "Get")]
        // public string Get(int id)
        // {
        //     return "value";
        // }
        
        // POST: api/FavoriteMovies
        [HttpPost("{id}")]
        public IActionResult Post(int id)
        {
            try
            {
                // Console.WriteLine("asd");
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                //var user = _db.Users.FirstOrDefault(u => u.Id == userId);

                var profile = _db.Profiles.FirstOrDefault(p => p.UserId == userId);
                if (_db.FavoriteMovies.FirstOrDefault(f => f.ProfileId == profile.Id && f.MovieId == id) != null)
                {
                    return BadRequest();
                }

                var favMovie = new FavoriteMovie
                {
                    ProfileId = profile.Id,
                    MovieId = id
                };
                _db.FavoriteMovies.Add(favMovie);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
            return Ok();
        }
        
        // // PUT: api/FavoriteMovies/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }
        
        // DELETE: api/FavoriteMovies/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                //var user = _db.Users.FirstOrDefault(u => u.Id == userId);

                var profile = _db.Profiles.FirstOrDefault(p => p.UserId == userId);
                
                var favMovie = _db.FavoriteMovies.FirstOrDefault(f => f.ProfileId == profile.Id && f.MovieId == id);
                
                if (favMovie == null)
                {
                    return NotFound();
                }
                
                _db.FavoriteMovies.Remove(favMovie);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
            return Ok();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Helpers;
using FinalProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        
        private readonly AppDbContext _db;
        private readonly JwtService _jwtService;

        public MoviesController(AppDbContext context, JwtService jwtService)
        {
            _db = context;
            _jwtService = jwtService;
        }
        
        // GET: api/Movies
        [HttpGet]
        public ActionResult GetMovies()
        {
            return Ok(new
            {
                List = _db.Movies.ToList()
            });
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var movie = _db.Movies.SingleOrDefault(a => a.Id == id);

            if (movie == null)
            {
                return BadRequest();
            }
            
            return Ok(movie);
            
        }
        
        // POST: api/Movies
        [HttpPost]
        public ActionResult Post( Movie movie )
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                //var user = _db.Users.FirstOrDefault(u => u.Id == userId);

                var profile = _db.Profiles.FirstOrDefault(p => p.UserId == userId);

                if (profile == null)
                {
                    return Unauthorized();
                }

                var movieInDatabase =  _db.Movies.Where(m => m.Title == movie.Title).ToList();
                if (movieInDatabase.Count > 0)
                {
                    return BadRequest(new
                    {
                        message = "Already Exist in Database"
                    });
                }

                movie.ProfileId = profile.Id;
                
                _db.Movies.Add(movie);
                _db.SaveChanges();
                
                return Ok(movie);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
            
        }
        
        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Movie movie)
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var profile = _db.Profiles.FirstOrDefault(p => p.UserId == userId);

                if (profile == null)
                {
                    return Unauthorized();
                }
                
                var editMovie = _db.Movies.SingleOrDefault(a => a.Id == id);
                
                if (editMovie == null)
                {
                    return BadRequest();
                }

                if (editMovie.ProfileId != profile.Id && profile.Id != 1)
                {
                    return Unauthorized();
                }
                
                editMovie.Title = movie.Title;
                editMovie.Date = movie.Date;
                editMovie.Summary = movie.Summary;
                editMovie.Rating = movie.Rating;
                editMovie.Poster = movie.Poster;
                
                _db.SaveChanges();
                
                return Ok(movie);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
           
        }
        
        // // DELETE: api/Movies/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}

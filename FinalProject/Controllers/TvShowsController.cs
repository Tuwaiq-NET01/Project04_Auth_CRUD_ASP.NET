using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Helpers;
using FinalProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TvShowsController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly JwtService _jwtService;

        public TvShowsController(AppDbContext context, JwtService jwtService)
        {
            _db = context;
            _jwtService = jwtService;
        }
        
        
        // GET: api/TvShows
        [HttpGet]
        public IActionResult GetTvShows()
        {
            return Ok(new
            {
                List = _db.TvShows.ToList()
            });
        }

        // GET: api/TvShows/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Console.WriteLine("GET");
            var tvShow = _db.TvShows.SingleOrDefault(a => a.Id == id);

            if (tvShow == null)
            {
                return BadRequest();
            }
            
            return Ok(tvShow);
        }
        
        // POST: api/TvShows
        [HttpPost]
        public ActionResult Post(TvShow tvShow)
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

                var tvShowInDatabase =  _db.TvShows.Where(t => t.Title == tvShow.Title).ToList();
                if (tvShowInDatabase.Count > 0)
                {
                    return BadRequest(new
                    {
                        message = "Already Exist in Database"
                    });
                }

                tvShow.ProfileId = profile.Id;
                
                _db.TvShows.Add(tvShow);
                _db.SaveChanges();
                
                return Ok(tvShow);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }
        
        // PUT: api/TvShows/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, TvShow tvShow)
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
                
                var editTvShow = _db.TvShows.SingleOrDefault(a => a.Id == id);
                
                if (editTvShow == null)
                {
                    return BadRequest();
                }

                if (editTvShow.ProfileId != profile.Id && profile.Id != 1)
                {
                    return Unauthorized();
                }
                
                editTvShow.Title = tvShow.Title;
                editTvShow.Date = tvShow.Date;
                editTvShow.Summary = tvShow.Summary;
                editTvShow.Rating = tvShow.Rating;
                editTvShow.Poster = tvShow.Poster;
                
                _db.SaveChanges();
                
                return Ok(tvShow);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }
        
        // // DELETE: api/TvShows/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}

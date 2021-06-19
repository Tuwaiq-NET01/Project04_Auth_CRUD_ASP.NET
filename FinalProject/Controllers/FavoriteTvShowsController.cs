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
    public class FavoriteTvShowsController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly JwtService _jwtService;

        public FavoriteTvShowsController(AppDbContext context, JwtService jwtService)
        {
            _db = context;
            _jwtService = jwtService;
        }
        
        
        // GET: api/FavoriteTvShow
        [HttpGet]
        public IActionResult GetFavTvShow()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                //var user = _db.Users.FirstOrDefault(u => u.Id == userId);

                var profile = _db.Profiles.FirstOrDefault(p => p.UserId == userId);

                var favTvShow = _db.FavoriteTvShows.Where(f => f.ProfileId == profile.Id).Include(f => f.TvShow).ToList();
                
                // var movieLists = _db.Movies.
                    
                if (favTvShow.Count < 1)
                {
                    return NotFound();
                }
                
                return Ok(favTvShow[0].Profile.FavoriteTvShow);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }
        
        // // GET: api/FavoriteTvShow/5
        // [HttpGet("{id}", Name = "Get")]
        // public string Get(int id)
        // {
        //     return "value";
        // }

        // POST: api/FavoriteTvShow
        [HttpPost("{id}")]
        public IActionResult Post(int id)
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var profile = _db.Profiles.FirstOrDefault(p => p.UserId == userId);
                
                if (_db.FavoriteTvShows.FirstOrDefault(f => f.ProfileId == profile.Id && f.TvShowId == id) != null)
                {
                    return BadRequest();
                }

                var favTvShow = new FavoriteTvShow
                {
                    ProfileId = profile.Id,
                    TvShowId = id
                };
                _db.FavoriteTvShows.Add(favTvShow);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
            return Ok();
        }

        // // PUT: api/FavoriteTvShow/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }

        // DELETE: api/FavoriteTvShow/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var profile = _db.Profiles.FirstOrDefault(p => p.UserId == userId);
                
                var favTvShow = _db.FavoriteTvShows.FirstOrDefault(f => f.ProfileId == profile.Id && f.TvShowId == id);
                
                if (favTvShow == null)
                {
                    return NotFound();
                }
                
                _db.FavoriteTvShows.Remove(favTvShow);
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

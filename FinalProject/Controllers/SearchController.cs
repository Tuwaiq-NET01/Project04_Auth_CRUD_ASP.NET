using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Helpers;
using FinalProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using Newtonsoft.Json.Linq;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly JwtService _jwtService;

        public SearchController(AppDbContext context, JwtService jwtService)
        {
            _db = context;
            _jwtService = jwtService;
        }
        
        // GET: api/Search/movie/title
        [HttpGet("movie/{title}")]
        public IActionResult GetMovie(string title)
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
                
                title = title.Replace(' ', '+');
            
                List<Movie> MovieList = new List<Movie>();
                JArray result = GetJSON(title, true);
                for (int i = 0; i < result.Count; i++)
                {
                    MovieList.Add(new Movie()
                    {
                        Id = i + 1,
                        Title = result[i]["title"].ToString(),
                        Date = JObject.Parse(result[i].ToString()).ContainsKey("release_date") ? result[i]["release_date"].ToString() : null,
                        Summary = result[i]["overview"].ToString(),
                        Rating = Convert.ToInt32(result[i]["vote_average"]),
                        Poster = "https://image.tmdb.org/t/p/w300" + result[i]["poster_path"].ToString()
                    });
                }
                
                return Ok(MovieList);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
            
        }
        // GET: api/Search/tvshow/title
        [HttpGet("tvshow/{title}")]
        public IActionResult GetTvShow(string title)
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
                
                title = title.Replace(' ', '+');
                
                List<TvShow> TvShowList = new List<TvShow>();
                JArray result = GetJSON(title, false);
                for (int i = 0; i < result.Count; i++)
                {
                    TvShowList.Add(new TvShow()
                    {
                        Id = i + 1,
                        Title = result[i]["name"].ToString(),
                        Date = JObject.Parse(result[i].ToString()).ContainsKey("first_air_date") ? result[i]["first_air_date"].ToString() : null,
                        Summary = result[i]["overview"].ToString(),
                        Rating = Convert.ToInt32(result[i]["vote_average"]),
                        Poster = "https://image.tmdb.org/t/p/w300" + result[i]["poster_path"].ToString()
                    });
                }

                return Ok(TvShowList);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }

        // // GET: api/Search/5
        // [HttpGet("{id}", Name = "Get")]
        // public string Get(int id)
        // {
        //     return "value";
        // }
        //
        // // POST: api/Search
        // [HttpPost]
        // public void Post([FromBody] string value)
        // {
        // }
        //
        // // PUT: api/Search/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }
        //
        // // DELETE: api/Search/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
        
        public JArray GetJSON(string title, bool what)
        {
            string html = string.Empty;
            
            string url = what? "https://api.themoviedb.org/3/search/movie?api_key=5b1b9f67b573e2104ae29d0da0c6104f&query=" + title : "https://api.themoviedb.org/3/search/tv?api_key=5b1b9f67b573e2104ae29d0da0c6104f&query=" + title;
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }
            
            var res = JObject.Parse(html);
            JArray result = JArray.Parse(res["results"].ToString());

            return result;
        }
    }
}

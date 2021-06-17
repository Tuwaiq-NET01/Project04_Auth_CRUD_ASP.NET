using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CelebrityVideoController : ControllerBase
    {
        private readonly ApplicationDbContext _Db;
        public CelebrityVideoController(ApplicationDbContext appDb)
        {
            this._Db = appDb;
        }

        // GET: api/<CelebritiesController>
        [HttpGet]
        public List<CelebrityVideo> Get()
        {
            var videos = _Db.CelebrityVideo.ToList();
            return videos;
        }

        // POST api/<CelebritiesController>
        [HttpPost]
        public void Post([FromBody] CelebrityVideo video)
        {
            _Db.CelebrityVideo.Add(video);
            _Db.SaveChanges();

        }
        [HttpDelete("{id}")]
        public ActionResult<String> Delete(int id)
        {
            CelebrityVideo c = _Db.CelebrityVideo.ToList().Find(ce => ce.id == id);

            if (c != null)
            {
                _Db.CelebrityVideo.Remove(c);
                _Db.SaveChanges();
                return id + " has been deleted ";
            }
            else
                throw new Exception("404");

        }
    }
}

using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject.Controllers
{

   
    [Route("api/[controller]")]
    [ApiController]
    public class CelebritiesController : ControllerBase
    {
        private readonly ApplicationDbContext _Db;
        public CelebritiesController(ApplicationDbContext appDb)
        {
            this._Db = appDb;
        }

        // GET: api/<CelebritiesController>
        [HttpGet]
        public List<Celebrity> Get()
        {
            var Celebrities = _Db.celebrities.ToList();
            return Celebrities;
        }

        // GET api/<CelebritiesController>/5
        [HttpGet("{id}")]
        public ActionResult<Celebrity>  Get(int id)
        {
            Celebrity c =_Db.celebrities.ToList().Find(ce =>ce.id==id);

            if(c != null)
            {
                return c;
            }
            return NotFound();
        }

        // POST api/<CelebritiesController>
        [HttpPost]
        public void Post([FromBody] Celebrity celebrity)
        {
            _Db.celebrities.Add(celebrity);
            _Db.SaveChanges();

        }

        // PUT api/<CelebritiesController>/5
        [HttpPut("{id}")]
        public ActionResult<String> Put(int id, [FromBody] Celebrity celebrity)
        {
            Celebrity c = _Db.celebrities.ToList().Find(ce => ce.id == id);

            if (c != null)
            {
                c.Name = celebrity.Name;
                c.Description = celebrity.Description;
                c.country = celebrity.country;
                c.Email = celebrity.Email;
                c.img = celebrity.img;
                c.IntroductionVideo = celebrity.IntroductionVideo;
                
                _Db.Update(c);
                _Db.SaveChanges();
                return id+" has been edited ";
            }
            else
                throw new Exception("404");

        }

        // DELETE api/<CelebritiesController>/5
        [HttpDelete("{id}")]
        public ActionResult<String> Delete(int id)
        {
            Celebrity c = _Db.celebrities.ToList().Find(ce => ce.id == id);

            if (c != null)
            {
                _Db.celebrities.Remove(c);
                _Db.SaveChanges();
                return id + " has been deleted ";
            }
            else
            throw new Exception("404");

        }
    }
}

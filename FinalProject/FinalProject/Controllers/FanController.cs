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
    public class FanController : ControllerBase
    {
        private readonly ApplicationDbContext _Db;
        public FanController(ApplicationDbContext appDb)
        {
            this._Db = appDb;
        }

        // GET: api/<CelebritiesController>
        [HttpGet]
        public List<Fan> Get()
        {
            var Fan = _Db.fans.ToList();
            return Fan;
        }

        [HttpGet("{id}")]
        public ActionResult<Fan> Get(int id)
        {
            Fan fan = _Db.fans.ToList().Find(f => f.id == id);

            if (fan != null)
            {
                return fan;
            }
            return NotFound();
        }

        [HttpPost]
        public void Post([FromBody] Fan fan)
        {
            _Db.fans.Add(fan);
            _Db.SaveChanges();

        }

        [HttpPut("{id}")]
        public ActionResult<String> Put(int id, [FromBody] Fan fan)
        {
            Fan fan1 = _Db.fans.ToList().Find(f => f.id == id);

            if (fan1 != null)
            {
                fan1.Name = fan.Name;
                fan1.country = fan.country;
                fan1.Email = fan.Email;
                fan1.img = fan.img;
               
                _Db.Update(fan1);
                _Db.SaveChanges();
                return id + " has been edited ";
            }
            else
                throw new Exception("404");

        }

        // DELETE api/<CelebritiesController>/5
        [HttpDelete("{id}")]
        public ActionResult<String> Delete(int id)
        {
            Fan fan1 = _Db.fans.ToList().Find(f => f.id == id);

            if (fan1 != null)
            {
               
                _Db.Remove(fan1);
                _Db.SaveChanges();
                return id + " has been edited ";
            }
            else
                throw new Exception("404");

        }



    }
}

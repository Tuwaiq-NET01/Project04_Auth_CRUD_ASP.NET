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
    public class FanReqeustCelebrityController : ControllerBase
    {
        private readonly ApplicationDbContext _Db;
        public FanReqeustCelebrityController(ApplicationDbContext appDb)
        {
            this._Db = appDb;
        }

        // GET: api/<CelebritiesController>
        [HttpGet]
        public List<FanReqeustCelebrity> Get()
        {
            var FanReqeustCelebrity = _Db.fanReqeustCelebrities.ToList();

            return FanReqeustCelebrity;
        }

        [HttpPost]
        public void Post([FromBody] FanReqeustCelebrity FanReqeustCelebrity)
        {
            _Db.fanReqeustCelebrities.Add(FanReqeustCelebrity);
            _Db.SaveChanges();

        }

        [HttpDelete("{id}")]
        public ActionResult<String> Delete(int id)
        {
            FanReqeustCelebrity Reqeust = _Db.fanReqeustCelebrities.ToList().Find(r => r.id == id);

            if (Reqeust != null)
            {

                _Db.Remove(Reqeust);
                _Db.SaveChanges();
                return id + " has been deleted ";
            }
            else
                throw new Exception("404");

        }
    }
}

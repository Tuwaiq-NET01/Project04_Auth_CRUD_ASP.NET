using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Models;
using Web.Data;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;

namespace Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/API/[controller]")]
    public class CNAsController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly VulnDbContext _db;
        public CNAsController(ILogger<WeatherForecastController> logger, VulnDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpPost]
        [AllowAnonymous]
        [Consumes(MediaTypeNames.Application.Json)]
        public ActionResult CreateCNA([Bind] CNA cna)
        {
            if (cna.Name == null || cna.Email == null) return BadRequest("CNA name or email was not provided");
            if (_db.CNAs.Where(c => c.Name.ToLower() == cna.Name.ToLower() && c.Email == cna.Email.ToLower()).Any()) return Conflict("CNA already exists");
            _db.CNAs.Add(cna);
            _db.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [AllowAnonymous]
        public IAsyncEnumerable<CNA> ReadCNAs([FromQuery] CNAQuery q)
        {
            IQueryable<CNA> dbQ = _db.CNAs;
            if (q.Id != null) dbQ = dbQ.Where(c => c.Id == q.Id);
            if (q.Name != null) dbQ = dbQ.Where(c => c.Name.ToLower().Contains(q.Name.ToLower()));
            if (q.Email != null) dbQ = dbQ.Where(c => c.Email.Contains(q.Email.ToLower()));
            if (q.Offset != null && q.Offset > 0) dbQ = dbQ.Skip((int)q.Offset);
            if (q.Limit != null && q.Limit > 0) dbQ = dbQ.Take(q.Limit ?? 10);
            return dbQ.AsAsyncEnumerable();
        }

        [HttpPatch]
        [HttpPut]
        [AllowAnonymous]
        [Consumes(MediaTypeNames.Application.Json)]
        public ActionResult UpdateCNA([FromQuery] string id, [Bind] CNA cna)
        {

            CNA dbCna = _db.CNAs.Where(item => item.Id == cna.Id).FirstOrDefault();
            if (dbCna == null) return NotFound();
            else if (_db.CNAs.Where(c => c.Name.ToLower() == cna.Name.ToLower() && c.Email == cna.Email.ToLower()).Any()) return Conflict("A CNA with the same information already exist");

            if (cna.Name == null && cna.Email == null) return BadRequest("Neither a CNA name nor email were provided");
            if (cna.Name != null) dbCna.Name = cna.Name;
            if (cna.Email != null) dbCna.Email = cna.Email;
            _db.SaveChanges();

            // _db.CVEs.Remove(_db.CVEs.Where(item => item.Year == year && item.Id == id).FirstOrDefault());
            // // TODO: Handle related records in junction tables (i.e. related CWEs, References and CPEs)
            // _db.CVEs.Add(cve);
            // _db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [AllowAnonymous]
        public ActionResult DeleteCNA([FromQuery] short id)
        {
            var cna = _db.CNAs.Where(c => c.Id == id).FirstOrDefault();
            if (cna == null) return NotFound();
            _db.CNAs.Remove(cna);
            _db.SaveChanges();
            return Ok();
        }

        [HttpGet("Count")]
        [AllowAnonymous]
        public Task<int> CountCNAs() => _db.CNAs.CountAsync();


        public class CNAQuery
        {
            [FromQuery(Name = "id")] public int? Id { get; set; }
            [FromQuery(Name = "name")] public string Name { get; set; }
            [FromQuery(Name = "email")] public string Email { get; set; }
            [FromQuery(Name = "offset")] public int? Offset { get; set; }
            [FromQuery(Name = "limit")] public int? Limit { get; set; }

        }

    }

}

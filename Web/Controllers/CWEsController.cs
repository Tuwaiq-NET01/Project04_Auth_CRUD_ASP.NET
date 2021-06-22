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
    public class CWEsController : ControllerBase
    {
        private readonly ILogger<CWEsController> _logger;
        private readonly VulnDbContext _db;
        public CWEsController(ILogger<CWEsController> logger, VulnDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet("Count")]
        [AllowAnonymous]
        public Task<int> CountCWEs() => _db.CWEs.CountAsync();


        [HttpGet]
        [AllowAnonymous]
        public IAsyncEnumerable<CWE> ReadCWEs([FromQuery] CWEQuery q)
        {
            IQueryable<CWE> dbQ = _db.CWEs;
            if (q.Id != null) dbQ = dbQ.Where(c => c.Id == q.Id);
            if (q.Name != null) dbQ = dbQ.Where(c => c.Name == q.Name);
            if (q.Offset > 0) dbQ = dbQ.Skip((int)q.Offset);
            return dbQ.Take(q.Limit ?? 10).AsAsyncEnumerable();
        }

        public class CWEQuery
        {
            [FromQuery(Name = "id")] public short? Id { get; set; }
            [FromQuery(Name = "name")] public string Name { get; set; }
            [FromQuery(Name = "offset")] public int Offset { get; set; }
            [FromQuery(Name = "limit")] public int? Limit { get; set; }

        }
    }

}

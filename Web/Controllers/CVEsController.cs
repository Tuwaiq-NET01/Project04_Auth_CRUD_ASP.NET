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
    public class CVEsController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly VulnDbContext _db;
        public CVEsController(ILogger<WeatherForecastController> logger, VulnDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/API/[controller]/Average")]
        public double AverageCVEs([FromQuery] CVEQuery q)
        {
            IQueryable<CVE> dbQ = _db.CVEs;
            dbQ = q.From != null ? dbQ.Where(cve => cve.CreatedAt >= q.From) : dbQ;
            dbQ = q.To != null ? dbQ.Where(cve => cve.CreatedAt <= q.To) : dbQ;
            if (q.CNA != null)
            {
                var dbCna = _db.CNAs.Where(record => record.Name.ToLower() == q.CNA.ToLower()).FirstOrDefault();
                if (dbCna == null) return 0;
                dbQ = dbQ.Where(cve => cve.CNA == dbCna.Id);
            }
            return (q.UseCVSSv2 ? dbQ.Average(cve => cve.CVSSv2Impact) : dbQ.Average(cve => cve.CVSSv3Impact)) / 10 ?? 0;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/API/[controller]/Count")]
        public int CountCVEs([FromQuery] CVEQuery q)
        {
            IQueryable<CVE> dbQ = _db.CVEs;
            dbQ = q.From != null ? dbQ.Where(cve => cve.CreatedAt >= q.From) : dbQ;
            dbQ = q.To != null ? dbQ.Where(cve => cve.CreatedAt <= q.To) : dbQ;
            dbQ = q.CVSSv2Min != null && q.CVSSv2Min <= 10 ? dbQ.Where(cve => cve.CVSSv2Impact >= q.CVSSv2Min * 10) : dbQ;
            dbQ = q.CVSSv2Max != null && q.CVSSv2Max > 0 ? dbQ.Where(cve => cve.CVSSv2Impact <= Math.Min((double)q.CVSSv2Max, 10) * 10) : dbQ;
            dbQ = q.CVSSv3Min != null && q.CVSSv3Min <= 10 ? dbQ.Where(cve => cve.CVSSv3Impact >= q.CVSSv3Min * 10) : dbQ;
            dbQ = q.CVSSv3Max != null && q.CVSSv3Max > 0 ? dbQ.Where(cve => cve.CVSSv3Impact <= Math.Min((double)q.CVSSv3Max, 10) * 10) : dbQ;
            if (q.CNA != null)
            {
                var dbCna = _db.CNAs.Where(record => record.Name.ToLower() == q.CNA.ToLower()).FirstOrDefault();
                if (dbCna == null) return 0;
                dbQ = dbQ.Where(cve => cve.CNA == dbCna.Id);
            }
            return dbQ.Count();
        }

        [HttpPost]
        [AllowAnonymous]
        [Consumes(MediaTypeNames.Application.Json)]
        public ActionResult CreateCVE([Bind] CVE cve)
        {
            if (_db.CVEs.Where(item => item.Year == cve.Year && item.Id == cve.Id).Any()) return Conflict($"CVE-{cve.Year}-{cve.Id} already exists");
            int id = 0;
            if (cve.Year < 1970 || cve.Year > DateTime.Now.Year + 1) BadRequest("Invalid year value");
            else if (!Int32.TryParse(cve.Id, out id) || id <= 0) BadRequest("Invalid ID value");
            else if (!_db.CNAs.Where(cna => cna.Id == cve.CNA).Any()) return NotFound("The provided CNA does not exist");

            if (cve.CVSSv2Impact == 0 || cve.CVSSv2Impact > 100) cve.CVSSv2Impact = Byte.MaxValue;
            if (cve.CVSSv3Impact == 0 || cve.CVSSv3Impact > 100) cve.CVSSv3Impact = Byte.MaxValue;
            if (cve.CreatedAt == null) cve.CreatedAt = DateTime.UtcNow;
            if (cve.UpdatedAt == null) cve.UpdatedAt = DateTime.UtcNow;

            _db.CVEs.Add(cve);
            _db.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [AllowAnonymous]
        public IAsyncEnumerable<CVE> ReadCVEs([FromQuery] CVEQuery q)
        {
            IQueryable<CVE> dbQ = _db.CVEs.Include(cve => cve.CNANavigation);

            // Filters
            if (q.Id != null) dbQ = dbQ.Where(c => c.Id.Contains(q.Id));
            if (q.Year != null) dbQ = dbQ.Where(c => c.Year == q.Year);
            if (q.From != null) dbQ = dbQ.Where(c => c.CreatedAt >= q.From);
            if (q.To != null) dbQ = dbQ.Where(c => c.CreatedAt <= q.To);
            if (q.CVSSv2Min != null && q.CVSSv2Min <= 10) dbQ = dbQ.Where(c => c.CVSSv2Impact >= q.CVSSv2Min * 10);
            if (q.CVSSv2Max != null && q.CVSSv2Max > 0) dbQ = dbQ.Where(c => c.CVSSv2Impact <= q.CVSSv2Max * 10);
            if (q.CVSSv3Min != null && q.CVSSv3Min <= 10) dbQ = dbQ.Where(c => c.CVSSv3Impact >= q.CVSSv3Min * 10);
            if (q.CVSSv3Max != null && q.CVSSv3Max > 0) dbQ = dbQ.Where(c => c.CVSSv3Impact <= q.CVSSv3Max * 10);
            if (q.CNA != null)
            {
                var dbCna = _db.CNAs.Where(record => record.Name.ToLower() == q.CNA.ToLower()).FirstOrDefault();
                if (dbCna == null) return null;
                dbQ = dbQ.Where(cve => cve.CNA == dbCna.Id);
            }

            // Order By
            switch (q.Sort)
            {
                case CVEOrderBy.Id:
                    dbQ = dbQ.OrderBy(c => c.Id); break;
                case CVEOrderBy.Year:
                    dbQ = dbQ.OrderBy(c => c.Year); break;
                case CVEOrderBy.CreatedAt:
                    dbQ = dbQ.OrderBy(c => c.CreatedAt); break;
                case CVEOrderBy.UpdatedAt:
                    dbQ = dbQ.OrderBy(c => c.UpdatedAt); break;
                case CVEOrderBy.CVSSv2:
                    dbQ = dbQ.OrderBy(c => c.CVSSv2Impact); break;
                case CVEOrderBy.CVSSv3:
                    dbQ = dbQ.OrderBy(c => c.CVSSv3Impact); break;
                case CVEOrderBy.DescendingId:
                    dbQ = dbQ.OrderByDescending(c => c.Id); break;
                case CVEOrderBy.DescendingYear:
                    dbQ = dbQ.OrderByDescending(c => c.Year); break;
                case CVEOrderBy.DescendingUpdatedAt:
                    dbQ = dbQ.OrderByDescending(c => c.UpdatedAt); break;
                case CVEOrderBy.DescendingCVSSv2:
                    dbQ = dbQ.OrderByDescending(c => c.CVSSv2Impact); break;
                case CVEOrderBy.DescendingCVSSv3:
                    dbQ = dbQ.OrderByDescending(c => c.CVSSv3Impact); break;
                case CVEOrderBy.DescendingCreatedAt:
                case CVEOrderBy.None:
                case null:
                default:
                    dbQ = dbQ.OrderByDescending(c => c.CreatedAt); break;
            }
            if (q.Offset != null && q.Offset > 0) dbQ = dbQ.Skip((int)q.Offset);
            return dbQ.Take(q.Limit ?? 10).AsAsyncEnumerable();
        }

        [HttpPatch]
        [HttpPut]
        [AllowAnonymous]
        [Consumes(MediaTypeNames.Application.Json)]
        public ActionResult UpdateCVE([FromQuery(Name = "cve-id")] string id, [FromQuery(Name = "cve-year")] int year, [Bind] CVE cve)
        {
            CVE dbCve = _db.CVEs.Where(item => item.Year == year && item.Id == id).FirstOrDefault();
            if (dbCve == null) return NotFound();

            // TODO: Handle related records in junction tables (i.e. related CWEs, References and CPEs)
            if (cve.CVSSv2Impact == 0 || cve.CVSSv2Impact > 100) cve.CVSSv2Impact = Byte.MaxValue;
            if (cve.CVSSv3Impact == 0 || cve.CVSSv3Impact > 100) cve.CVSSv3Impact = Byte.MaxValue;

            if (_db.CNAs.Where(cna => cna.Id == cve.CNA).Any()) dbCve.CNA = cve.CNA;
            if (cve.Description != null) dbCve.Description = cve.Description;
            if (cve.CVSSv2Impact > 0 || cve.CVSSv2Impact <= 100) dbCve.CVSSv2Impact = cve.CVSSv2Impact;
            if (cve.CVSSv3Impact > 0 || cve.CVSSv3Impact <= 100) dbCve.CVSSv3Impact = cve.CVSSv3Impact;
            cve.UpdatedAt = DateTime.UtcNow;
            _db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [AllowAnonymous]
        public ActionResult DeleteCVE([FromQuery(Name = "cve-id")] string id, [FromQuery(Name = "cve-year")] int year)
        {
            if (!_db.CVEs.Where(item => item.Year == year && item.Id == id).Any()) return NotFound();
            // TODO: Handle related records in junction tables (i.e. related CWEs, References and CPEs)
            _db.CVEs.Remove(_db.CVEs.Where(item => item.Year == year && item.Id == id).FirstOrDefault());
            _db.SaveChanges();
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("Aggr")]
        public IEnumerable<CVECount> CountCVEsPerMonth()
        {
            return _db.CVEs
                .GroupBy(cve => new { ((DateTime)cve.CreatedAt).Year, ((DateTime)cve.CreatedAt).Month })
                .Select(cve => new CVECount(cve.Key.Year, cve.Key.Month, cve.Count()))
                .AsEnumerable().OrderBy(cveCount => cveCount.Year)
                .ThenBy(cveCount => cveCount.Month);
        }

        public class CVEQuery
        {
            [FromQuery(Name = "cve-id")] public string Id { get; set; }
            [FromQuery(Name = "cve-year")] public int? Year { get; set; }
            [FromQuery(Name = "from-date")] public DateTime? From { get; set; }
            [FromQuery(Name = "to-date")] public DateTime? To { get; set; }
            [FromQuery(Name = "from-cvssv2")] public double? CVSSv2Min { get; set; }
            [FromQuery(Name = "to-cvssv2")] public double? CVSSv2Max { get; set; }
            [FromQuery(Name = "from-cvssv3")] public double? CVSSv3Min { get; set; }
            [FromQuery(Name = "to-cvssv3")] public double? CVSSv3Max { get; set; }
            [FromQuery(Name = "cna")] public string CNA { get; set; }
            [FromQuery(Name = "cvss2")] public bool UseCVSSv2 { get; set; }
            [FromQuery(Name = "cvss3")] public string UseCVSSv3 { get; set; }
            [FromQuery(Name = "offset")] public int? Offset { get; set; }
            [FromQuery(Name = "limit")] public int? Limit { get; set; }
            [FromQuery(Name = "sort")] public CVEOrderBy? Sort { get; set; }

        }

        public enum CVEOrderBy
        {
            None = 0,
            Id,
            Year,
            CreatedAt,
            UpdatedAt,
            CVSSv2,
            CVSSv3,
            DescendingId,
            DescendingYear,
            DescendingCreatedAt,
            DescendingUpdatedAt,
            DescendingCVSSv2,
            DescendingCVSSv3,
        }

        public record CVECount(int Year, int Month, int Count);

    }
}


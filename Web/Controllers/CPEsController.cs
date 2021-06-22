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
using System.Text.RegularExpressions;

namespace Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/API/[controller]")]
    public class CPEsController : ControllerBase
    {
        private readonly ILogger<CPEsController> _logger;
        private readonly VulnDbContext _db;
        private static readonly Regex _cpeVectorRegex = new Regex(@"^cpe:2\.3(:([^:]*(\\:)*)+){11}$", RegexOptions.Compiled);
        public CPEsController(ILogger<CPEsController> logger, VulnDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpPost]
        [AllowAnonymous]
        [Consumes(MediaTypeNames.Application.Json)]
        public ActionResult CreateCPE([Bind] CPE cpe)
        {
            if (!CPEsController._cpeVectorRegex.IsMatch(cpe.vector)) return BadRequest("Invalid CPE vector structure");

            var cpeVector = cpe.vector.Replace("\\\\", "\\").ToLower();
            byte[] cpeMd5;

            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(cpeVector);
                cpeMd5 = md5.ComputeHash(inputBytes);
            }
            if (_db.CPEs.Where(c => c.id.Equals(cpeMd5)).Any()) return Conflict("CPE already exist");

            var cpeItems = cpeVector.Replace("\\:", "_").Split(':');
            CPE newCpe = new()
            {
                id = cpeMd5,
                part = (byte)cpeItems[2][0],
                vendor = cpeItems[3],
                product = cpeItems[4],
                version = cpeItems[5],
                update = cpeItems[6],
                edition = cpeItems[7],
                language = cpeItems[8],
                sw_edition = cpeItems[9],
                target_sw = cpeItems[10],
                target_hw = cpeItems[11],
                vector = cpeVector
            };

            _db.CPEs.Add(newCpe);
            _db.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [AllowAnonymous]
        public IAsyncEnumerable<CPE> ReadCPEs([FromQuery] CPEQuery q)
        {
            IQueryable<CPE> dbQ = _db.CPEs;
            if (q.Part != null) dbQ = dbQ.Where(c => c.part == q.Part);
            if (q.Vendor != null) dbQ = dbQ.Where(c => c.vendor == q.Vector.ToLower());
            if (q.Product != null) dbQ = dbQ.Where(c => c.product.Contains(q.Product.ToLower()));
            if (q.Version != null) dbQ = dbQ.Where(c => c.version.Contains(q.Version.ToLower()));
            if (q.Update != null) dbQ = dbQ.Where(c => c.update.Contains(q.Update.ToLower()));
            if (q.Edition != null) dbQ = dbQ.Where(c => c.edition.Contains(q.Edition.ToLower()));
            if (q.Language != null) dbQ = dbQ.Where(c => c.language.Contains(q.Language.ToLower()));

            if (q.SwEdition != null) dbQ = dbQ.Where(c => c.sw_edition.Contains(q.SwEdition.ToLower()));
            if (q.TargetSw != null) dbQ = dbQ.Where(c => c.target_sw.Contains(q.TargetSw.ToLower()));
            if (q.TargetHw != null) dbQ = dbQ.Where(c => c.target_hw.Contains(q.TargetHw.ToLower()));

            if (q.Vector != null) dbQ = dbQ.Where(c => c.vector.Contains(q.Vector.ToLower()));

            if (q.Offset != null && q.Offset > 0) dbQ = dbQ.Skip((int)q.Offset);
            if (q.Limit != null && q.Limit > 0) dbQ = dbQ.Take(q.Limit ?? 10);
            return dbQ.AsAsyncEnumerable();
        }

        [HttpPut]
        [AllowAnonymous]
        [Consumes(MediaTypeNames.Application.Json)]
        public ActionResult UpdateCNA([FromBody] CPEQuery q)
        {
            if (q.Vector == null || q.NewVector == null) return BadRequest("Missing old and/or new CPE vector");
            CPE dbCpe = _db.CPEs.Where(c => c.vector == q.Vector).FirstOrDefault();
            if (dbCpe == null) return NotFound("Old CPE vector does not exist");
            var cpeVector = q.NewVector.Replace("\\\\", "\\").ToLower();
            byte[] cpeMd5;

            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
                cpeMd5 = md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(cpeVector));
            if (_db.CPEs.Where(c => c.id.Equals(cpeMd5)).Any()) return Conflict("CPE already exist");

            var cpeItems = cpeVector.Replace("\\:", "_").Split(':');
            dbCpe.id = cpeMd5;
            dbCpe.part = (byte)cpeItems[2][0];
            dbCpe.vendor = cpeItems[3];
            dbCpe.product = cpeItems[4];
            dbCpe.version = cpeItems[5];
            dbCpe.update = cpeItems[6];
            dbCpe.edition = cpeItems[7];
            dbCpe.language = cpeItems[8];
            dbCpe.sw_edition = cpeItems[9];
            dbCpe.target_sw = cpeItems[10];
            dbCpe.target_hw = cpeItems[11];
            dbCpe.vector = cpeVector;

            // TODO: Handle related records in junction tables (i.e. related CWEs, References and CPEs)
            _db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [AllowAnonymous]
        public ActionResult DeleteCNA([FromQuery] CPEQuery q)
        {
            var cpe = _db.CPEs.Where(c => c.vector == q.Vector).FirstOrDefault();
            if (cpe == null) return NotFound();
            _db.CPEs.Remove(cpe);
            _db.SaveChanges();
            return Ok();
        }

        [HttpGet("Count")]
        [AllowAnonymous]
        public Task<int> CountCPEs() => _db.CPEs.CountAsync();

        public class CPEQuery
        {
            [FromQuery(Name = "id")] public byte[] Id { get; set; }
            [FromQuery(Name = "part")] public byte? Part { get; set; }
            [FromQuery(Name = "vendor")] public string Vendor { get; set; }
            [FromQuery(Name = "product")] public string Product { get; set; }
            [FromQuery(Name = "version")] public string Version { get; set; }
            [FromQuery(Name = "update")] public string Update { get; set; }
            [FromQuery(Name = "edition")] public string Edition { get; set; }
            [FromQuery(Name = "language")] public string Language { get; set; }
            [FromQuery(Name = "sw_edition")] public string SwEdition { get; set; }
            [FromQuery(Name = "target_sw")] public string TargetSw { get; set; }
            [FromQuery(Name = "target_hw")] public string TargetHw { get; set; }

            [FromQuery(Name = "vector")] public string Vector { get; set; }
            [FromQuery(Name = "new-vector")] public string NewVector { get; set; }

            [FromQuery(Name = "offset")] public int? Offset { get; set; }
            [FromQuery(Name = "limit")] public int? Limit { get; set; }

        }

    }

}

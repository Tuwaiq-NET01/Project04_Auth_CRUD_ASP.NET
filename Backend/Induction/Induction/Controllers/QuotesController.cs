using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Induction.Models;
using Induction.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Induction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly IQuotesRepository _quotesRepository;

        public QuotesController(IQuotesRepository quotesRepository)
        {
            this._quotesRepository = quotesRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<QouteModel>> GetQuotes()
        {
            return await _quotesRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QouteModel>> GetQuotes(int id)
        {
            return await _quotesRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<QouteModel>> PostQuotes([FromBody] QouteModel qoute)
        {
            var NewQuote = await _quotesRepository.Create(qoute);
            return CreatedAtAction(nameof(GetQuotes), new {id = NewQuote.Id}, NewQuote);
        }

        [HttpPut]
        public async Task<ActionResult> PutBooks(int id, [FromBody]  QouteModel qoute)
        {
            if (id != qoute.Id)
            {
                return BadRequest();
            }

            await _quotesRepository.Update(qoute);
            return NoContent();
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteQuotes(int id)
        {
            var QuotesToDelete = await _quotesRepository.Get(id);
            if (QuotesToDelete == null)
            {
                return NotFound(); 
            }
            await _quotesRepository.Delete(id);
            return NoContent(); 
        }
    }
}
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
    public class FactsController : ControllerBase
    {
        private readonly IFactRepository _factRepository;

        public FactsController(IFactRepository factRepository)
        {
            this._factRepository = factRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<FactModel>> GetFacts()
        {
            return await _factRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FactModel>> GetFacts(int id)
        {
            return await _factRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<FactModel>> PostFacts([FromBody] FactModel fact)
        {
            var NewFact = await _factRepository.Create(fact);
            return CreatedAtAction(nameof(GetFacts), new {id = NewFact.Id}, NewFact);
        }

        [HttpPut]
        public async Task<ActionResult> PutBooks(int id, [FromBody]  FactModel fact)
        {
            if (id != fact.Id)
            {
                return BadRequest();
            }

            await _factRepository.Update(fact);
            return NoContent();
        }
        
        [HttpDelete]
        public async Task<ActionResult> DeleteFacts(int id)
        {
            var factToDelte = await _factRepository.Get(id);
            if (factToDelte == null)
            {
                return NotFound(); 
            }
            await _factRepository.Delete(id);
            return NoContent(); 
        }
    }
}
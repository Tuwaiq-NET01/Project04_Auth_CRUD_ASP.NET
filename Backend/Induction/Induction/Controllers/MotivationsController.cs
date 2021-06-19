using System;
using System.Collections;
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
    public class MotivationsController : ControllerBase
    {
        private readonly IMotavationRepository _motavationRepository;

        public MotivationsController(IMotavationRepository motavationRepository)
        {
            this._motavationRepository = motavationRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<MotivationModel>> GetMotivations()
        {
            return await _motavationRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MotivationModel>> GetMotivations(int id)
        {
            return await _motavationRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<MotivationModel>> PostMotivations([FromBody] MotivationModel motivation)
        {
            var NewMotivation = await _motavationRepository.Create(motivation);
            return CreatedAtAction(nameof(GetMotivations), new {id = NewMotivation.id}, NewMotivation);
        }
        
        [HttpPut]
        public async Task<ActionResult> PutBooks(int id, [FromBody]  MotivationModel motivation)
        {
            if (id != motivation.id)
            {
                return BadRequest();
            }

            await _motavationRepository.Update(motivation);
            return NoContent();
        }


        [HttpDelete]
        public async Task<ActionResult> DeleteMotivations(int id)
        {
            var MotivationToDelete = await _motavationRepository.Get(id);
            if (MotivationToDelete == null)
            {
                return NotFound(); 
            }
            await _motavationRepository.Delete(id);
            return NoContent(); 
        }
      
    }
}
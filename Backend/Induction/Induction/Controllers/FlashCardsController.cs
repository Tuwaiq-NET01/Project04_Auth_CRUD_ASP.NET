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
    public class FlashCardsController : ControllerBase
    {
        private readonly IFlashCardRepository _flashCardRepository;

        public FlashCardsController(IFlashCardRepository flashCardRepository)
        {
            this._flashCardRepository = flashCardRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<FlashCardModel>> GetFlashCards()
        {
            return await _flashCardRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FlashCardModel>> GetFlashCards(int id)
        {
            return await _flashCardRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<FlashCardModel>> PostFlashCards([FromBody] FlashCardModel FlashCard)
        {
            var NewFlashCard = await _flashCardRepository.Create(FlashCard);
            return CreatedAtAction(nameof(GetFlashCards), new {id = NewFlashCard.id}, NewFlashCard);
        }

        [HttpPut]
        public async Task<ActionResult> PutBooks(int id, [FromBody]  FlashCardModel FlashCard)
        {
            if (id != FlashCard.id)
            {
                return BadRequest();
            }

            await _flashCardRepository.Update(FlashCard);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteFlashCards(int id)
        {
            var FlashCardToDelete = await _flashCardRepository.Get(id);
            if (FlashCardToDelete == null)
            {
                return NotFound(); 
            }
            await _flashCardRepository.Delete(id);
            return NoContent(); 
        }
    }
}
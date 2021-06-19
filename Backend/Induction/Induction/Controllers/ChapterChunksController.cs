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
    public class ChapterChunksController : ControllerBase
    {
        private readonly IChapterChunkRepository _chapterChunkRepository;

        public ChapterChunksController(IChapterChunkRepository chapterChunkRepository)
        {
            this._chapterChunkRepository = chapterChunkRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ChapterChunkModel>> GetChapterChunks()
        {
            return await _chapterChunkRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChapterChunkModel>> GetChapterChunks(int id)
        {
            return await _chapterChunkRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<ChapterChunkModel>> PostChapterChunks([FromBody] ChapterChunkModel chapterchunk)
        {
            var NewChapterchunk = await _chapterChunkRepository.Create(chapterchunk);
            return CreatedAtAction(nameof(GetChapterChunks), new {id = NewChapterchunk.Id}, NewChapterchunk);
        }
        
        [HttpPut]
        public async Task<ActionResult> PutBooks(int id, [FromBody] ChapterChunkModel chapterchunk)
        {
            if (id != chapterchunk.Id)
            {
                return BadRequest(); 
            }

            await _chapterChunkRepository.Update(chapterchunk);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteChapterChunks(int id)
        {
            var chapterChunkTodeltee = await _chapterChunkRepository.Get(id);
            if (chapterChunkTodeltee == null)
            {
                return NotFound(); 
            }
            await _chapterChunkRepository.Delete(id);
            return NoContent(); 
        }
    }
}
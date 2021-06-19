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
    public class ChaptersController : ControllerBase
    {
        private readonly IChapterRepository _chapterRepository;

        public ChaptersController(IChapterRepository chapterRepository)
        {
            this._chapterRepository = chapterRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ChapterModel>> GetChapters()
        {
            return await _chapterRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChapterModel>> GetChapters(int id)
        {
            return await _chapterRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<ChapterModel>> PostChapters([FromBody] ChapterModel chapter)
        {
            var NewChapter = await _chapterRepository.Create(chapter);
            return CreatedAtAction(nameof(GetChapters), new {id = NewChapter.Id}, NewChapter);
        }


        [HttpPut]
        public async Task<ActionResult> PutBooks(int id, [FromBody] ChapterModel chapter)
        {
            if (id != chapter.Id)
            {
                return BadRequest();
            }

            await _chapterRepository.Update(chapter);
            return NoContent();
        }


        [HttpDelete]
        public async Task<ActionResult> DeleteChapters(int id)
        {
            var chapterToDelete = await _chapterRepository.Get(id);
            if (chapterToDelete == null)
            {
                return NotFound();
            }

            await _chapterRepository.Delete(id);
            return NoContent();
        }
    }
}
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
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<BookModel>> GetBooks()
        {
            return await _bookRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookModel>> GetBooks(int id)
        {
            return await _bookRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<BookModel>> PostBooks([FromBody] BookModel book)
        {
            var NewBook = await _bookRepository.Create(book);
            return CreatedAtAction(nameof(GetBooks), new {id = NewBook.Id}, NewBook);
        }

        [HttpPut]
        public async Task<ActionResult> PutBooks(int id, [FromBody] BookModel book)
        {
            if (id != book.Id)
            {
                return BadRequest(); 
            }

            await _bookRepository.Update(book);
            return NoContent();
        }
        
        [HttpDelete]
        public async Task<ActionResult> DeleteBooks(int id)
        {
            var BookToDelete = await _bookRepository.Get(id);
            if (BookToDelete == null)
            {
                return NotFound();
            }

            await _bookRepository.Delete(id);
            return NoContent();
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Induction.Data;
using Induction.Models;
using Microsoft.EntityFrameworkCore;

namespace Induction.Repositories
{
    public class BookRepository :  IBookRepository
    {
        private readonly AppDbContext _context; 

        public BookRepository(AppDbContext context)
        {
            this._context = context; 
        }
        public async Task<IEnumerable<BookModel>> Get()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<BookModel> Get(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<BookModel> Create(BookModel Book)
        {
            _context.Books.Add(Book);
            await _context.SaveChangesAsync();
            return Book;
        }

        public async Task Update(BookModel Book)
        {
            _context.Entry(Book).State = EntityState.Modified;
            await _context.SaveChangesAsync(); 
        }

        public async Task Delete(int id)
        {
            var BookToDelete = await _context.Books.FindAsync(id);
            _context.Books.Remove(BookToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
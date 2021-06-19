using System.Collections.Generic;
using System.Threading.Tasks;
using Induction.Data;
using Induction.Models;
using Microsoft.EntityFrameworkCore;

namespace Induction.Repositories
{
    public class QuoteRepository :IQuotesRepository
    {
        private readonly AppDbContext _context; 
        
        public QuoteRepository(AppDbContext context)
        {
            this._context = context; 
        }

        public async Task<IEnumerable<QouteModel>> Get()
        {
            return await _context.Quotes.ToListAsync();
        }

        public async Task<QouteModel> Get(int id)
        {
            return await _context.Quotes.FindAsync(id);
        }

        public async Task<QouteModel> Create(QouteModel Quote)
        {
            _context.Quotes.Add(Quote);
            await _context.SaveChangesAsync();
            return Quote;
        }

        public async Task Update(QouteModel Quote)
        {
            _context.Entry(Quote).State = EntityState.Modified;
            await _context.SaveChangesAsync(); 
        }

        public async Task Delete(int id)
        {
            var QuoteToDelete = await _context.Quotes.FindAsync(id);
            _context.Quotes.Remove(QuoteToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
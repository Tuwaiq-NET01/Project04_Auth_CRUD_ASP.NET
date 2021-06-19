using System.Collections.Generic;
using System.Threading.Tasks;
using Induction.Data;
using Induction.Models;
using Microsoft.EntityFrameworkCore;

namespace Induction.Repositories
{
    public class FlashCardRepository : IFlashCardRepository
    {
        private readonly AppDbContext _context;

        public FlashCardRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<FlashCardModel>> Get()
        {
            return await _context.FlashCards.ToListAsync();
        }

        public async Task<FlashCardModel> Get(int id)
        {
            return await _context.FlashCards.FindAsync(id);
        }

        public async Task<FlashCardModel> Create(FlashCardModel FlashCard)
        {
            _context.FlashCards.Add(FlashCard);
            await _context.SaveChangesAsync();
            return FlashCard;
        }

        public async Task Update(FlashCardModel FlashCard)
        {
            _context.Entry(FlashCard).State = EntityState.Modified;
            await _context.SaveChangesAsync(); 
        }

        public async Task Delete(int id)
        {
            var FlashCardToDelete = await _context.FlashCards.FindAsync(id);
            _context.FlashCards.Remove(FlashCardToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Induction.Data;
using Induction.Models;
using Microsoft.EntityFrameworkCore;

namespace Induction.Repositories
{
    public class FactRepository : IFactRepository
    {
        private readonly AppDbContext _context;

        public FactRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<FactModel>> Get()
        {
            return await _context.Facts.ToListAsync();
        }

        public async Task<FactModel> Get(int id)
        {
            return await _context.Facts.FindAsync(id);
        }

        public async Task<FactModel> Create(FactModel Fact)
        {
            _context.Facts.Add(Fact);
            await _context.SaveChangesAsync();
            return Fact;
        }

        public async Task Update(FactModel Fact)
        {
            _context.Entry(Fact).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var FactToDelete = await _context.Facts.FindAsync(id);
            _context.Facts.Remove(FactToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
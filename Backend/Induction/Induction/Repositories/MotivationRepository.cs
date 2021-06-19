using Induction.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Induction.Models;
using Microsoft.EntityFrameworkCore;

namespace Induction.Repositories
{
    public class MotivationRepository : IMotavationRepository
    {
        private readonly AppDbContext _context; 
        public MotivationRepository(AppDbContext context)
        {
            this._context = context; 
        }
        
        public async Task<IEnumerable<MotivationModel>> Get()
        {
            return await _context.Motivations.ToListAsync();
        }

        public async Task<MotivationModel> Get(int id)
        {
            return await _context.Motivations.FindAsync(id);

        }

        public async Task<MotivationModel> Create(MotivationModel Motivation)
        {
            _context.Motivations.Add(Motivation);
            await _context.SaveChangesAsync();
            return Motivation;
        }

        public async Task Update(MotivationModel Motivation)
        {
            _context.Entry(Motivation).State = EntityState.Modified;
            await _context.SaveChangesAsync(); 
        }

        public async Task Delete(int id)
        {
            var MotivationToDelete = await _context.Motivations.FindAsync(id);
            _context.Motivations.Remove(MotivationToDelete);
            await _context.SaveChangesAsync();
        }
        
        
        
    }
}
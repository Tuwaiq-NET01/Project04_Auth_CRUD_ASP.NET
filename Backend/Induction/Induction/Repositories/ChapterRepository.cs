using System.Collections.Generic;
using System.Threading.Tasks;
using Induction.Data;
using Induction.Models;
using Microsoft.EntityFrameworkCore;

namespace Induction.Repositories
{
    public class ChapterRepository : IChapterRepository
    {
        private readonly AppDbContext _context;

        public ChapterRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<ChapterModel>> Get()
        {
            return await _context.Chapters.ToListAsync();
        }

        public async Task<ChapterModel> Get(int id)
        {
            return await _context.Chapters.FindAsync(id);
        }

        public async Task<ChapterModel> Create(ChapterModel Chapter)
        {
            _context.Chapters.Add(Chapter);
            await _context.SaveChangesAsync();
            return Chapter;
        }

        public async Task Update(ChapterModel Chapter)
        {
            _context.Entry(Chapter).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
        }

        public async Task Delete(int id)
        {
            var ChapterToDelete = await _context.Chapters.FindAsync(id);
            _context.Chapters.Remove(ChapterToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Induction.Data;
using Induction.Models;
using Microsoft.EntityFrameworkCore;

namespace Induction.Repositories
{
    public class ChapterChunkRepository : IChapterChunkRepository
    {
        private readonly AppDbContext _context;

        public ChapterChunkRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<ChapterChunkModel>> Get()
        {
            return await _context.ChapterChunks.ToListAsync();
        }

        public async Task<ChapterChunkModel> Get(int id)
        {
            return await _context.ChapterChunks.FindAsync(id);
        }

        public async Task<ChapterChunkModel> Create(ChapterChunkModel ChapterChunk)
        {
            _context.ChapterChunks.Add(ChapterChunk);
            await _context.SaveChangesAsync();
            return ChapterChunk;
        }

        public async Task Update(ChapterChunkModel ChapterChunk)
        {
            _context.Entry(ChapterChunk).State = EntityState.Modified;
            await _context.SaveChangesAsync(); 
        }

        public async Task Delete(int id)
        {
            var ChapterChunkToDelete = await _context.ChapterChunks.FindAsync(id);
            _context.ChapterChunks.Remove(ChapterChunkToDelete);
            await _context.SaveChangesAsync();        }
    }
}
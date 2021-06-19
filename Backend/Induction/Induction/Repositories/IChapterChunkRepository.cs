using System.Collections.Generic;
using System.Threading.Tasks;
using Induction.Models;

namespace Induction.Repositories
{
   
        public interface IChapterChunkRepository
        {
            Task<IEnumerable<ChapterChunkModel>> Get();
            Task<ChapterChunkModel> Get(int id);
            Task<ChapterChunkModel> Create(ChapterChunkModel ChapterChunk);
            Task Update(ChapterChunkModel ChapterChunk);
            Task Delete(int id); 
        }
    
}
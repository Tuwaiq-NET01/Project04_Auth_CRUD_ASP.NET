using System.Collections.Generic;
using System.Threading.Tasks;
using Induction.Models;

namespace Induction.Repositories
{
    public interface IChapterRepository
    {
        Task<IEnumerable<ChapterModel>> Get();
        Task<ChapterModel> Get(int id);
        Task<ChapterModel> Create(ChapterModel Chapter);
        Task Update(ChapterModel Chapter);
        Task Delete(int id); 
    }
}
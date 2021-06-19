using System.Collections.Generic;
using System.Threading.Tasks;
using Induction.Models;

namespace Induction.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookModel>> Get();
        Task<BookModel> Get(int id);
        Task<BookModel> Create(BookModel Book);
        Task Update(BookModel Book);
        Task Delete(int id); 
    }
}
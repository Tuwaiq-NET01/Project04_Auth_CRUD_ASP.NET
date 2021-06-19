using System.Collections.Generic;
using System.Threading.Tasks;
using Induction.Models;

namespace Induction.Repositories
{
    public interface IFactRepository
    {
        Task<IEnumerable<FactModel>> Get();
        Task<FactModel> Get(int id);
        Task<FactModel> Create(FactModel Fact);
        Task Update(FactModel Fact); 
        Task Delete(int id); 
    }
}
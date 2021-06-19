using System.Collections.Generic;
using System.Threading.Tasks;
using Induction.Models;

namespace Induction.Repositories
{
    public interface IQuotesRepository
    {
        Task<IEnumerable<QouteModel>> Get();
        Task<QouteModel> Get(int id);
        Task<QouteModel> Create(QouteModel Quote);
        Task Update(QouteModel Quote);
        Task Delete(int id); 
    }
}
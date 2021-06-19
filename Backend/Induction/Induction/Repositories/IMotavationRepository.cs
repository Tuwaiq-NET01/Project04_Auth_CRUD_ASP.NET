using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Induction.Models;

namespace Induction.Repositories
{
    public interface IMotavationRepository
    {
        Task<IEnumerable<MotivationModel>> Get();
        Task<MotivationModel> Get(int id);
        Task<MotivationModel> Create(MotivationModel Motivation);
        Task Update(MotivationModel Motivation); 
        Task Delete(int id); 
    }
}
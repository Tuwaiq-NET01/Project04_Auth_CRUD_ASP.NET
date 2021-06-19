using System.Collections.Generic;
using System.Threading.Tasks;
using Induction.Models;

namespace Induction.Repositories
{
    public interface IFlashCardRepository
    {
        Task<IEnumerable<FlashCardModel>> Get();
        Task<FlashCardModel> Get(int id);
        Task<FlashCardModel> Create(FlashCardModel FlashCard);
        Task Update(FlashCardModel FlashCard);
        Task Delete(int id);  
    }
}
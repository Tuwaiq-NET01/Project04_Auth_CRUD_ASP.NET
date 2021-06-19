using System;
using System.Threading.Tasks;
using Induction.Models;

namespace Induction.Repositories
{
    public interface IUserRepository
    {

        Task<UserModel> Create(UserModel user);

        Task<UserModel> GetUserByEmail(string email);
        Task<UserModel> GetUserById(int id);

    }
}

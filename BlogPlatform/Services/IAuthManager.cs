using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using BlogPlatform.Models;

namespace BlogPlatform.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(Person user);
        Task<string> CreateToken();
        JwtSecurityToken VerifyToken(string jwt);
    }
}
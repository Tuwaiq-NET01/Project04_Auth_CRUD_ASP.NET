using System;
using System.IdentityModel.Tokens.Jwt;

namespace Induction.Helpers
{
   public interface IJwtService
   {
        string Generate(int id);
        JwtSecurityToken Verify(string jwt);
    }
}

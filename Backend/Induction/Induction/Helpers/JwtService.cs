using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Induction.Helpers
{
    public class JwtService: IJwtService
    {
        private DateTime TOKEN_EXPIRATION = DateTime.Today.AddDays(1);

        private string secretKey = "nQjRUnJ4230n6iWLbfoGJMqToMd3GUsanQjRUnJ4230n6iWLbfoGJMqToMd3GUsapiMP2KVr28SPd9pAvoeGzdHOAIrhaVh";

        public string Generate(int id)
        {
            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credintials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            var header = new JwtHeader(credintials);
            var payload = new JwtPayload(id.ToString(), null, null, null, DateTime.Today.AddDays(1));

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public JwtSecurityToken Verify(string jwt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            tokenHandler.ValidateToken(jwt, new TokenValidationParameters{

                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,

                ValidateIssuer = false,
                ValidateAudience = false
            }
             , out SecurityToken validatedToken);

            return (JwtSecurityToken)validatedToken;

        }
    }
}

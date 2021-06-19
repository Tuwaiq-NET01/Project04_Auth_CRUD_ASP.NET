using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace WEBv3.Helpers
{
    public class Decodepayload
    {

        public Decodepayload()
        {

        }
        public string decodePaload(string token)
        {
            var jsonToken = new JwtSecurityTokenHandler().ReadToken(token.Replace("Bearer ", ""));
            var tokenData = jsonToken as JwtSecurityToken;
            var userId = tokenData.Claims.First(claim => claim.Type == "uid").Value;
            return userId;
        }
    }
}

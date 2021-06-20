using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogPlatform.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogPlatform.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<Person> _userManager;
        private readonly IConfiguration _configuration;
        private Person _user;

        public AuthManager(UserManager<Person> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<bool> ValidateUser(Person userLogin)
        {
            _user = await _userManager.FindByNameAsync(userLogin.Email);
            return (_user != null && await _userManager.CheckPasswordAsync(_user, userLogin.Password));
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var token = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public JwtSecurityToken VerifyToken(string jwt)
        {
            //var jwtSettings = _configuration.GetSection("Jwt");
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET"));
            tokenHandler.ValidateToken(jwt, new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                
                ValidateIssuer = false,
                ValidateAudience = false
            }, out SecurityToken validatedToken);

            return (JwtSecurityToken) validatedToken;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var lifetime = jwtSettings.GetSection("lifetime").Value;
            var expiration = DateTime.Now.AddMinutes(Convert.ToDouble(lifetime));

            var token = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("Issuer").Value,
                claims: claims,
                expires: expiration,
                signingCredentials: signingCredentials
            );

            return token;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.UserName)
            };
            return claims;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Environment.GetEnvironmentVariable("JWT_SECRET");
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key ?? string.Empty));
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
    }
}
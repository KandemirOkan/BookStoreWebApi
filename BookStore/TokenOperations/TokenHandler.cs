using BookStoreWebApi.Entities;
using BookStoreWebApi.TokenOperations.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BookStoreWebApi.TokenOperations
{
    public class TokenHandler
    {
        private readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token CreateAccesToken(User user)
        {
            Token tokenModel = new();
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            tokenModel.Expiration = DateTime.Now.AddMinutes(15);
            JwtSecurityToken securityToken = new(
                            issuer: _configuration["Token:Issuer"],
            audience: _configuration["Token:Audience"],
            expires: tokenModel.Expiration,
            notBefore: DateTime.Now,
            signingCredentials: signingCredentials
                );
            JwtSecurityTokenHandler tokenHandler = new();
            tokenModel.AccessToken= tokenHandler.WriteToken( securityToken );
            tokenModel.RefreshToken = CreateRefreshToken();
            return tokenModel;
        }
        private string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();   
        }
    }
}

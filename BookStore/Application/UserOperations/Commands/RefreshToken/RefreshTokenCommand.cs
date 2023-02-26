using BookStoreWebApi.DBOperations;
using BookStoreWebApi.TokenOperations;
using BookStoreWebApi.TokenOperations.Models;

namespace BookStoreWebApi.Application.UserOperations.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {
        public string RefreshToken { get; set; }
        private readonly IBookStoreDbContext _context;
        private readonly IConfiguration _configuration;

        public RefreshTokenCommand(IBookStoreDbContext context,IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public Token Handle()
        {
            var user = _context.Users.FirstOrDefault(x=>x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate>DateTime.Now);
            if (user is not null)
            {
                TokenHandler tokenHandler = new(_configuration);
                Token token = tokenHandler.CreateAccesToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _context.SaveChanges();
                return token;
            }
            else
                throw new InvalidOperationException("No valid refresh token was found!");
        }
    }
}

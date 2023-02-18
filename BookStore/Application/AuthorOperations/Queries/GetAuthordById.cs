using AutoMapper;
using BookStoreWebApi.DBOperations;

namespace BookStoreWebApi.Application.AuthorOperations.Quearies
{
    public class GetAuthorById
    {
        public int AuthorId { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAuthorById(IBookStoreDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public AuthorViewIdModel Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x=>x.Id==AuthorId);         
            return _mapper.Map<AuthorViewIdModel>(author);         
        }
    }
    public class AuthorViewIdModel{
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public DateTime BirthDate { get; set; }
    }
    
}
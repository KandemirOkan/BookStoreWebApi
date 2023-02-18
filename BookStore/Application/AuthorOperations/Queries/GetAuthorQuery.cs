using AutoMapper;
using BookStoreWebApi.DBOperations;
using BookStoreWebApi.Entities;

namespace BookStoreWebApi.Application.AuthorOperations.Quearies
{
    public class GetAuthorQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAuthorQuery(IBookStoreDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<AuthorViewModel> Handle()
        {
            var authorList = _dbContext.Authors.OrderBy(x=>x.Id).ToList<Author>();
            return _mapper.Map<List<AuthorViewModel>>(authorList);         
        }
    }
    public class AuthorViewModel{

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public DateTime BirthDate { get; set; }
    }  
}
using AutoMapper;
using BookStoreWebApi.DBOperations;
using BookStoreWebApi.Entities;

namespace BookStoreWebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateGenreCommand(BookStoreDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x=>x.Id==Model.Id);
            if (author is not null)
            {
                throw new InvalidOperationException("Database'inizde Bu Id'ye sahip bir yazar bulunmaktadır.");
            }
            author = _mapper.Map<Author>(Model);
            _dbContext.Add(author);
            _dbContext.SaveChanges();
        }
    }
    //Id AutoIncrement olduğu için almaya gerek yok.
    public class CreateAuthorModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

    }
}
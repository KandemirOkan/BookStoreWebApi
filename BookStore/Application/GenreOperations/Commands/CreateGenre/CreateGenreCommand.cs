using AutoMapper;
using BookStoreWebApi.DBOperations;
using BookStoreWebApi.Entities;

namespace BookStoreWebApi.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateGenreCommand(BookStoreDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x=>x.Id==Model.Id);
            if (genre is not null)
            {
                throw new InvalidOperationException("Database'inizde Bu Id'ye sahip bir Genre bulunmaktadır.");
            }
            genre = _mapper.Map<Genre>(Model);
            _dbContext.Add(genre);
            _dbContext.SaveChanges();
        }
    }
    //Id AutoIncrement olduğu için almaya gerek yok.
    public class CreateGenreModel
    {
        public string Name { get; set; }
    }
}
using AutoMapper;
using BookStoreWebApi.DBOperations;

namespace BookStoreWebApi.Application.GenreOperations.Quearies
{
    public class GetGenreById
    {
        public int GenreId { get; set; }
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGenreById(BookStoreDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public GenreViewIdModel Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x=>x.Id==GenreId);         
            return _mapper.Map<GenreViewIdModel>(genre);         
        }
    }
    public class GenreViewIdModel{
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
}
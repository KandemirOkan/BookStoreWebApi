using AutoMapper;
using BookStoreWebApi.DBOperations;

namespace BookStoreWebApi.Application.GenreOperations.Quearies
{
    public class GetGenreQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGenreQuery(BookStoreDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<GenreViewModel> Handle()
        {
            var genres = _dbContext.Genres.Where(x=>x.IsActive).OrderBy(x=>x.Id);
            List<GenreViewModel> rg = _mapper.Map<List<GenreViewModel>>(genres);
            return rg;         
        }
    }
    public class GenreViewModel{
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
}
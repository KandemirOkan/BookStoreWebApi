using AutoMapper;
using BookStoreWebApi.DBOperations;
using BookStoreWebApi.Entities;

namespace BookStoreWebApi.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int GenreId { get; set; }

        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var genre = _dbContext.Genres.Where(x=>x.Id==GenreId).SingleOrDefault();
            if (genre is null)
            {
                throw new InvalidOperationException("Geçersiz bir ID numarası girdiniz.");
            }
            _dbContext.Genres.Remove(genre);
            _dbContext.SaveChanges();
        }
    }
}
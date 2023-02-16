using BookStoreWebApi.DBOperations;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApi.Application.BookOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public UpdateBookModel Model { get; set; }
        public int GenreId { get; set; }
        private readonly BookStoreDbContext _dbContext;

        public GenreBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x=>x.Id==GenreId);
            if (genre is null)
            {
                throw new InvalidOperationException("Güncellemek istediğiniz genre id'si databasede bulunmuyor.");
            }
            //Any() = Baktığı obje içerisinde en az 1 eşleşme bulursa true döner.
            if(_dbContext.Genres.Any(x=>x.Name.ToLower() == Model.Name.ToLower() && x.Id != Model.Id))
            {
                throw new InvalidOperationException("Bu kitap türü farklı bir id numarası ile database'de kayıtlı bulunmaktadır. ");
            }
            //Trim gelen string'in sonunda boşluk varsa siler.
            genre.Name = Model.Name.Trim() == default ? genre.Name : Model.Name;
            genre.IsActive = Model.IsActive;
            _dbContext.SaveChanges();
        }
    }
    public class UpdateGenreModel
    {
        public string? Name { get; set; }

        public bool IsActive{get;set;} = true;
    }
}
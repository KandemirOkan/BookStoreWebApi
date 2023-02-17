using BookStoreWebApi.DBOperations;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public UpdateAuthorModel Model { get; set; }
        public int AuthorId { get; set; }
        private readonly BookStoreDbContext _dbContext;

        public GenreBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x=>x.Id==AuthorId);
            if (author is null)
            {
                throw new InvalidOperationException("Güncellemek istediğiniz genre id'si databasede bulunmuyor.");
            }
            //Any() = Baktığı obje içerisinde en az 1 eşleşme bulursa true döner.
            if(_dbContext.Authors.Any(x=>x.FirstName.ToLower() == Model.FirstName.ToLower()&& x.LastName.ToLower() == Model.LastName.ToLower() && x.Id != Model.Id))
            {
                throw new InvalidOperationException("Bu kitap türü farklı bir id numarası ile database'de kayıtlı bulunmaktadır. ");
            }
            //Trim gelen string'in sonunda boşluk varsa siler.
            author = _mapper.Map<Author>(Model);
            _dbContext.Add(author);
            author.IsActive = Model.IsActive;
            _dbContext.SaveChanges();
        }
    }
    public class UpdateAuthorModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
using BookStoreWebApi.DBOperations;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApi.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommand
    {
        public UpdateBookModel Model { get; set; }
        public int BookId { get; set; }
        private readonly IBookStoreDbContext _dbContext;

        public UpdateBookCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x=>x.Id==BookId);
            if (book is null)
            {
                throw new InvalidOperationException("Güncellemek istediğiniz kitap id'si databasede bulunmuyor.");
            }
            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
            book.Title = Model.Title != default ? Model.Title : book.Title;
            _dbContext.SaveChanges();
        }
    }
    public class UpdateBookModel
    {
        public string? Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }

        public string? Author { get; set; }
    }
}
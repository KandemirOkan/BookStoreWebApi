using BookStoreWebApi.DBOperations;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApi.BookOperations.Commands.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;

        public CreateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public void Handle()
        {
        var book = _dbContext.Books.SingleOrDefault(x=>x.Title==Model.Title);
        if(book is not null)
            throw new InvalidOperationException("Bu isimdeki bir kitap zaten Database'de mevcut.");

        book.GenreId = Model.GenreId;
        book.Title = Model.Title;
        book.PageCount = Model.PageCount;
        _dbContext.Books.Add(book);
        _dbContext.SaveChanges();

        }
        
    }
    public class CreateBookModel
    {
        public string? Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
    }
}
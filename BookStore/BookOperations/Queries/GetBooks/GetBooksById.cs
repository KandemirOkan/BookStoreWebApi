using BookStoreWebApi.Common;
using BookStoreWebApi.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApi.BookOperations.Queries.GetBooks
{
    public class GetBooksById
    {
        private readonly BookStoreDbContext _dbContext;

        public GetBooksById(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public BooksViewIdModel Handle(int id)
        {
            var vm = new BooksViewIdModel();
            var book = _dbContext.Books.Where(x=>x.Id==id).SingleOrDefault();
            if (book is null)
            {
                throw new InvalidOperationException("Aradığınız Id'de kitap bulunmamaktadır.");
            }
           new BooksViewIdModel();
           {
             vm.Title = book.Title;
             vm.Genre = ((GenreEnum)book.GenreId).ToString();
             vm.PageCount = book.PageCount;
             vm.Author = book.Author;
           };
           
           return vm;
        }
    }
    public class BooksViewIdModel
    {
        public string Title { get; set; }

        public int PageCount { get; set; }

        public string Genre { get; set; }

        public string Author { get; set; }
    }
}
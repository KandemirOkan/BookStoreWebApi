using BookStoreWebApi.Common;
using BookStoreWebApi.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApi.BookOperations.Queries.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;

        public GetBooksQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.OrderBy(x=>x.Id).ToList<Book>();
            List<BooksViewModel> vm = new List<BooksViewModel>();
            foreach (var book in bookList)
            {
                vm.Add(new BooksViewModel()
                {
                    Title = book.Title,
                    PageCount = book.PageCount,
                    Author = book.Author,
                    Genre = ((GenreEnum)book.GenreId).ToString()
                    
                });
            }
            return vm;
        }
    }
        public class BooksViewModel
    {
        public string Title { get; set; }

        public int PageCount { get; set; }

        public string Genre { get; set; }

        public string Author { get; set; }
    }
}
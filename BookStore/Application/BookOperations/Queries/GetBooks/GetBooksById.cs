using AutoMapper;
using BookStoreWebApi.Common;
using BookStoreWebApi.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApi.Application.BookOperations.Queries.GetBooks
{
    public class GetBooksById
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }
        private readonly IMapper _mapper;

        public GetBooksById(BookStoreDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public BooksViewIdModel Handle()
        {
            var book = _dbContext.Books.Where(x=>x.Id==BookId).SingleOrDefault();
            if (book is null)
            {
                throw new InvalidOperationException("Aradığınız Id'de kitap bulunmamaktadır.");
            }
            BooksViewIdModel vm = _mapper.Map<BooksViewIdModel>(book);
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
using AutoMapper;
using BookStoreWebApi.Common;
using BookStoreWebApi.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApi.BookOperations.Queries.GetBooks
{
    public class GetBooksById
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBooksById(BookStoreDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public BooksViewIdModel Handle(int id)
        {
            var book = _dbContext.Books.Where(x=>x.Id==id).SingleOrDefault();
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
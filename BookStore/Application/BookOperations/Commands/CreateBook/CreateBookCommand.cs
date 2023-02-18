using AutoMapper;
using BookStoreWebApi.DBOperations;
using BookStoreWebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApi.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateBookCommand(IBookStoreDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public void Handle()
        {
        var book = _dbContext.Books.SingleOrDefault(x=>x.Title==Model.Title);
        if(book is not null)
            throw new InvalidOperationException("Bu isimdeki bir kitap zaten Database'de mevcut.");
        book = _mapper.Map<Book>(Model);
        _dbContext.Books.Add(book);
        _dbContext.SaveChanges();
        }
        
    }
    public class CreateBookModel
    {
        public string? Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public int AuthorId { get; set; }
    }
}
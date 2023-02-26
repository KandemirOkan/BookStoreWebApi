using AutoMapper;
using BookStoreWebApi.Application.BookOperations.Commands.CreateBook;
using BookStoreWebApi.DBOperations;
using BookStoreWebApi.Entities;
using FluentAssertions;
using TestSetup;

namespace WebApi.UnitTests.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandTest:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommandTest(CommonTestFixture commonTestFixture)
        {
            _context = commonTestFixture.DbContext;
            _mapper = commonTestFixture.Mapper;
        }

        [Fact]
        public void When_AlreadyExistBookIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            var book = new Book(){Title="Deneme Kitap",PageCount=159,GenreId=3};
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
            command.Model = new CreateBookModel(){Title=book.Title};


            FluentActions
            .Invoking(()=>command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu isimdeki bir kitap zaten Database'de mevcut.");
        }
        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeCreated()
        {
            CreateBookCommand command = new(_context, _mapper);
            CreateBookModel model = new CreateBookModel()
            {
                Title = "Hobbit",
                GenreId = 3,
                PageCount = 350
            };
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();    

            var book = _context.Books.SingleOrDefault(x=>x.Title==model.Title);
            book.Should().NotBeNull();  
            book.Genre.Should().NotBeNull();
        }
    }
}
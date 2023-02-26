using AutoMapper;
using BookStoreWebApi.Application.BookOperations.Commands.DeleteBook;
using BookStoreWebApi.DBOperations;
using BookStoreWebApi.Entities;
using FluentAssertions;
using TestSetup;

namespace WebApi.UnitTests.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandTest:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public DeleteBookCommandTest(CommonTestFixture commonTestFixture)
        {
            _context = commonTestFixture.DbContext;
            _mapper = commonTestFixture.Mapper;
        }

        [Fact]
        public void When_NotExistBookIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            DeleteBookCommand command = new(_context);
            command.BookId = 150;

            FluentActions
            .Invoking(()=>command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Geçersiz bir ID numarası girdiniz.");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeDeleted()
        {
            DeleteBookCommand command = new(_context);
            command.BookId = 1;
            FluentActions.Invoking(() => command.Handle()).Invoke();    

            var book = _context.Books.SingleOrDefault(book=>book.Id==command.BookId);
            book.Should().Be(null);
        }
    }
}
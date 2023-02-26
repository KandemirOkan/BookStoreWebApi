using AutoMapper;
using BookStoreWebApi.Application.BookOperations.Commands.UpdateBook;
using BookStoreWebApi.DBOperations;
using BookStoreWebApi.Entities;
using FluentAssertions;
using TestSetup;

namespace WebApi.UnitTests.Application.BookOperations.Commands.CreateBook
{
    public class UpdateBookCommandTest:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateBookCommandTest(CommonTestFixture commonTestFixture)
        {
            _context = commonTestFixture.DbContext;
            _mapper = commonTestFixture.Mapper;
        }

        [Fact]
        public void When_AlreadyNotExistBookIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            UpdateBookCommand command = new(_context);
            command.BookId = 150;
            FluentActions
            .Invoking(()=>command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellemek istediğiniz kitap id'si databasede bulunmuyor.");
        }
        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeUpdated()
        {
        UpdateBookCommand command = new(_context);
        var book = new Book { Title = "Test Book", GenreId = 1, AuthorId = 1, PageCount = 100 };

        _context.Books.Add(book);
        _context.SaveChanges();

        command.BookId = book.Id;
        UpdateBookModel model = new UpdateBookModel { Title = "Updated Title", GenreId = 2,PageCount=999 };
        command.Model = model;

        // act
        FluentActions.Invoking(() => command.Handle()).Invoke();
        // assert
        var updatedBook = _context.Books.SingleOrDefault(b => b.Id == book.Id);
        updatedBook.Should().NotBeNull();
        updatedBook.Title.Should().Be(model.Title);
        updatedBook.GenreId.Should().Be(model.GenreId);

        }
    }
}
using AutoMapper;
using BookStoreWebApi.Application.AuthorOperations.Commands.CreateAuthor;
using BookStoreWebApi.DBOperations;
using BookStoreWebApi.Entities;
using FluentAssertions;
using TestSetup;

namespace WebApi.UnitTests.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateAuthorCommandTest(CommonTestFixture commonTestFixture)
        {
            _context = commonTestFixture.DbContext;
            _mapper = commonTestFixture.Mapper;
        }

        [Fact]
        public void When_AlreadyExistAuthorIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            var author = new Author() { FirstName = "Cengiz", LastName = "Aytmatov", BirthDate = new DateTime(1928,12,12) };
            _context.Authors.Add(author);
            _context.SaveChanges();

            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            command.Model = new CreateAuthorModel() { FirstName = author.FirstName, LastName = author.LastName, BirthDate = author.BirthDate  };


            FluentActions
            .Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Database'inizde bu isme sahip bir yazar bulunmaktadır.");
        }
        [Fact]
        public void WhenValidInputsAreGiven_Author_ShouldBeCreated()
        {
            CreateAuthorCommand command = new(_context, _mapper);
        CreateAuthorModel model = new CreateAuthorModel()
        {
            FirstName = "Sabahattin",
            LastName = "Ali",
            BirthDate = new DateTime(1907,02,25)
            };
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var author = _context.Authors.SingleOrDefault(x => x.FirstName == model.FirstName && x.LastName == model.LastName && x.BirthDate == model.BirthDate);
            author.Should().NotBeNull();

        }
    }
}
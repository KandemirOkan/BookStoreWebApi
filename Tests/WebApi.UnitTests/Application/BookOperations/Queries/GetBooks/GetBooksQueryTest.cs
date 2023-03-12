using AutoMapper;
using BookStoreWebApi.Application.BookOperations.Queries.GetBooks;
using BookStoreWebApi.DBOperations;
using BookStoreWebApi.Entities;
using FluentAssertions;
using TestSetup;

namespace WebApi.UnitTests.Application.BookOperations.Queries.GetBooks
{
    public class GetBooksQueryTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetBooksQueryTest(CommonTestFixture commonTestFixture)
        {
            _context = commonTestFixture.DbContext;
            _mapper = commonTestFixture.Mapper;
        }

        [Fact]
        public void WhenGetBooksQueryIsHandled_BookList_ShouldBeReturn()
        {
            var query = new GetBooksQuery(_context, _mapper);

            var result = query.Handle();

            result.Should().NotBeNull();
            result.Should().HaveCount(3);

            result[0].Title.Should().Be("Sapiens");
            result[0].Genre.Should().Be("Science Ficton");
            result[0].Author.Should().Be("Yuval Noah");
            result[0].PageCount.Should().Be(255);

        }
    }
}
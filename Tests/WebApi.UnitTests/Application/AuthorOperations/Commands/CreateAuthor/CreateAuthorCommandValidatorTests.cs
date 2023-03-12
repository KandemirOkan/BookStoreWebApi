using AutoMapper;
using BookStoreWebApi.Application.BookOperations.Commands.CreateAuthor;
using BookStoreWebApi.DBOperations;
using BookStoreWebApi.Entities;
using FluentAssertions;
using TestSetup;

namespace WebApi.UnitTests.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("of", 0, 2)]
        [InlineData("Rings", 1, 0)]
        [InlineData("", 80, 2)]
        [InlineData("Lord", 1, 2)]
        [InlineData("Lord", -1, 2)]
        [InlineData("of", 500, 2)]
        [InlineData("O", 60, 2)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(string name)
        {
            CreateBookCommand command = new(null, null);
            command.Model = new()
            {
                Title = _title,
                PageCount = _pageCount,
                GenreId = _genreId
            };
            CreateBookCommandValidator validator = new();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldReturnError()
        {
            CreateBookCommand command = new(null, null);
            command.Model = new()
            {
                Title = "S",
                PageCount = 100,
                GenreId = 2
            };
            CreateBookCommandValidator validator = new();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            CreateBookCommand command = new(null, null);
            command.Model = new CreateBookModel()
            {
                Title = "Simyaci",
                PageCount = 100,
                GenreId = 2
            };
            CreateBookCommandValidator validator = new();
            var result = validator.Validate(command);
            result.Errors.Count.Should().Be(0);
        }
    }
}
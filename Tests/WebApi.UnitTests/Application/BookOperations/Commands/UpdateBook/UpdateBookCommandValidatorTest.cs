using AutoMapper;
using BookStoreWebApi.Application.BookOperations.Commands.UpdateBook;
using BookStoreWebApi.DBOperations;
using BookStoreWebApi.Entities;
using FluentAssertions;
using TestSetup;

namespace WebApi.UnitTests.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandValidatorTest:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("of",0,2)]
        [InlineData("Rings",1,0)]
        [InlineData("",80,2)]
        [InlineData("Lord",1,2)]
        [InlineData("Lord",-1,2)]
        [InlineData("of",500,2)]
        [InlineData("O",60,2)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(string _title, int _pageCount, int _genreId)
        {
            UpdateBookCommand command = new(null);
            command.Model = new()
            {
                Title = _title,
                PageCount = _pageCount,
                GenreId = _genreId
            };
            UpdateBookCommandValidator validator = new();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            UpdateBookCommand command = new(null);
            command.Model = new UpdateBookModel()
            {
                Title = "Simyaci",
                PageCount = 100,
                GenreId = 2,
                Author="Paulo Coelho"
            };
            UpdateBookCommandValidator validator = new();
            var result = validator.Validate(command);
            result.Errors.Count.Should().Be(0);
        }
    }
}

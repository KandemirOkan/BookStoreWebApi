using AutoMapper;
using BookStoreWebApi.Application.BookOperations.Commands.DeleteBook;
using BookStoreWebApi.DBOperations;
using BookStoreWebApi.Entities;
using FluentAssertions;
using TestSetup;

namespace WebApi.UnitTests.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandValidatorTest:IClassFixture<CommonTestFixture>
    {

        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(-51)]
        [InlineData(-561)]
        [Theory]
        public void WhenBookIdLessThanOrEqualZero_Validator_ShouldReturnError(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(null);
            command.BookId = id;
            DeleteBookCommandValidator validator = new(); 
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [InlineData(1)]
        [InlineData(10)]
        [InlineData(51)]
        [InlineData(561)]
        [Theory]
        public void WhenBookIdGreaterThanZero_Validator_ShouldNotReturnError(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(null);
            command.BookId = id;
            DeleteBookCommandValidator validator = new(); 
            var result = validator.Validate(command);
            result.Errors.Count.Should().Be(0);
        }
    }
}
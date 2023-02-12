using FluentValidation;

namespace BookStoreWebApi.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(x=>x.BookId).GreaterThan(0);
        }
    }
}
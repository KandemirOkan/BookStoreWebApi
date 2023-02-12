using FluentValidation;

namespace BookStoreWebApi.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x=>x.Model.Author).NotEmpty().MinimumLength(3);
            RuleFor(x=>x.Model.PageCount).GreaterThan(50);
            RuleFor(x=>x.Model.GenreId).GreaterThan(0);
            RuleFor(x=>x.Model.Title).NotEmpty().MinimumLength(2);
        }
    }
}
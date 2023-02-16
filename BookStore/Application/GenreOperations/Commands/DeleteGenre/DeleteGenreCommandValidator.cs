using FluentValidation;

namespace BookStoreWebApi.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(x=>x.GenreId).GreaterThan(0);
        }
    }
}
using FluentValidation;

namespace BookStoreWebApi.Application.BookOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(x=>x.Model.Name).MinimumLength(3).When(x=>x.Model.Name.Trim() != string.Empty);
        }
    }
}
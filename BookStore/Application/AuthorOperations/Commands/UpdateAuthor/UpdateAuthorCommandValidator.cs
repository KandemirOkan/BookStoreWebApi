using FluentValidation;

namespace BookStoreWebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(x=>x.Model.FirstName).MinimumLength(3).When(x=>x.Model.FirstName.Trim() != string.Empty);
            RuleFor(x=>x.Model.LastName).MinimumLength(3).When(x=>x.Model.LastName.Trim() != string.Empty);
        }
    }
}
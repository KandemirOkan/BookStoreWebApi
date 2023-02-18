using FluentValidation;

namespace BookStoreWebApi.Application.AuthorOperations.Quearies
{
    public class GetAuthorByIdValidator: AbstractValidator<GetAuthorById>
    {
        public GetAuthorByIdValidator()
        {
            RuleFor(x=>x.AuthorId).GreaterThan(0);
        }
    }
}
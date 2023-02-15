using FluentValidation;

namespace BookStoreWebApi.Application.GenreOperations.Quearies
{
    public class GetGenreByIdValidator: AbstractValidator<GetGenreById>
    {
        public GetGenreByIdValidator()
        {
            RuleFor(x=>x.GenreId).GreaterThan(0);
        }
    }
}
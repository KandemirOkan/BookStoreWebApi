using FluentValidation;

namespace BookStoreWebApi.BookOperations.Queries.GetBooks
{
    public class GetBooksByIdValidator : AbstractValidator<GetBooksById>
    {
        public GetBooksByIdValidator()
        {
            RuleFor(x=>x.BookId).GreaterThan(0);
        }
    }
}
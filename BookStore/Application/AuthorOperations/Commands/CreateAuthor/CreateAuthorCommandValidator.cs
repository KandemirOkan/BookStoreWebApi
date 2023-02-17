using AutoMapper;
using BookStoreWebApi.DBOperations;
using BookStoreWebApi.Entities;

namespace BookStoreWebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator
    {
            public CreateAuthorCommandValidator()
        {
            RuleFor(x=>x.Model.Name).NotEmpty().MinimumLength(3);
        }
    }
}
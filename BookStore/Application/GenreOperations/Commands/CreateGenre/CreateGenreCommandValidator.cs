using AutoMapper;
using BookStoreWebApi.DBOperations;
using BookStoreWebApi.Entities;

namespace BookStoreWebApi.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidator
    {
            public CreateGenreCommandValidator()
        {
            RuleFor(x=>x.Model.Name).NotEmpty().MinimumLength(3);
        }
    }
}
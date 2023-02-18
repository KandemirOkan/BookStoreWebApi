using AutoMapper;
using BookStoreWebApi.DBOperations;
using BookStoreWebApi.Entities;
using FluentValidation;

namespace BookStoreWebApi.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
            public CreateGenreCommandValidator()
        {
            RuleFor(x=>x.Model.Name).NotEmpty().MinimumLength(3);
        }
    }
}
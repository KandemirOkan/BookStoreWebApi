using AutoMapper;
using BookStoreWebApi.Application.BookOperations.Commands.CreateBook;
using BookStoreWebApi.Application.BookOperations.Commands.DeleteBook;
using BookStoreWebApi.Application.BookOperations.Commands.UpdateBook;
using BookStoreWebApi.Application.BookOperations.Queries.GetBooks;
using BookStoreWebApi.DBOperations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApi.Controllers.GenreController;

[ApiController]
[Route("[controller]")]
public class GenreController : ControllerBase
{
    private readonly BookStoreDbContext context;
    private readonly IMapper _mapper;

    public GenreController(BookStoreDbContext _context,IMapper mapper)
    {
        context = _context;
        _mapper = mapper;
    }

}
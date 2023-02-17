using AutoMapper;
using BookStoreWebApi.Application.BookOperations.Commands.CreateBook;
using BookStoreWebApi.Application.BookOperations.Commands.DeleteBook;
using BookStoreWebApi.Application.BookOperations.Commands.UpdateBook;
using BookStoreWebApi.Application.BookOperations.Queries.GetBooks;
using BookStoreWebApi.DBOperations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApi.Controllers.AuthorController;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    private readonly BookStoreDbContext context;
    private readonly IMapper _mapper;

    public AuthorController(BookStoreDbContext _context,IMapper mapper)
    {
        context = _context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAuthors()
    {
       GetAuthorsQuery query = new GetAuthorsQuery(context,_mapper);
       var result = query.Handle();
       return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetAuthorsById(int id)
    {
        GetAuthorsById query = new GetAuthorsById(context,_mapper);
        AuthorsViewIdModel result;
        query.AuthorId = id;
        GetAuthorsByIdValidator validator = new GetAuthorsByIdValidator();
        validator.ValidateAndThrow(query);
        result = query.Handle();
        return Ok(result);
    }

    [HttpPost]
    public IActionResult AddAuthor([FromBody] CreateBookModel newAuthor)
    {
        CreateBookCommand command = new CreateBookCommand(context,_mapper);
        command.Model = newAuthor;
        CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id,[FromBody] UpdateAuthorModel updateAuthor)
    {
        UpdateAuthorCommand command = new UpdateBookCommand(context);

        command.AuthorId = id;
        command.Model = updatebook;
        UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle(); 
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAuthor(int id)
    {
        DeleteAuthorCommand command = new DeleteAuthorCommand(context);
        command.BookId=id;
        DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }
}
using AutoMapper;
using BookStoreWebApi.Application.AuthorOperations.Commands.CreateAuthor;
using BookStoreWebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using BookStoreWebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using BookStoreWebApi.Application.AuthorOperations.Quearies;
using BookStoreWebApi.DBOperations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApi.Controllers.AuthorController;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IBookStoreDbContext context;
    private readonly IMapper _mapper;

    public AuthorController(IBookStoreDbContext _context,IMapper mapper)
    {
        context = _context;
        _mapper = mapper;
    }

    [HttpGet("[action]")]
    public IActionResult GetAuthors()
    {
       GetAuthorQuery query = new(context,_mapper);
       var result = query.Handle();
       return Ok(result);
    }

    [HttpGet("[action]/{id}")]
    public IActionResult GetAuthorsById(int id)
    {
        GetAuthorById query = new GetAuthorById(context,_mapper);
        AuthorViewIdModel result;
        query.AuthorId = id;
        GetAuthorByIdValidator validator = new GetAuthorByIdValidator();
        validator.ValidateAndThrow(query);
        result = query.Handle();
        return Ok(result);
    }

    [HttpPost("[action]")]
    public IActionResult AddAuthor([FromBody] CreateAuthorModel newAuthor)
    {
        CreateAuthorCommand command = new CreateAuthorCommand(context,_mapper);
        command.Model = newAuthor;
        CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }

    [HttpPut("[action]/{id}")]
    public IActionResult UpdateAuthor(int id,[FromBody] UpdateAuthorModel updateAuthor)
    {
        UpdateAuthorCommand command = new UpdateAuthorCommand(context,_mapper);

        command.AuthorId = id;
        command.Model = updateAuthor;
        UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle(); 
        return Ok();
    }

    [HttpDelete("[action]/{id}")]
    public IActionResult DeleteAuthor(int id)
    {
        DeleteAuthorCommand command = new DeleteAuthorCommand(context);
        command.AuthorId=id;
        DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }
}
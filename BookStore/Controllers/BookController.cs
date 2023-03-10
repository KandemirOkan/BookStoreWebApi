using AutoMapper;
using BookStoreWebApi.Application.BookOperations.Commands.CreateBook;
using BookStoreWebApi.Application.BookOperations.Commands.DeleteBook;
using BookStoreWebApi.Application.BookOperations.Commands.UpdateBook;
using BookStoreWebApi.Application.BookOperations.Queries.GetBooks;
using BookStoreWebApi.DBOperations;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApi.Controllers.BookController;
[Authorize]
[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookStoreDbContext context;
    private readonly IMapper _mapper;

    public BookController(IBookStoreDbContext _context,IMapper mapper)
    {
        context = _context;
        _mapper = mapper;
    }

    [HttpGet("[action]")]
    public IActionResult GetBooks()
    {
       GetBooksQuery query = new GetBooksQuery(context,_mapper);
       var result = query.Handle();
       return Ok(result);
    }

    [HttpGet("[action]/{id}")]
    public IActionResult GetBooksById(int id)
    {
        GetBooksById query = new GetBooksById(context,_mapper);
        BooksViewIdModel result;
        query.BookId = id;
        GetBooksByIdValidator validator = new GetBooksByIdValidator();
        validator.ValidateAndThrow(query);
        result = query.Handle();
        return Ok(result);
    }

    [HttpPost("[action]")]
    public IActionResult AddBook([FromBody] CreateBookModel newBook)
    {
        CreateBookCommand command = new CreateBookCommand(context,_mapper);
        command.Model = newBook;
        CreateBookCommandValidator validator = new CreateBookCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }

    [HttpPut("[action]/{id}")]
    public IActionResult UpdateBook(int id,[FromBody] UpdateBookModel updatebook)
    {
        UpdateBookCommand command = new UpdateBookCommand(context);

        command.BookId = id;
        command.Model = updatebook;
        UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle(); 
        return Ok();
    }

    [HttpDelete("[action]/{id}")]
    public IActionResult DeleteBook(int id)
    {
        DeleteBookCommand command = new DeleteBookCommand(context);
        command.BookId=id;
        DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }
}
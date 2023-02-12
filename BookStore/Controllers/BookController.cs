using AutoMapper;
using BookStoreWebApi.BookOperations.Commands.CreateBook;
using BookStoreWebApi.BookOperations.Commands.DeleteBook;
using BookStoreWebApi.BookOperations.Commands.UpdateBook;
using BookStoreWebApi.BookOperations.Queries.GetBooks;
using BookStoreWebApi.DBOperations;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly BookStoreDbContext context;
    private readonly IMapper _mapper;

    public BookController(BookStoreDbContext _context,IMapper mapper)
    {
        context = _context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetBooks()
    {
       GetBooksQuery query = new GetBooksQuery(context,_mapper);
       var result = query.Handle();
       return Ok(result);
    }
    [HttpGet("{id}")]
    public IActionResult GetBooksById(int id)
    {
        GetBooksById query = new GetBooksById(context,_mapper);
        var result = query.Handle(id);
        return Ok(result);
    }
    [HttpPost]
    public IActionResult AddBook([FromBody] CreateBookModel newBook)
    {
        CreateBookCommand command = new CreateBookCommand(context,_mapper);
        try
        {
        command.Model = newBook;
        command.Handle();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id,[FromBody] UpdateBookModel updatebook)
    {
        UpdateBookCommand command = new UpdateBookCommand(context);
        try
        {
            command.BookId = id;
            command.Model = updatebook;
            command.Handle(id); 
        }
        catch (Exception ex)
        {            
            return BadRequest(ex.Message);
        }
        return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        DeleteBookCommand command = new DeleteBookCommand(context);
        try
        {
            command.Handle(id);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
            return Ok();
    }
}
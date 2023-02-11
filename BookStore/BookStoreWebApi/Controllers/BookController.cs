using BookStoreWebApi.BookOperations.Commands.CreateBook;
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

    public BookController(BookStoreDbContext _context)
    {
        context = _context;
    }

    [HttpGet]
    public IActionResult GetBooks()
    {
       GetBooksQuery query = new GetBooksQuery(context);
       var result = query.Handle();
       return Ok(result);
    }
    [HttpGet("{id}")]
    public IActionResult GetBooksById(int id)
    {
        GetBooksById query = new GetBooksById(context);
        var result = query.Handle(id);
        return Ok(result);
    }
    [HttpPost]
    public IActionResult AddBook([FromBody] CreateBookModel newBook)
    {
        CreateBookCommand command = new CreateBookCommand(context);
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
        var book = context.Books.SingleOrDefault(x=>x.Id==id);
        if(book is null)
            return BadRequest();
        context.Books.Remove(book);
        context.SaveChanges();
        return Ok();
    }
}
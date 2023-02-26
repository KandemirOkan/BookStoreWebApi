using AutoMapper;
using BookStoreWebApi.Application.BookOperations.Commands.UpdateGenre;
using BookStoreWebApi.Application.GenreOperations.Commands.CreateGenre;
using BookStoreWebApi.Application.GenreOperations.Commands.DeleteGenre;
using BookStoreWebApi.Application.GenreOperations.Quearies;
using BookStoreWebApi.DBOperations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApi.Controllers.GenreController;

[ApiController]
[Route("[controller]")]
public class GenreController : ControllerBase
{
    private readonly IBookStoreDbContext context;
    private readonly IMapper _mapper;

    public GenreController(IBookStoreDbContext _context,IMapper mapper)
    {
        context = _context;
        _mapper = mapper;
    }

    [HttpGet("[action]")]
    public IActionResult GetGenres()
    {
       GetGenreQuery query = new GetGenreQuery(context,_mapper);
       var result = query.Handle();
       return Ok(result);
    }

    [HttpGet("[action]/{id}")]
    public IActionResult GetGenresById(int id)
    {
        GetGenreById query = new GetGenreById(context,_mapper);
        GenreViewIdModel result;
        query.GenreId = id;
        GetGenreByIdValidator validator = new GetGenreByIdValidator();
        validator.ValidateAndThrow(query);
        result = query.Handle();
        return Ok(result);
    }

    [HttpPost("[action]")]
    public IActionResult AddGenre([FromBody] CreateGenreModel newGenre)
    {
        CreateGenreCommand command = new CreateGenreCommand(context,_mapper);
        command.Model = newGenre;
        CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }

    [HttpPut("[action]/{id}")]
    public IActionResult UpdateGenre(int id,[FromBody] UpdateGenreModel updateGenre)
    {
        UpdateGenreCommand command = new UpdateGenreCommand(context);

        command.GenreId = id;
        command.Model = updateGenre;
        UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle(); 
        return Ok();
    }

    [HttpDelete("[action]/{id}")]
    public IActionResult DeleteGenre(int id)
    {
        DeleteGenreCommand command = new DeleteGenreCommand(context);
        command.GenreId=id;
        DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }
}
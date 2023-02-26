using AutoMapper;
using BookStoreWebApi.Application.UserOperations.Commands.CreateToken;
using BookStoreWebApi.Application.UserOperations.Commands.CreateUser;
using BookStoreWebApi.Application.UserOperations.Commands.RefreshToken;
using BookStoreWebApi.Application.UserOperations.Quaries;
using BookStoreWebApi.DBOperations;
using BookStoreWebApi.TokenOperations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static BookStoreWebApi.Application.UserOperations.Commands.CreateUser.CreateUserCommand;

namespace BookStoreWebApi.Controllers.UserController;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IBookStoreDbContext _context;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public UserController(IBookStoreDbContext context,IConfiguration configuration, IMapper mapper)
    {
        _context = context;
        _configuration = configuration;
        _mapper = mapper;
    }
    [HttpGet("[action]")]
    public IActionResult GetAllUsers()
    {
        GetUserQuery query = new GetUserQuery(_context, _mapper);
        var result = query.Handle();
        return Ok(result);
    }

    [HttpPost("[action]")]
    public IActionResult CreateUser([FromBody] CreateUserModel newUser)
    {
        CreateUserCommand command = new(_context,_mapper);
        command.Model = newUser;
        command.Handle();
        return Ok();
    }
    [HttpPost("[action]")]
    public ActionResult<Token> CreateToken([FromBody] CreateTokenModel newToken)
    {
        CreateTokenCommand command = new(_context, _mapper, _configuration);
        command.Model = newToken;
        var token = command.Handle();
        return token;
    }
    [HttpGet("[action]")]
    public ActionResult<Token> RefreshToken([FromQuery] string token)
    {
        RefreshTokenCommand command = new(_context, _configuration);
        command.RefreshToken = token;
        var refreshedToken = command.Handle();
        return refreshedToken;
    }
}

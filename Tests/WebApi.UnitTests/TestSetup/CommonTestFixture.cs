using AutoMapper;
using BookStoreWebApi.Common;
using BookStoreWebApi.DBOperations;
using Microsoft.EntityFrameworkCore;
using WebApi.UnitTests.TestsSetup;

namespace TestSetup
{
    public class CommonTestFixture
    {
        public BookStoreDbContext DbContext { get; set; }
        public IMapper Mapper { get; set; }

    public CommonTestFixture()
    {
        var options = new DbContextOptionsBuilder<BookStoreDbContext>().UseInMemoryDatabase("BookStoreTestDb").Options;
        DbContext = new(options);
        DbContext.Database.EnsureCreated();
        DbContext.AddBooks();
        DbContext.AddAuthors();
        DbContext.AddGenres();
        DbContext.SaveChanges();

        Mapper = new MapperConfiguration(config => { config.AddProfile<MappingProfile>();}).CreateMapper();
    }
    }
}
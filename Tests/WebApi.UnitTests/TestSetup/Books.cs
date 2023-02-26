using BookStoreWebApi.DBOperations;
using BookStoreWebApi.Entities;

namespace WebApi.UnitTests.TestsSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext dbContext)
        {
            dbContext.AddRange(
               new Book{
                    Title="Sapiens",
                    GenreId=1,
                    AuthorId = 1,
                    PageCount = 255
            },
                new Book{
                    Title="1984",
                    GenreId=2,
                    AuthorId = 2,
                    PageCount = 300
            },
                new Book{
                    Title="Fahrenheit 451",
                    GenreId=2,
                    AuthorId = 3,
                    PageCount = 350
                }
            );
        }
    }
}
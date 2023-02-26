using BookStoreWebApi.DBOperations;
using BookStoreWebApi.Entities;

namespace WebApi.UnitTests.TestsSetup;

public static class Genres
{
    public static void AddGenres(this BookStoreDbContext context)
    {
        context.Genres.AddRange(
                new Genre{
                    Name="Science Ficton"
                },
                new Genre{
                    Name="Noval"
                },
                new Genre{
                    Name="History"
                }                    
            );
    }
}
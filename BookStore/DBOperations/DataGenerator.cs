using BookStoreWebApi.Entities;
using BookStoreWebApi.DBOperations;
using Microsoft.EntityFrameworkCore;

public class DataGenerator
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new BookStoreDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
        {
            // Look for any book.
            if (context.Books.Any())
            {
                return;   // Data was already seeded
            }
            
            context.Genres.AddRange{
                new Genre{
                    Name="Science Ficton"
                },
                new Genre{
                    Name="Noval"
                },
                new Genre{
                    Name="History"
                }                    
            };

            context.Books.AddRange(
               new Book{
                Title="Sapiens",
                GenreId=1,
                PageCount = 255,
                Author="Yuval Noah Hariri",
            },
                new Book{
                    Title="1984",
                    GenreId=2,
                    PageCount = 300,
                    Author="George Orwell",
            },
                new Book{
                    Title="Fahrenheit 451",
                    GenreId=2,
                    PageCount = 350,
                    Author="Ray Bradbury",
                }
            );
            //Database'e git değiştir komutunu girmek lazım, o da bu satır.
            context.SaveChanges();
        }
    }
}
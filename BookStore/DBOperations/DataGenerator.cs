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

            context.Books.AddRange(
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
            
            context.Authors.AddRange(
                new Author{
                    FirstName="Yuval Noah",
                    BirthDate = new DateTime(1976,02,24),
                    LastName="Hariri",                                  
                },
                new Author{
                    FirstName="George",
                    LastName="Orwell",
                    BirthDate = new DateTime(1903,06,25)
                },
                new Author{
                    FirstName="Ray",
                    LastName="Bradbury",
                    BirthDate = new DateTime(1920,08,22)
                }                  
            );
            //Database'e git değiştir komutunu girmek lazım, o da bu satır.
            context.SaveChanges();
        }
    }
}
using BookStoreWebApi.DBOperations;
using BookStoreWebApi.Entities;

namespace WebApi.UnitTests.TestsSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext dbContext)
        {
            dbContext.AddRange(
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
        }
    }
}
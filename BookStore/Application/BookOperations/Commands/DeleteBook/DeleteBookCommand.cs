
using BookStoreWebApi.DBOperations;

namespace BookStoreWebApi.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly IBookStoreDbContext _dbContext;
        public int BookId { get; set; }

        public DeleteBookCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var book = _dbContext.Books.Where(x=>x.Id==BookId).SingleOrDefault();
            if (book is null)
            {
                throw new InvalidOperationException("Geçersiz bir ID numarası girdiniz.");
            }
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }
}
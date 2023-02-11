
using BookStoreWebApi.DBOperations;

namespace BookStoreWebApi.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _dbContext;

        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle(int id)
        {
            var book = _dbContext.Books.Where(x=>x.Id==id).SingleOrDefault();
            if (book is null)
            {
                throw new InvalidOperationException("Geçersiz bir ID numarası girdiniz.");
            }
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }
}
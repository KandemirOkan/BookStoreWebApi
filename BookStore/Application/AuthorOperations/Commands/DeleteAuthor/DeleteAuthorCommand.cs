using AutoMapper;
using BookStoreWebApi.DBOperations;
using BookStoreWebApi.Entities;

namespace BookStoreWebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly IBookStoreDbContext _dbContext;
        public int AuthorId { get; set; }

        public DeleteAuthorCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var author = _dbContext.Authors.Where(x=>x.Id==AuthorId).SingleOrDefault();
            if (author is null)
            {
                throw new InvalidOperationException("Geçersiz bir ID numarası girdiniz.");
            }
            _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();
        }
    }
}
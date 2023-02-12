using AutoMapper;
using BookStoreWebApi.BookOperations.Commands.CreateBook;
using BookStoreWebApi.BookOperations.Commands.UpdateBook;
using BookStoreWebApi.BookOperations.Queries.GetBooks;

namespace BookStoreWebApi.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel,Book>();
            CreateMap<Book,BooksViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book,BooksViewIdModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
            CreateMap<UpdateBookModel,Book>();
        }
    }
}
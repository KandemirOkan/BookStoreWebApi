using AutoMapper;
using BookStoreWebApi.Application.BookOperations.Commands.CreateBook;
using BookStoreWebApi.Application.BookOperations.Commands.UpdateBook;
using BookStoreWebApi.Application.BookOperations.Queries.GetBooks;
using BookStoreWebApi.Application.GenreOperations.Quearies;
using BookStoreWebApi.Entities;

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
            CreateMap<GenreViewModel,Genre>();
        }
    }
}
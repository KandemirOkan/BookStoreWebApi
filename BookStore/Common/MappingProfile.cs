using AutoMapper;
using BookStoreWebApi.Application.AuthorOperations.Commands.CreateAuthor;
using BookStoreWebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using BookStoreWebApi.Application.AuthorOperations.Quearies;
using BookStoreWebApi.Application.BookOperations.Commands.CreateBook;
using BookStoreWebApi.Application.BookOperations.Commands.UpdateBook;
using BookStoreWebApi.Application.BookOperations.Queries.GetBooks;
using BookStoreWebApi.Application.GenreOperations.Commands.CreateGenre;
using BookStoreWebApi.Application.GenreOperations.Quearies;
using BookStoreWebApi.Application.UserOperations.Quaries;
using BookStoreWebApi.Entities;
using static BookStoreWebApi.Application.UserOperations.Commands.CreateUser.CreateUserCommand;

namespace BookStoreWebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Book
            CreateMap<CreateBookModel, Book>();// (source,target)

            CreateMap<Book, BooksViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => (src.Genre.Name).ToString()))
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => (src.Author.FirstName).ToString()));

            CreateMap<Book, BooksViewIdModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => (src.Genre.Name).ToString()))
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => (src.Author.FirstName + " " + src.Author.LastName).ToString()));

            CreateMap<CreateBookModel, Book>();
            CreateMap<UpdateBookModel, Book>();

            CreateMap<GenreViewModel, Genre>().ReverseMap();
            CreateMap<UpdateAuthorModel, Author>();

            CreateMap<Genre, GenreViewIdModel>().ReverseMap();


            //ReverseMap'de �ift tarafl� e�le�tirme �al���r. A�a��daki koda gerek kalmazm��. (S�per �zellik). 
            //CreateMap<GenreViewIdModel, Genre>();
            CreateMap<CreateGenreModel, Genre>();

            CreateMap<Author, AuthorViewModel>();
            CreateMap<Author, AuthorViewIdModel>().ReverseMap();

            CreateMap<CreateAuthorModel, Author>();

            CreateMap<CreateUserModel, User>();

            CreateMap<UserViewModel,User>().ReverseMap();

        }
    }
}
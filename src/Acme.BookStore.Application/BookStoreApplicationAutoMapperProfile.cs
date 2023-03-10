using Acme.BookStore.Books;
using AutoMapper;

namespace Acme.BookStore;

public class BookStoreApplicationAutoMapperProfile : Profile
{
    public BookStoreApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>().ReverseMap();
       // CreateMap<BookDto, Book>();
        CreateMap<CreateUpdateBookDto, Book>();
    }
}


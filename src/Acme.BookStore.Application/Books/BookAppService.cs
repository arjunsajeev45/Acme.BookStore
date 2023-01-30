using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Books;

public class BookAppService :
    CrudAppService<
        Book, //The Book entity
        BookDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateBookDto>, //Used to create/update a book
    IBookAppService //implement the IBookAppService
{

    IRepository<Book, Guid> repository;
    public BookAppService(IRepository<Book, Guid> repository)
        : base(repository)
    {
        this.repository = repository;
    }

    public override Task<BookDto> CreateAsync(CreateUpdateBookDto input)
    {
        input.Name = input.Name + "Speehive";

        return base.CreateAsync(input);
    }



    public void SomeLogic(BookDto input, string s)
    {
        var book1=ObjectMapper.Map<BookDto,Book>(input);

        Book book = new Book();
        book.Name = input.Name; 
        book.Type= input.Type;


        repository.InsertAsync(book1);
    }

    [HttpGet]
    public void Hello()
    {

    }
}


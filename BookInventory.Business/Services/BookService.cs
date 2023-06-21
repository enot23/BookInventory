using AutoMapper;
using BookInventory.Business.Interfaces;
using BookInventory.Business.Models;
using BookInventory.Data.Entities;
using BookInventory.Data.Interfaces;

namespace BookInventory.Business.Services;

public class BookService : BaseService<Book, BookDto>, IBookService
{
    public BookService(IBaseRepository<Book> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
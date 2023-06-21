using BookInventory.Business.Models;
using BookInventory.Data.Entities;

namespace BookInventory.Business.Interfaces;

public interface IBookService : IBaseService<Book, BookDto>
{
    // Additional methods specific to the Book entity can be defined here if needed
}
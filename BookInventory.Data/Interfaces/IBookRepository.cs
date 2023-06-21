using BookInventory.Data.Entities;

namespace BookInventory.Data.Interfaces;

public interface IBookRepository : IBaseRepository<Book>
{
    // Additional methods specific to the Category entity can be defined here if needed
}
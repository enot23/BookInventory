using BookInventory.Data.Entities;
using BookInventory.Data.Interfaces;

namespace BookInventory.Data.Repositories;

public class BookRepository : BaseRepository<Book>, IBookRepository
{
    public BookRepository(AppContext context) : base(context)
    {
    }
    
}
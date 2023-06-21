using BookInventory.Data.Entities;
using BookInventory.Data.Interfaces;

namespace BookInventory.Data.Repositories;

public class CategoryRepository: BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppContext context) : base(context)
    {
    }
}
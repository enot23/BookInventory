using BookInventory.Business.Models;
using BookInventory.Data.Entities;

namespace BookInventory.Business.Interfaces;

public interface ICategoryService : IBaseService<Category, CategoryDto>
{
    // Additional methods specific to the Category entity can be defined here if needed
}
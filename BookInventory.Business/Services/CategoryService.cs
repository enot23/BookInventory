using AutoMapper;
using BookInventory.Business.Interfaces;
using BookInventory.Business.Models;
using BookInventory.Data.Entities;
using BookInventory.Data.Interfaces;

namespace BookInventory.Business.Services;

public class CategoryService: BaseService<Category, CategoryDto>, ICategoryService
{
    public CategoryService(IBaseRepository<Category> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
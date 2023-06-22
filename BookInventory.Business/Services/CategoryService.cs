using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookInventory.Business.Interfaces;
using BookInventory.Business.Interfaces.Validators;
using BookInventory.Business.Models;
using BookInventory.Common.Exceptions;
using BookInventory.Data.Entities;
using BookInventory.Data.Interfaces;

namespace BookInventory.Business.Services;

public class CategoryService: BaseService<Category, CategoryDto>, ICategoryService
{
    private readonly ICategoryRepository _repository;
    private readonly ICategoryValidator _validator;
    
    public CategoryService(ICategoryRepository repository, ICategoryValidator validator, IMapper mapper) : base(repository, mapper)
    {
        _repository = repository;
        _validator = validator;
    }
    
    public override async Task<CategoryDto> AddAsync(CategoryDto categoryDto)
    {
        if (!await _validator.IsCategoryNameUnique(categoryDto.Name))
            throw new AlreadyExistException("Category name must be unique");

        return base.AddAsync(categoryDto).Result;
    }

    public override async Task UpdateAsync(CategoryDto categoryDto)
    {
        var existentCategories = await _repository.FindAsync(x => x.Name == categoryDto.Name);
        
        if (existentCategories.Any())
            throw new AlreadyExistException("Category name must be unique");
        
        await base.UpdateAsync(categoryDto);
    }
}
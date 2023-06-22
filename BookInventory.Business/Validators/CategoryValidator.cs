using System.Threading.Tasks;
using BookInventory.Business.Interfaces.Validators;
using BookInventory.Data.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace BookInventory.Business.Validators;

public class CategoryValidator : ICategoryValidator
{
    private readonly ICategoryRepository _repository;
    
    public CategoryValidator(ICategoryRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<bool> IsCategoryNameUnique(string categoryName)
    {
        var existentCategories = await _repository.FindAsync(x => x.Name == categoryName);
        
        return existentCategories.IsNullOrEmpty();
    }
}
using System.Threading.Tasks;

namespace BookInventory.Business.Interfaces.Validators;

public interface ICategoryValidator
{
    public Task<bool> IsCategoryNameUnique(string categoryName);
}
using System.Linq.Expressions;
using BookInventory.Data.Entities;

namespace BookInventory.Data.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    public Task<TEntity> GetByIdAsync(int id);
    
    public Task<IEnumerable<TEntity>> GetAllAsync();
    
    public Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
    
    public Task<TEntity> AddAsync(TEntity entity);
    
    public Task UpdateAsync(TEntity entity);
    
    public Task DeleteAsync(TEntity entity);

}
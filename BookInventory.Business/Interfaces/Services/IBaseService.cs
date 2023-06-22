using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BookInventory.Business.Models;
using BookInventory.Data.Entities;

namespace BookInventory.Business.Interfaces;

public interface IBaseService<TEntity, TDto, TCreateDeleteModel> where TEntity : BaseEntity where TDto : BaseDto
{
    Task<TDto> GetByIdAsync(int id);
    
    Task<IEnumerable<TDto>> GetAllAsync();
    
    Task<IEnumerable<TDto>> FindAsync(Expression<Func<TEntity, bool>> predicate);
    
    Task<TDto> AddAsync(TCreateDeleteModel dto);
    
    Task UpdateAsync(TCreateDeleteModel dto);
    
    Task DeleteAsync(int id);
}
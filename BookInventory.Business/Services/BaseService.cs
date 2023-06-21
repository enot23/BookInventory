using System.Linq.Expressions;
using AutoMapper;
using BookInventory.Business.Interfaces;
using BookInventory.Business.Models;
using BookInventory.Data.Entities;
using BookInventory.Data.Interfaces;

namespace BookInventory.Business.Services;

public class BaseService<TEntity, TDto> : IBaseService<TEntity, TDto> where TEntity : BaseEntity where TDto : BaseDto
{
    private readonly IBaseRepository<TEntity> _repository;
    private readonly IMapper _mapper;

    public BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TDto> GetByIdAsync(int id)
    {
        TEntity entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<TDto>(entity);
    }

    public async Task<IEnumerable<TDto>> GetAllAsync()
    {
        IEnumerable<TEntity> entities = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<TDto>>(entities);
    }

    public async Task<IEnumerable<TDto>> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        IEnumerable<TEntity> entities = await _repository.FindAsync(predicate);
        return _mapper.Map<IEnumerable<TDto>>(entities);
    }

    public async Task<TDto> AddAsync(TDto dto)
    {
        TEntity entity = _mapper.Map<TEntity>(dto);
        entity = await _repository.AddAsync(entity);
        return _mapper.Map<TDto>(entity);
    }

    public async Task UpdateAsync(TDto dto)
    {
        TEntity entity = _mapper.Map<TEntity>(dto);
        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        TEntity entity = await _repository.GetByIdAsync(id);
        await _repository.DeleteAsync(entity);
    }
}
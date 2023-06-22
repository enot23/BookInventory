using System.Threading.Tasks;
using AutoMapper;
using BookInventory.Business.Interfaces;
using BookInventory.Business.Models;
using BookInventory.Data.Entities;
using BookInventory.Data.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace BookInventory.Business.Services;

public class BookService : BaseService<Book, BookDto>, IBookService
{
    private readonly ICategoryRepository _categoryRepository;
    
    public BookService(IBookRepository bookRepository, ICategoryRepository categoryRepository, IMapper mapper) : base(bookRepository, mapper)
    {
        _categoryRepository = categoryRepository;
    }
    
    public override async Task<BookDto> AddAsync(BookDto bookDto)
    {
        if (bookDto.CategoryName.IsNullOrEmpty()) 
            return await base.AddAsync(bookDto);
        
        var existentCategories = await _categoryRepository.FindAsync(x => x.Name == bookDto.CategoryName);

        if (existentCategories.IsNullOrEmpty())
        {
            var newCategory = await _categoryRepository.AddAsync(new Category { Name = bookDto.CategoryName });
            bookDto.CategoryId = newCategory.Id;
        }
        
        return await base.AddAsync(bookDto);
    }

    public override async Task UpdateAsync(BookDto bookDto)
    {
        var existentCategories = await _categoryRepository.FindAsync(x => x.Name == bookDto.CategoryName);

        if (existentCategories.IsNullOrEmpty())
        {
            var newCategory = await _categoryRepository.AddAsync(new Category { Name = bookDto.CategoryName });
            bookDto.CategoryId = newCategory.Id;
        }
        
        await base.UpdateAsync(bookDto);
    }
}
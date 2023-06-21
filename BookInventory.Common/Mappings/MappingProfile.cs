using AutoMapper;
using BookInventory.Business.Models;
using BookInventory.Data.Entities;

namespace BookInventory.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookDto>()
            .ForMember(x => x.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

        CreateMap<BookDto, Book>();

        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
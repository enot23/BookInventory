using AutoMapper;
using BookInventory.Business.Models;
using BookInventory.Data.Entities;

namespace BookInventory.Business.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BookCreateUpdateModel, Book>()
            .ForMember(dest => dest.CategoryId, opt =>
            {
                opt.Condition(src => src.CategoryId == 0);
                opt.MapFrom(src => 1);
            });
        CreateMap<BookDto, Book>();
        CreateMap<Book, BookDto>()
            .ForMember(x => x.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

        CreateMap<CategoryCreateUpdateModel, Category>();
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
using AutoMapper;
using lVirtual.ProductApi.Models;

namespace lVirtual.ProductApi.DTOs.Mappings;
public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<ProductDTO, Product>();
    CreateMap<Product, ProductDTO>().ForMember(x => x.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
    CreateMap<Category, CategoryDTO>().ReverseMap();
  }
}
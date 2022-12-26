using AutoMapper;
using lVirtual.ProductApi.Models;

namespace lVirtual.ProductApi.DTOs.Mappings;
public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<Product, ProductDTO>().ReverseMap();
    CreateMap<Category, CategoryDTO>().ReverseMap();
  }
}
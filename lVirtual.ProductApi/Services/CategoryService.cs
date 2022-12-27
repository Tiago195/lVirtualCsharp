using AutoMapper;
using lVirtual.ProductApi.DTOs;
using lVirtual.ProductApi.Models;
using lVirtual.ProductApi.Repositories;

namespace lVirtual.ProductApi.Services;

public class CategoryService : ICategoryService
{
  private readonly ICategoryRepository _categoryRepository;
  private readonly IMapper _mapper;

  public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
  {
    _categoryRepository = categoryRepository;
    _mapper = mapper;
  }

  public async Task<IEnumerable<CategoryDTO>> GetAll()
  {
    var categoriesEntity = await _categoryRepository.GetAll();
    return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
  }

  public async Task<IEnumerable<CategoryDTO>> GetCategoriesProducts()
  {
    var categoriesEntity = await _categoryRepository.GetCategoriesProducts();
    return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
  }

  public async Task<CategoryDTO> GetById(int id)
  {
    var categoryEntity = await _categoryRepository.GetById(id);
    return _mapper.Map<CategoryDTO>(categoryEntity);
  }

  public async Task Create(CategoryDTO categoryDto)
  {
    var categoryEntity = _mapper.Map<Category>(categoryDto);
    await _categoryRepository.Create(categoryEntity);
    categoryDto.CategoryId = categoryEntity.CategoryId;
  }

  public async Task Update(CategoryDTO categoryDto)
  {
    var categoryEntity = _mapper.Map<Category>(categoryDto);
    await _categoryRepository.Update(categoryEntity);
  }

  public async Task Delete(int id)
  {
    var categoryEntity = await _categoryRepository.GetById(id);
    await _categoryRepository.Delete(categoryEntity.CategoryId);
  }

}
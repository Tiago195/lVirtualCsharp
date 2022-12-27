using lVirtual.ProductApi.DTOs;

namespace lVirtual.ProductApi.Services;

public interface ICategoryService
{
  Task<IEnumerable<CategoryDTO>> GetAll();
  Task<IEnumerable<CategoryDTO>> GetCategoriesProducts();
  Task<CategoryDTO> GetById(int id);
  Task Create(CategoryDTO categoryDto);
  Task Update(CategoryDTO categoryDto);
  Task Delete(int id);
}

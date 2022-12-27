using lVirtual.ProductApi.DTOs;

namespace lVirtual.ProductApi.Services;

public interface IProductService
{
  Task<IEnumerable<ProductDTO>> GetAll();
  Task<ProductDTO> GetById(int id);
  Task Create(ProductDTO productDto);
  Task Update(ProductDTO productDto);
  Task Delete(int id);
}
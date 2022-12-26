using lVirtual.ProductApi.Models;

namespace lVirtual.ProductApi.Repositories;

public interface IProductRepository
{
  Task<IEnumerable<Product>> GetAll();
  Task<Product> GetById(int id);
  Task<Product> Create(Product product);
  Task<Product> Update(Product product);
  Task<Product> Delete(int id);
}

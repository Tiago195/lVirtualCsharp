using lVirtual.Web.Models;

namespace lVirtual.Web.Services.Contracts;

public interface IProductService
{
  Task<IEnumerable<ProductViewModel>> GetAllProducts();
  Task<ProductViewModel> GetProduct(int id);
  Task<ProductViewModel> CreateProduct(ProductViewModel productView);
  Task<ProductViewModel> UpdateProduct(ProductViewModel productView);
  Task<bool> DeleteProduct(int id);
}
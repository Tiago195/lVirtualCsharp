using lVirtual.Web.Models;
using lVirtual.Web.Services.Contracts;
using System.Text.Json;

namespace lVirtual.Web.Services;

public class ProductService : IProductService
{
  private readonly IHttpClientFactory _clientFactory;
  private const string apiEndpoint = "/product/";
  private readonly JsonSerializerOptions _options;
  private ProductViewModel ProductView;
  private IEnumerable<ProductViewModel> ProductsView;

  public ProductService(IHttpClientFactory clientFactory)
  {
    _clientFactory = clientFactory;
    _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
  }

  public Task<IEnumerable<ProductViewModel>> GetAllProducts()
  {
    throw new NotImplementedException();
  }
  public Task<ProductViewModel> GetProduct(int id)
  {
    throw new NotImplementedException();
  }
  public Task<ProductViewModel> CreateProduct(ProductViewModel productView)
  {
    throw new NotImplementedException();
  }
  public Task<ProductViewModel> UpdateProduct(ProductViewModel productView)
  {
    throw new NotImplementedException();
  }
  public Task<bool> DeleteProduct(int id)
  {
    throw new NotImplementedException();
  }
}
using AutoMapper;
using lVirtual.ProductApi.DTOs;
using lVirtual.ProductApi.Models;
using lVirtual.ProductApi.Repositories;

namespace lVirtual.ProductApi.Services;

public class ProductService : IProductService
{
  private readonly IProductRepository _productRepository;
  private readonly IMapper _mapper;

  public ProductService(IProductRepository productRepository, IMapper mapper)
  {
    _productRepository = productRepository;
    _mapper = mapper;
  }

  public async Task<IEnumerable<ProductDTO>> GetAll()
  {
    var productEntity = await _productRepository.GetAll();
    return _mapper.Map<IEnumerable<ProductDTO>>(productEntity);
  }


  public async Task<ProductDTO> GetById(int id)
  {
    var productEntity = await _productRepository.GetById(id);
    return _mapper.Map<ProductDTO>(productEntity);
  }
  public async Task Create(ProductDTO productDto)
  {
    var productEntity = _mapper.Map<Product>(productDto);
    await _productRepository.Create(productEntity);
    productDto.Id = productEntity.Id;
  }

  public async Task Update(ProductDTO productDto)
  {
    var productEntity = _mapper.Map<Product>(productDto);
    await _productRepository.Update(productEntity);
  }
  public async Task Delete(int id)
  {
    var productEntity = await _productRepository.GetById(id);
    await _productRepository.Delete(productEntity.Id);
  }
}
using lVirtual.ProductApi.DTOs;
using lVirtual.ProductApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace lVirtual.ProductApi.Controllers;

[ApiController]
[Route("[controller]")]

public class ProductController : ControllerBase
{
  private readonly IProductService _product;

  public ProductController(IProductService product)
  {
    _product = product;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll()
  {
    var products = await _product.GetAll();

    return Ok(products);
  }

  [HttpGet("{id}", Name = "GetProduct")]
  // [Route("{id:int}", Name = "GetProduct")]
  public async Task<ActionResult<ProductDTO>> GetById(int id)
  {
    var product = await _product.GetById(id);

    if (product is null) return NotFound("Product not found.");

    return Ok(product);
  }

  [HttpPost]
  public async Task<ActionResult> Create([FromBody] ProductDTO productDto)
  {
    if (productDto is null) return BadRequest("Invalid Data.");

    await _product.Create(productDto);

    return new CreatedAtRouteResult("GetProduct", new { id = productDto.Id }, productDto);

  }

  [HttpPut]
  [Route("{id:int}")]
  public async Task<ActionResult<ProductDTO>> Update(int id, [FromBody] ProductDTO productDto)
  {
    if (productDto is null || id != productDto.Id) return BadRequest("Indalid Data.");


    await _product.Update(productDto);

    return Ok(productDto);
  }

  [HttpDelete]
  [Route("{id:int}")]
  public async Task<ActionResult> Delete(int id)
  {
    var product = await _product.GetById(id);

    if (product is null) return NotFound("Product not found.");

    await _product.Delete(id);

    return NoContent();
  }
}
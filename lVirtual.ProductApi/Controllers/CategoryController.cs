using lVirtual.ProductApi.DTOs;
using lVirtual.ProductApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace lVirtual.ProductApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
  private readonly ICategoryService _category;

  public CategoryController(ICategoryService category)
  {
    _category = category;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAll()
  {
    var categories = await _category.GetAll();

    return Ok(categories);
  }

  [HttpGet]
  [Route("products")]
  public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesProducts()
  {
    var categories = await _category.GetCategoriesProducts();

    return Ok(categories);
  }

  [HttpGet]
  [Route("{id:int}", Name = "GetCategory")]
  public async Task<ActionResult<CategoryDTO>> GetById(int id)
  {
    var category = await _category.GetById(id);

    if (category is null) return NotFound("Category not found.");

    return Ok(category);
  }

  [HttpPost]
  public async Task<ActionResult> Create([FromBody] CategoryDTO categoryDto)
  {
    if (categoryDto is null) return BadRequest("Invalid Data.");

    await _category.Create(categoryDto);

    return new CreatedAtRouteResult("GetCategory", new { id = categoryDto.CategoryId }, categoryDto);
    // return Created("GetCategory", category);
  }

  [HttpPut]
  [Route("{id:int}")]
  public async Task<ActionResult<CategoryDTO>> Update(int id, [FromBody] CategoryDTO categoryDto)
  {
    if (categoryDto is null || id != categoryDto.CategoryId) return BadRequest("Invalid Data.");

    // var categoryEntity = await _category.GetById(id);

    // if (categoryEntity is null) return NotFound("Category not found.");

    await _category.Update(categoryDto);

    return Ok(categoryDto);

  }

  [HttpDelete]
  [Route("{id:int}")]

  public async Task<ActionResult> Delete(int id)
  {

    var category = await _category.GetById(id);

    if (category is null) return NotFound("Category not found.");

    await _category.Delete(id);

    return NoContent();
  }
}
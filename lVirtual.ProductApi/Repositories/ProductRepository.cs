using lVirtual.ProductApi.Context;
using lVirtual.ProductApi.Models;
using Microsoft.EntityFrameworkCore;

namespace lVirtual.ProductApi.Repositories;

public class ProductRepository : IProductRepository
{
  private readonly AppDbContext _context;

  public ProductRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<Product>> GetAll()
  {
    return await _context.Products.Include(x => x.Category).ToListAsync();
  }
  public async Task<Product> GetById(int id)
  {
    return await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
  }
  public async Task<Product> Create(Product product)
  {
    _context.Products.Add(product);
    await _context.SaveChangesAsync();
    return product;
  }
  public async Task<Product> Update(Product product)
  {
    _context.Entry(product).State = EntityState.Modified;
    await _context.SaveChangesAsync();
    return product;
  }
  public async Task<Product> Delete(int id)
  {
    var product = await GetById(id);
    _context.Products.Remove(product);
    await _context.SaveChangesAsync();
    return product;
  }
}
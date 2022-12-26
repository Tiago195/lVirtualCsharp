using lVirtual.ProductApi.Models;
using Microsoft.EntityFrameworkCore;

namespace lVirtual.ProductApi.Context;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  public DbSet<Product> Products { get; set; }
  public DbSet<Category> Categories { get; set; }
}
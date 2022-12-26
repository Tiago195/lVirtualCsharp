using lVirtual.ProductApi.Models;
using Microsoft.EntityFrameworkCore;

namespace lVirtual.ProductApi.Context;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  public DbSet<Product> Products { get; set; }
  public DbSet<Category> Categories { get; set; }


  protected override void OnModelCreating(ModelBuilder mb)
  {
    // Product

    mb.Entity<Product>().HasKey(p => p.Id);
    mb.Entity<Product>().Property(p => p.Name).HasMaxLength(100).IsRequired();
    mb.Entity<Product>().Property(p => p.Description).HasMaxLength(255).IsRequired();
    mb.Entity<Product>().Property(p => p.ImageURL).HasMaxLength(255).IsRequired();
    mb.Entity<Product>().Property(p => p.Price).HasPrecision(12, 2);

    mb.Entity<Product>().HasData(
      new Product { Id = 1, Name = "Caderno", Price = 7.55M, Description = "Caderno Espiral", Stock = 10, ImageURL = "carderno1.jpg", CategoryId = 1 },
      new Product { Id = 2, Name = "Lápis", Price = 3.45M, Description = "Lápis Preto", Stock = 20, ImageURL = "lapis1.jpg", CategoryId = 1 },
      new Product { Id = 3, Name = "Clips", Price = 5.33M, Description = "Clipis para papel", Stock = 50, ImageURL = "clipis1.jpg", CategoryId = 2 }
    );

    // Category

    mb.Entity<Category>().HasKey(c => c.CategoryId);
    mb.Entity<Category>().Property(c => c.Name).HasMaxLength(100).IsRequired();
    mb.Entity<Category>().HasMany(c => c.Products).WithOne(p => p.Category).IsRequired().OnDelete(DeleteBehavior.Cascade);

    mb.Entity<Category>().HasData(
      new Category { CategoryId = 1, Name = "Material Escolar" },
      new Category { CategoryId = 2, Name = "Acessórios" }
    );
  }
}
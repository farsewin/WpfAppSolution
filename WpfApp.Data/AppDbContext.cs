using Microsoft.EntityFrameworkCore;
using WpfApp.Core.Models;

namespace WpfApp.Data;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    // Add a constructor that accepts DbContextOptions<AppDbContext>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Laptop", Price = 999.99m, StockCount = 10 },
            new Product { Id = 2, Name = "Smartphone", Price = 499.99m, StockCount = 20 },
            new Product { Id = 3, Name = "Tablet", Price = 299.99m, StockCount = 15 }
        );
    }
}

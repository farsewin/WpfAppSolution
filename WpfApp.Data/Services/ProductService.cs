using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WpfApp.Core.Models;
using WpfApp.Core.Services;

namespace WpfApp.Data.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _context.Products.AsNoTracking().ToList();
    }

    public IEnumerable<Product> SearchProducts(string searchTerm)
    {
        return _context.Products
            .Where(p => p.Name.Contains(searchTerm))
            .AsNoTracking()
            .ToList();
    }

    public void AddProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void UpdateProduct(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }

    public void DeleteProduct(int productId)
    {
        var product = _context.Products.Find(productId);
        if (product != null)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}

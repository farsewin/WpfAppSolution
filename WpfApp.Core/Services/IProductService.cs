using System.Collections.Generic;
using WpfApp.Core.Models;

namespace WpfApp.Core.Services;

public interface IProductService
{
    IEnumerable<Product> GetAllProducts();
    IEnumerable<Product> SearchProducts(string searchTerm);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(int productId);
}

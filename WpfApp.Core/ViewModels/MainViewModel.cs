using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using WpfApp.Core.Models;
using WpfApp.Core.Services;

namespace WpfApp.Core.ViewModels;

public class MainViewModel : BaseViewModel
{
    private readonly IProductService _productService;
    private Product _selectedProduct = new(); // Initialize to avoid null

    public MainViewModel() : this(new MockProductService()) // Corrected constructor chaining syntax
    {
    }

    public ObservableCollection<Product> Products { get; private set; }

    public Product SelectedProduct
    {
        get => _selectedProduct;
        set => SetProperty(ref _selectedProduct, value);
    }

    public MainViewModel(IProductService productService)
    {
        _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        Products = new ObservableCollection<Product>(); // Corrected initialization
        LoadProducts();
    }

    private void LoadProducts()
    {
        Products = new ObservableCollection<Product>(_productService.GetAllProducts()); // Corrected initialization
    }

    private RelayCommand _addProductCommand = null!;
    public RelayCommand AddProductCommand => _addProductCommand ??= new RelayCommand(AddProduct);

    private void AddProduct()
    {
        var newProduct = new Product { Name = "New Product", Price = 0, StockCount = 0 };
        _productService.AddProduct(newProduct);
        LoadProducts();
    }
}
public class MockProductService : IProductService
{
    public IEnumerable<Product> GetAllProducts() => new List<Product>();
    public IEnumerable<Product> SearchProducts(string searchTerm) => new List<Product>();
    public void AddProduct(Product product) { }
    public void UpdateProduct(Product product) { }
    public void DeleteProduct(int productId) { }
}

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;
using WpfApp.Core.Models;
using WpfApp.Core.Services;

namespace WpfApp.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IProductService _productService;
        private readonly INavigationService _navigationService;

        public ObservableCollection<Product> Products { get; private set; } = new ObservableCollection<Product>();

        private RelayCommand _addProductCommand = null!; // Initialize with null-forgiving operator to satisfy non-nullable requirement.  
        public RelayCommand AddProductCommand => _addProductCommand ??= new RelayCommand(AddProduct);

        public MainViewModel(IProductService productService, INavigationService navigationService)
        {
            _productService = productService;
            _navigationService = navigationService;
            LoadProducts();
        }

        private void LoadProducts()
        {
            Products = new ObservableCollection<Product>(_productService.GetAllProducts());
        }

        private void AddProduct()
        {
            _navigationService.NavigateTo("SettingsView");
        }
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

public class NavigationService : INavigationService
{
    private Window mainWindow;

    public NavigationService(Window mainWindow)
    {
        this.mainWindow = mainWindow;
    }

    public void GoBack()
    {
        throw new NotImplementedException();
    }

    public void NavigateTo(string viewName)
    {
        // Implement navigation logic here
    }
}

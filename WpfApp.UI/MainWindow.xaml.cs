using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WpfApp.Core.ViewModels;
using WpfApp.Data.Services;

namespace WpfApp.UI;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = App.Host.Services.GetRequiredService<MainViewModel>();
    }
}
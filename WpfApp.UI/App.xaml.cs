using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using WpfApp.Core.Services;
using WpfApp.Core.ViewModels;
using WpfApp.Data.Services;
using WpfApp.Data;

namespace WpfApp.UI;

public partial class App : Application
{
    public static IHost Host { get; private set; } = null!;

    public App()
    {
        InitializeComponent();

        Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlite("Data Source=app.db"));

                services.AddScoped<IProductService, ProductService>();
                services.AddSingleton<ILoggerService, LoggerService>();
                services.AddSingleton<INavigationService, NavigationService>(provider => new NavigationService(MainWindow));
                services.AddTransient<MainViewModel>();
            })
            .Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        using var scope = Host.Services.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<AppDbContext>();
            context.Database.EnsureCreated();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILoggerService>();
            logger.LogError($"Error initializing database: {ex.Message}");
            MessageBox.Show($"Error initializing database: {ex.Message}");
        }

        var mainWindow = new MainWindow
        {
            DataContext = Host.Services.GetRequiredService<MainViewModel>()
        };
        mainWindow.Show();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        Host.Dispose();
        base.OnExit(e);
    }
}

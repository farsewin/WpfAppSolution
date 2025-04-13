using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using WpfApp.Core.Services;
using WpfApp.Core.ViewModels;
using WpfApp.Data;
using WpfApp.Data.Services;

namespace WpfApp.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost Host { get; private set; } = null!;

        public App()
        {
            InitializeComponent();
            
            Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Register data services
                    services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlite("Data Source=app.db"));
                    
                    services.AddScoped<IProductService, ProductService>();
                    
                    // Register view models
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
                MessageBox.Show($"Error initializing database: {ex.Message}");
            }

            var mainWindow = new MainWindow
            {
                DataContext = Host.Services.GetRequiredService<MainViewModel>()
            };
            mainWindow.Show();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            if (Host is IAsyncDisposable disposable)
            {
                await disposable.DisposeAsync();
            }
            else
            {
                Host.Dispose();
            }
            base.OnExit(e);
        }
    }
}

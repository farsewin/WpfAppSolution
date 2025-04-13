using System.Windows;
using WpfApp.Core.Services;
using WpfApp.UI.Views;

namespace WpfApp.UI.Services
{
    public class NavigationService : INavigationService
    {
        private readonly Window _mainWindow;

        public NavigationService(Window mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public void NavigateTo(string viewName)
        {
            switch (viewName)
            {
                case "MainView":
                    _mainWindow.Content = new MainView();
                    break;
                case "SettingsView":
                    _mainWindow.Content = new SettingsView();
                    break;
                default:
                    throw new ArgumentException("Unknown view name", nameof(viewName));
            }
        }

        public void GoBack()
        {
            // Implement navigation back logic
        }
    }
}

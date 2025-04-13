using Microsoft.Extensions.DependencyInjection;
using System;
using WpfApp.Core.Services;

namespace WpfApp.Data.Services;
public class ServiceFactory : IServiceFactory
{
    private readonly IServiceProvider _serviceProvider;

    public ServiceFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public T Create<T>() where T : class
    {
        return _serviceProvider.GetRequiredService<T>();
    }
}

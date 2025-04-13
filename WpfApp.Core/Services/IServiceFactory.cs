using System;
using WpfApp.Core.Services;

namespace WpfApp.Core.Services;
public interface IServiceFactory
{
    T Create<T>() where T : class;
}

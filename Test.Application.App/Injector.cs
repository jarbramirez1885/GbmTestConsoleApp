using Microsoft.Extensions.DependencyInjection;
using System;

namespace Test.Application.App
{
    public static class Injector
    {
        static IServiceProvider? _proveedor;

        public static void GenerarProveedor(IServiceCollection serviceCollection)
        {
            _proveedor = serviceCollection.BuildServiceProvider();
        }

        public static T GetService<T>()
        {
            return _proveedor.GetService<T>();
        }
    }
}

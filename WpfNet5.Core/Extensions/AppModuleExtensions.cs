using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace WpfNet5.Core.Extensions
{
    public static class AppModuleExtensions
    {
        public static IServiceCollection AddModule<TModule> (this IServiceCollection services) where TModule : AppModule
        {
            var assembly = Assembly.GetAssembly(typeof(TModule));
            return AddModule(services, assembly);
        }

        public static IServiceCollection AddModule(this IServiceCollection services, Assembly assembly)
        {
            var viewModels = assembly.GetTypes().Where(type => type.CustomAttributes.Any(attribute => attribute.AttributeType == typeof(ViewModelAttribute)));

            foreach (var viewModel in viewModels)
            {
                services.AddTransient(viewModel);
            }

            return services;
        }
    }
}

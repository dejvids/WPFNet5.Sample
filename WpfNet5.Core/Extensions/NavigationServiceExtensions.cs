using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WpfNet5.Core.Services;

namespace WpfNet5.Core.Extensions
{
    public static class NavigationServiceExtensions
    {

        public static IServiceCollection RegisterMainWindow<TWindow>(this IServiceCollection services) where TWindow : WindowBase
        {
            services.AddSingleton<WindowBase, TWindow>();
            services.AddSingleton<IXNavigationService, XNavigationService>();

            //Register main module
            services.AddModule(Assembly.GetCallingAssembly());

            return services;
        }

       
    }
}

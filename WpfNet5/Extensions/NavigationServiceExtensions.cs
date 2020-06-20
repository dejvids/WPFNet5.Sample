using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Navigation;
using WpfNet5.Core;
using WpfNet5.Core.Services;

namespace WpfNet5.Extensions
{
    public static class NavigationServiceExtensions
    {
        public static IServiceCollection AddNavigation<TRootView>(this IServiceCollection services) where TRootView:XViewModel
        {
            services.AddTransient<TRootView>();
            services.AddSingleton<IXNavigationService, XNavigationService>(s =>
            {
                var rootViewmodel = s.GetRequiredService<TRootView>();
                var assembly = Assembly.GetAssembly(typeof(TRootView));
                var rootViewType = assembly.GetTypes().FirstOrDefault(t => t.IsSubclassOf(typeof(XPage<TRootView>)));
                var rootPage = Activator.CreateInstance(rootViewType) as XPage<TRootView>;
                rootPage.DataContext = rootViewmodel;

                var navService = new XNavigationService(s, rootPage);
                return navService;
            });

            return services;
        }
    }
}

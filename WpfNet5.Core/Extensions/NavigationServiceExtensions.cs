using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Navigation;
using WpfNet5.Core;
using WpfNet5.Core.Helpers;
using WpfNet5.Core.Services;

namespace WpfNet5.Core.Extensions
{
    public static class NavigationServiceExtensions
    {
       // public static IServiceCollection AddNavigation<TRootViewModel>(this IServiceCollection services) where TRootViewModel:XViewModel
        //{
        //    services.AddTransient<TRootViewModel>();
        //    services.AddSingleton<IXNavigationService, XNavigationService>(s =>
        //    {
        //        var rootViewmodel = s.GetRequiredService<TRootViewModel>();
        //        var mainWindow = s.GetRequiredService<MainWindow>();

        //        var routerContainer = FindVisualChildren<Router>(mainWindow) as Router;
        //        //var assembly = Assembly.GetAssembly(typeof(TRootViewModel));
        //        //var rootViewType = assembly.GetTypes().FirstOrDefault(t => t.IsSubclassOf(typeof(XPage<TRootViewModel>)));
        //        //var rootPage = Activator.CreateInstance(rootViewType) as XPage<TRootViewModel>;

        //        var navService = new XNavigationService(s, routerContainer);
        //        //rootViewmodel.Init(navService, null);
        //        //rootPage.DataContext = rootViewmodel;
        //        return navService;
        //    });

        //    return services;
        //}

        public static IServiceCollection RegisterMainWindow<TWindow>(this IServiceCollection services) where TWindow : WindowBase
        {
            services.AddSingleton<WindowBase, TWindow>();
            services.AddSingleton<IXNavigationService, XNavigationService>();

            return services;
        }

       
    }
}

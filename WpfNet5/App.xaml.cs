using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfNet5.Core.Extensions;
using WpfNet5.ViewModels;
using WpfNet5.Views;

namespace WpfNet5
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange:true)
                .Build();

             _serviceProvider = new ServiceCollection()
                .AddNavigation<HomeViewModel>()
                .AddTransient(typeof(MainWindow))
                .AddModule<Admin.AdminModule>()
                .AddModule<MainModule>()
                .BuildServiceProvider();

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}

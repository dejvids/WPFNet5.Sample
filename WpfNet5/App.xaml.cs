using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using WpfNet5.Core;
using WpfNet5.Core.Extensions;
using System.Net.Http;

namespace WpfNet5
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : ApplicationBase
    {
        public App()
        {
            SetDefaultConfiguration();

            ConfigureServices(services =>
            {
                services.AddModule<MainModule>()
                .AddModule<Admin.AdminModule>()
                .RegisterMainWindow<MainWindow>();

                services.AddHttpClient("apiClient");
            });

            Start();
        }
    }
}

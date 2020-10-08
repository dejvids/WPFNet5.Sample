using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;
using WpfNet5.Core;
using WpfNet5.User;
using WpfNet5.Core.Extensions;

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
               services.AddModule<MainModule>()
               .AddModule<Admin.AdminModule>()
               .AddModule<UserModule>()
               .RegisterMainWindow<MainWindow>());

            Start();
        }
    }
}

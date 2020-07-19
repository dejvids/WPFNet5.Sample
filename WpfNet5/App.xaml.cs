using Microsoft.Extensions.Configuration;
using System.IO;
using WpfNet5.Core;
using WpfNet5.Core.Extensions;

namespace WpfNet5
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
            ConfigureConfiguration(configurationBuilder =>
                configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true));
            
            ConfigureServices(services =>
               services.AddModule<Admin.AdminModule>()
               .AddModule<MainModule>()
               .RegisterMainWindow<MainWindow>());

            Start();
        }
        //protected override void Startup()
        //{
        //    ConfigureConfiguration(configurationBuilder =>
        //        configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //    );

        //    ConfigureServices(services =>
        //       services.AddModule<Admin.AdminModule>()
        //       .AddModule<MainModule>()
        //       .RegisterMainWindow<MainWindow>());
        //}
    }
}

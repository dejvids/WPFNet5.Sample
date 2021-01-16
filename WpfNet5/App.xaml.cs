using Microsoft.Extensions.DependencyInjection;
using WpfNet5.Core;
using WpfNet5.User;
using WpfNet5.Core.Extensions;
using WpfNet5.Admin;

namespace WpfNet5
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : ApplicationBase
    {
        public App()
            : base()
        {
            SetDefaultConfiguration();

            ConfigureServices(services =>
            {
                services.RegisterMainWindow<MainWindow>()
                .AddModule<MainModule>()
                .AddModule<AdminModule>()
                .AddModule<UserModule>()
                .AddEventAggregator();

                services.AddHttpClient("apiClient");
            });

            Start();
        }
    }
}

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
        {
            SetDefaultConfiguration();

            ConfigureServices(services =>
            {
                services.AddModule<MainModule>()
                .AddModule<AdminModule>()
                .RegisterMainWindow<MainWindow>()
                .AddModule<UserModule>();

                services.AddHttpClient("apiClient");
                services.AddSingleton<IEventPublisher, EventAggregator>();
            });

            Start();
        }
    }
}

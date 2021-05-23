using Microsoft.Extensions.DependencyInjection;
using ModularWPF.User;
using ModularWPF.Admin;
using ModularWPF.Core;
using ModularWPF.Core.Extensions;

namespace ModularWPF
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

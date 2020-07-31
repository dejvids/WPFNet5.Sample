using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;
using System.Windows;
using WpfNet5.Core.Services;

namespace WpfNet5.Core
{
    public class ApplicationBase : Application
    {
        private IServiceCollection m_services;
        private ConfigurationBuilder m_configBuilder;

        public IConfiguration Configuration { get; private set; }

        public ApplicationBase()
        {
        }

        public void Start()
        {
            WindowBase mainWindow;


            var serviceProvider = m_services.BuildServiceProvider();
            mainWindow = serviceProvider.GetRequiredService<WindowBase>();
            var navService = serviceProvider.GetRequiredService<IXNavigationService>();
            navService.StartWithRouter(mainWindow.Router);


            mainWindow.Show();
        }

        protected void ConfigureServices(Action<IServiceCollection> builder)
        {
            if (builder == null)
                throw new ArgumentNullException();

            if (m_services == null)
            {
                m_services = new ServiceCollection();

                builder.Invoke(m_services);
            }
        }

        protected void ConfigureConfiguration(Action<IConfigurationBuilder> builder)
        {
            if (builder == null)
                throw new ArgumentNullException();

            if (m_configBuilder == null)
            {
                m_configBuilder = new ConfigurationBuilder();
            }

            builder.Invoke(m_configBuilder);
        }

        protected void SetDefaultConfiguration()
        {
            if (m_configBuilder == null)
            {
                m_configBuilder = new ConfigurationBuilder();
            }

            var callingAssembly = Assembly.GetCallingAssembly();
            string environment = Environment.GetEnvironmentVariable("ASPNET_CORE_ENVIRONMENT");

            m_configBuilder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: false, reloadOnChange: true)
            .AddUserSecrets(callingAssembly);
        }
    }
}

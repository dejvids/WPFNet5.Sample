using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfNet5.Core
{
   public class AppBuilder
    {
        private IServiceCollection services;
        private ConfigurationBuilder configBuilder;
        public static AppBuilder Create()
        {
            return new AppBuilder();
        }

        public AppBuilder ConfigureServices(Action<IServiceCollection> builder)
        {
            if (services == null)
            {
                services = new ServiceCollection();

                builder.Invoke(services);
            }

            return this;
        }

        public AppBuilder ConfigureConfiguration(Action<IConfigurationBuilder> builder)
        {
            if (configBuilder == null)
            {
                configBuilder = new ConfigurationBuilder();
            }

            builder.Invoke(configBuilder);

            return this;
        }
    }
}

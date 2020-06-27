using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using WpfNet5.Core.Services;

namespace WpfNet5.Core.Extensions
{
    public static class AppModuleExtensions
    {
        public static IServiceCollection AddModule<TModule> (this IServiceCollection services) where TModule : AppModule
        {
            var assembly = Assembly.GetAssembly(typeof(TModule));
            var viewModels = assembly.GetTypes().Where(type => type.CustomAttributes.Any(attribute => attribute.AttributeType == typeof(ViewModelAttribute)));

            foreach(var viewModel in viewModels)
            {
                 services.AddTransient(viewModel);
            }

            services.AddTransient<TModule>();
            return services;
        }
    }
}

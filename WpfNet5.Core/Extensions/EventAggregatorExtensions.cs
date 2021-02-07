using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfNet5.Core.Extensions
{
    public static class EventAggregatorExtensions
    {

        public static IServiceCollection AddEventAggregator(this IServiceCollection services)
        {
            services.AddSingleton<IEventAggregator, EventAggregator>();
            return services;
        }
    }
}

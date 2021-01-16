using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace WpfNet5.Core.Extensions
{
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// Add standard appsettings.json file as configuration source, any environment specific extension files are also included
        /// </summary>
        /// <param name="config">Configuration builder</param>
        /// <param name="envornmentSpecific">Include also appsettings.json for current environemnt e.g. appsettings.Development.json</param>
        /// <returns></returns>
        public static IConfigurationBuilder AddAppSettingsJson(this IConfigurationBuilder config, bool envornmentSpecific = true)
        {
            string environment = Environment.GetEnvironmentVariable("ASPNET_CORE_ENVIRONMENT");

            config.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            if(envornmentSpecific)
                config.AddJsonFile($"appsettings.{environment}.json", optional: false, reloadOnChange: true);
            return config;
        }
    }
}

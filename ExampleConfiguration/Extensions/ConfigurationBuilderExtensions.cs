namespace ExampleConfiguration.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ExampleConfiguration.CustomProviders;

    using Microsoft.Extensions.Configuration;

    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddEntityConfiguration(
            this IConfigurationBuilder builder)
        {
            var tempConfig = builder.Build();
            var connectionString =
                tempConfig.GetConnectionString("DbContextString");

            return builder.Add(new EntityConfigurationSource(connectionString));
        }
    }
}

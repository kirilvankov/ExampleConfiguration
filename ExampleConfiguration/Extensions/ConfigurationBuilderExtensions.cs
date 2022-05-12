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
        public static IConfigurationBuilder AddSqlServer(this IConfigurationBuilder builder, string connectionString)
        {
            return builder.Add(new EntityConfigurationSource { ConnectionString = connectionString });
        }
    }
}

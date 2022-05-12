namespace ExampleConfiguration.CustomProviders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Configuration;

    public class EntityConfigurationSource : IConfigurationSource
    {
        private readonly string _connectionString;

        public EntityConfigurationSource(string connectionString) =>
            _connectionString = connectionString;

        public IConfigurationProvider Build(IConfigurationBuilder builder) =>
            new EntityConfigurationProvider(_connectionString);
    }
}

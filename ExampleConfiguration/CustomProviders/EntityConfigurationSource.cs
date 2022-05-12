namespace ExampleConfiguration.CustomProviders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ExampleConfiguration.Watchers;

    using Microsoft.Extensions.Configuration;

    public class EntityConfigurationSource : IConfigurationSource
    {
        public string ConnectionString { get; set; }
        public Watcher Watcher { get; set; }
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new EntityConfigurationProvider(this);
        }
    }
}

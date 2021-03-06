namespace ExampleConfiguration.CustomProviders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ExampleConfiguration.Data;
    using ExampleConfiguration.DataModels;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Primitives;

    public class EntityConfigurationProvider : ConfigurationProvider
    {
        private readonly EntityConfigurationSource _source;
        private readonly IDisposable _changeTokenRegistration;

        public EntityConfigurationProvider(EntityConfigurationSource source)
        {
            this._source = source;
            if (_source.Watcher != null)
            {
                _changeTokenRegistration = ChangeToken.OnChange(
                    () => _source.Watcher.Refresh(),
                    Load
                );
            }

        }


        public override void Load()
        {
            using var dbContext = new ApplicationDbContext(_source.ConnectionString);

            //dbContext.Database.EnsureCreated();

            Data = dbContext.Settings.Any()
                ? dbContext.Settings.ToDictionary(c => c.Key, c => c.Value, StringComparer.OrdinalIgnoreCase)
                : CreateAndSaveDefaultValues(dbContext);
        }

        static IDictionary<string, string> CreateAndSaveDefaultValues(
            ApplicationDbContext context)
        {
            var settings = new Dictionary<string, string>(
                StringComparer.OrdinalIgnoreCase)
            {
                ["Options:Id"] = "b3da3c4c-9c4e-4411-bc4d-609e2dcc5c67",
                ["Options:DisplayLabel"] = "Widgets Incorporated, LLC.",
                ["Options:WidgetRoute"] = "api/widgets"
            };

            context.Settings.AddRange(
                settings.Select(kvp => new Setting { Key = kvp.Key, Value = kvp.Value })
                        .ToArray());

            context.SaveChanges();

            return settings;
        }
    }
}

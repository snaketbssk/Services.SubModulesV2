using Microsoft.Extensions.Configuration;

namespace Services.SubModules.Configurations.Entities.Environments
{
    public abstract class BaseEnvironmentConfiguration
    {
        /// <summary>
        /// Название файла конфигурации
        /// </summary>
        protected abstract string Prefix { get; }

        /// <summary>
        /// Название файла конфигурации
        /// </summary>
        protected readonly IConfigurationRoot ConfigurationRoot;

        /// <summary>
        /// Конструктор
        /// </summary>
        protected internal BaseEnvironmentConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddEnvironmentVariables(Prefix);
            ConfigurationRoot = configurationBuilder.Build();
        }
    }
}

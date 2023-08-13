using Microsoft.Extensions.Configuration;

namespace Services.SubModules.Configurations.Entities.Environments
{
    /// <summary>
    /// Base class for environment-specific configuration settings.
    /// </summary>
    public abstract class BaseEnvironmentConfiguration
    {
        /// <summary>
        /// Gets the prefix for configuration keys.
        /// </summary>
        protected abstract string Prefix { get; }

        /// <summary>
        /// Gets the root configuration object.
        /// </summary>
        protected readonly IConfigurationRoot ConfigurationRoot;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseEnvironmentConfiguration"/> class.
        /// Constructs the configuration based on environment variables with the specified prefix.
        /// </summary>
        protected internal BaseEnvironmentConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();

            // Add environment variables with the specified prefix to the configuration builder.
            configurationBuilder.AddEnvironmentVariables(Prefix);

            // Build the configuration root using the collected environment variables.
            ConfigurationRoot = configurationBuilder.Build();
        }
    }
}

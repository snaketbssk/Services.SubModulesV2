using Microsoft.Extensions.Configuration;
using Services.SubModules.Configurations.Constants;

namespace Services.SubModules.Configurations.Entities.Environments
{
    /// <summary>
    /// Represents a configuration class for Serilog-related environment settings.
    /// </summary>
    /// <typeparam name="T">The type of the configuration class.</typeparam>
    public class SerilogEnvironmentConfiguration<T> : SingletonEnvironmentConfiguration<SerilogEnvironmentConfiguration<T>>
        where T : class, new()
    {
        /// <summary>
        /// Gets the prefix for configuration keys specific to Serilog environment.
        /// </summary>
        protected override string Prefix => ConfigurationConstant.SERILOG_ENVIRONMENT;

        /// <summary>
        /// Gets the root configuration object and binds it to an instance of type T.
        /// </summary>
        /// <returns>An instance of type T with Serilog-related configuration settings populated.</returns>
        public T GetRoot()
        {
            var result = new T();

            // Bind the configuration settings from ConfigurationRoot to the result instance of type T.
            ConfigurationRoot.Bind(result);

            return result;
        }
    }
}

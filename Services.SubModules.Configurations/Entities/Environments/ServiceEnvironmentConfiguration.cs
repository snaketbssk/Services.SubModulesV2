using Microsoft.Extensions.Configuration;
using Services.SubModules.Configurations.Constants;

namespace Services.SubModules.Configurations.Entities.Environments
{
    /// <summary>
    /// Represents a configuration class for service-related environment settings.
    /// </summary>
    /// <typeparam name="T">The type of the configuration class.</typeparam>
    public class ServiceEnvironmentConfiguration<T> : SingletonEnvironmentConfiguration<ServiceEnvironmentConfiguration<T>>
        where T : class, new()
    {
        /// <summary>
        /// Gets the prefix for configuration keys specific to the service environment, based on the service name.
        /// </summary>
        protected override string Prefix => $"{ConfigurationConstant.SERVICE_ENVIRONMENT}{Environment.GetEnvironmentVariable($"{ConfigurationConstant.SERVICE_ENVIRONMENT}NAME")}";

        /// <summary>
        /// Gets the root configuration object and binds it to an instance of type T.
        /// </summary>
        /// <returns>An instance of type T with service-related configuration settings populated.</returns>
        public T GetRoot()
        {
            var result = new T();

            // Bind the configuration settings from ConfigurationRoot to the result instance of type T.
            ConfigurationRoot.Bind(result);

            return result;
        }
    }
}

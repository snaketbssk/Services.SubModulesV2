namespace Services.SubModules.Configurations.Entities.Environments
{
    /// <summary>
    /// Represents an abstract base class for singleton environment configuration.
    /// </summary>
    /// <typeparam name="T">The type of the derived singleton configuration class.</typeparam>
    public abstract class SingletonEnvironmentConfiguration<T> : BaseEnvironmentConfiguration
        where T : BaseEnvironmentConfiguration, new()
    {
        /// <summary>
        /// Gets the singleton instance of the derived configuration class.
        /// </summary>
        public readonly static T Instance = new();
    }
}

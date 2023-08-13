namespace Services.SubModules.Configurations.Models.Roots.Entities.Environments
{
    /// <summary>
    /// Represents a root entity for Redis environment configuration.
    /// </summary>
    public class RedisEnvironmentRoot
    {
        /// <summary>
        /// Gets or sets the connection string for the Redis server.
        /// </summary>
        public string? CONNECTION { get; set; }
    }
}

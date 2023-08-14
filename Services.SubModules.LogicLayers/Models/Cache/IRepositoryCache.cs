namespace Services.SubModules.LogicLayers.Models.Cache
{
    /// <summary>
    /// Represents a cache configuration with common properties.
    /// </summary>
    public interface IRepositoryCache
    {
        /// <summary>
        /// Gets the project associated with the cache configuration.
        /// </summary>
        string Project { get; }

        /// <summary>
        /// Gets the container associated with the cache configuration.
        /// </summary>
        string Container { get; }

        /// <summary>
        /// Gets the expiry duration for cached items.
        /// </summary>
        TimeSpan? Expiry { get; }
    }
}

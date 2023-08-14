namespace Services.SubModules.LogicLayers.Models.Redis
{
    /// <summary>
    /// Represents a claim stored in Redis cache.
    /// </summary>
    public interface IClaimRedis
    {
        /// <summary>
        /// Gets or sets the type of the claim.
        /// </summary>
        string? Type { get; set; }

        /// <summary>
        /// Gets or sets the value of the claim.
        /// </summary>
        string? Value { get; set; }
    }
}

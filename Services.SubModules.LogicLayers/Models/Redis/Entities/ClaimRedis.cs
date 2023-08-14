namespace Services.SubModules.LogicLayers.Models.Redis.Entities
{
    /// <summary>
    /// Represents a claim stored in Redis cache.
    /// </summary>
    public class ClaimRedis : IClaimRedis
    {
        /// <summary>
        /// Gets or sets the claim type.
        /// </summary>
        public string? Type { get; set; }

        /// <summary>
        /// Gets or sets the claim value.
        /// </summary>
        public string? Value { get; set; }
    }
}

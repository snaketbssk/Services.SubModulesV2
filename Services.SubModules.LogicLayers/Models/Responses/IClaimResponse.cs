namespace Services.SubModules.LogicLayers.Models.Responses
{
    /// <summary>
    /// Represents an interface for claim response models.
    /// </summary>
    public interface IClaimResponse
    {
        /// <summary>
        /// Gets or sets the type of the claim.
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// Gets or sets the value of the claim.
        /// </summary>
        string Value { get; set; }
    }
}

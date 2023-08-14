namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    /// <summary>
    /// Represents a claim response containing information about a user claim.
    /// </summary>
    public class ClaimResponse : IClaimResponse
    {
        /// <summary>
        /// Gets or sets the type of the claim.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the value of the claim.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClaimResponse"/> class.
        /// </summary>
        public ClaimResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClaimResponse"/> class with the specified type and value.
        /// </summary>
        /// <param name="type">The type of the claim.</param>
        /// <param name="value">The value of the claim.</param>
        public ClaimResponse(string type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}

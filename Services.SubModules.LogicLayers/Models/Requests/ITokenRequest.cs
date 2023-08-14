namespace Services.SubModules.LogicLayers.Models.Requests
{
    /// <summary>
    /// Represents an interface for specifying a token in requests.
    /// </summary>
    public interface ITokenRequest
    {
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        string? Token { get; set; }
    }
}

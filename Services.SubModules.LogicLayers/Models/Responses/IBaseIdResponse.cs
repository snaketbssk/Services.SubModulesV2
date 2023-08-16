namespace Services.SubModules.LogicLayers.Models.Responses
{
    /// <summary>
    /// Represents an interface for response models with a base identifier.
    /// </summary>
    /// <typeparam name="T">The type of the identifier.</typeparam>
    public interface IBaseIdResponse<T>
    {
        /// <summary>
        /// Gets or sets the identifier associated with the response.
        /// </summary>
        T? Id { get; set; }

        /// <summary>
        /// Converts the identifier to its string representation.
        /// </summary>
        /// <returns>A string representation of the identifier.</returns>
        string ToIdString();
    }
}

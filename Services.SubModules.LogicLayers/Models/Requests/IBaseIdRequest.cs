namespace Services.SubModules.LogicLayers.Models.Requests
{
    /// <summary>
    /// Represents a base interface for request classes with an ID of a generic type.
    /// </summary>
    /// <typeparam name="T">The type of the ID.</typeparam>
    public interface IBaseIdRequest<T>
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        T? Id { get; set; }

        /// <summary>
        /// Converts the ID to its string representation.
        /// </summary>
        /// <returns>The string representation of the ID.</returns>
        string ToIdString();
    }
}

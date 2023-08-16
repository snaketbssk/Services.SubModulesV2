using Services.SubModules.LogicLayers.Models.Exceptions;

namespace Services.SubModules.LogicLayers.Models.Responses
{
    /// <summary>
    /// Represents an interface for exception response models.
    /// </summary>
    public interface IExceptionResponse
    {
        /// <summary>
        /// Gets or sets the timestamp of the exception.
        /// </summary>
        string Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier associated with the exception.
        /// </summary>
        string Guid { get; set; }

        /// <summary>
        /// Gets or sets the status of the service exception.
        /// </summary>
        StatusServiceException Status { get; set; }

        /// <summary>
        /// Converts the exception response to its string representation.
        /// </summary>
        /// <returns>A string representation of the exception response.</returns>
        string ToString();
    }
}

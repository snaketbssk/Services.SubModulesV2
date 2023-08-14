using Services.SubModules.LogicLayers.Models.Exceptions;
using System.Text.Json;

namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    /// <summary>
    /// Represents a response containing information about an exception.
    /// </summary>
    public class ExceptionResponse : IExceptionResponse
    {
        /// <summary>
        /// Gets or sets the timestamp when the exception occurred.
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the GUID associated with the exception.
        /// </summary>
        public string Guid { get; set; }

        /// <summary>
        /// Gets or sets the status of the service exception.
        /// </summary>
        public StatusServiceException Status { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionResponse"/> class.
        /// </summary>
        public ExceptionResponse()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionResponse"/> class.
        /// </summary>
        /// <param name="timestamp">The timestamp when the exception occurred.</param>
        /// <param name="guid">The GUID associated with the exception.</param>
        /// <param name="status">The status of the service exception.</param>
        public ExceptionResponse(DateTime timestamp, Guid guid, StatusServiceException status)
        {
            Timestamp = timestamp.ToString();
            Guid = guid.ToString();
            Status = status;
        }

        /// <summary>
        /// Converts the exception response to its JSON string representation.
        /// </summary>
        /// <returns>The JSON string representation of the exception response.</returns>
        public override string ToString()
        {
            var result = JsonSerializer.Serialize(this);
            return result;
        }
    }
}

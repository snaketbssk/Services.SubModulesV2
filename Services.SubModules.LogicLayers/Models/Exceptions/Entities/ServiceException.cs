namespace Services.SubModules.LogicLayers.Models.Exceptions.Entities
{
    /// <summary>
    /// Represents an exception that is thrown in service-related scenarios.
    /// </summary>
    public class ServiceException : Exception
    {
        /// <summary>
        /// Gets or sets the status associated with the service exception.
        /// </summary>
        public StatusServiceException Status { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceException"/> class
        /// with the specified status and optional error message.
        /// </summary>
        /// <param name="status">The status of the service exception.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public ServiceException(StatusServiceException status, string? message = default) : base(message)
        {
            Status = status;
        }
    }
}

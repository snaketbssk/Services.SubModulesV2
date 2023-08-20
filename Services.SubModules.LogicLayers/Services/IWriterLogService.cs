namespace Services.SubModules.LogicLayers.Services
{
    /// <summary>
    /// Represents a service for writing log files.
    /// </summary>
    public interface IWriterLogService
    {
        /// <summary>
        /// Writes a log entry to a log file asynchronously.
        /// </summary>
        /// <param name="timestamp">The timestamp for the log entry.</param>
        /// <param name="text">The text content of the log entry.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. True if the log entry was written successfully; otherwise, false.</returns>
        Task<bool> WriteLogFileAsync(DateTime timestamp, string text, CancellationToken cancellationToken = default);
    }
}

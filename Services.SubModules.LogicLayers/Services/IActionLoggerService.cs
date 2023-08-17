using Microsoft.Extensions.Logging;

namespace Services.SubModules.LogicLayers.Services
{
    /// <summary>
    /// Interface for a service responsible for logging action success.
    /// </summary>
    public interface IActionLoggerService
    {
        /// <summary>
        /// Logs a successful action.
        /// </summary>
        /// <typeparam name="T">The type of the logger.</typeparam>
        /// <param name="_logger">The logger instance to use for logging.</param>
        /// <param name="subject">The subject of the action.</param>
        /// <param name="content">The content of the action.</param>
        void ActionSuccess<T>(ILogger<T> _logger, string subject, string content);
    }
}

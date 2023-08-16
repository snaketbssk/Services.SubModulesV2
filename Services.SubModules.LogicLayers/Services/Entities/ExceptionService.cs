using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Prometheus;
using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;
using Services.SubModules.LogicLayers.Models.Exceptions;
using Services.SubModules.LogicLayers.Models.Exceptions.Entities;
using Services.SubModules.LogicLayers.Models.Responses;
using Services.SubModules.LogicLayers.Models.Responses.Entities;
using System.Net;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    /// <summary>
    /// Service for handling exceptions and logging.
    /// Implements the <see cref="IExceptionService"/> interface.
    /// </summary>
    public class ExceptionService : IExceptionService
    {
        /// <summary>
        /// Counter for tracking the number of exceptions by HTTP method.
        /// </summary>
        private static readonly Counter REQUEST_COUNT_BY_METHOD = Metrics
            .CreateCounter("exceptions_total", "Number of exceptions, by HTTP method.",
            new CounterConfiguration
            {
                // Here you specify only the names of the labels.
                LabelNames = new[] { "code", "method", "endpoint" }
            });

        private readonly IWriterLogService _logService;
        private readonly ILogger<ExceptionService> _logger;

        /// <summary>
        /// Constructor for initializing an instance of ExceptionService.
        /// </summary>
        /// <param name="logService">The service used for writing logs.</param>
        /// <param name="logger">The logger instance for ExceptionService.</param>
        public ExceptionService(
            IWriterLogService logService,
            ILogger<ExceptionService> logger)
        {
            _logger = logger;
            _logService = logService;
        }

        /// <summary>
        /// Executes the exception handling logic for an HTTP context.
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        /// <param name="exception">The exception that occurred.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>An instance of <see cref="IExceptionResponse"/>.</returns>
        public async Task<IExceptionResponse> ExecuteAsync(HttpContext context, Exception exception, CancellationToken cancellationToken = default)
        {
            var result = await ExecuteAsync(context.Request.Method, context.Request.Path, exception);
            return result;
        }

        /// <summary>
        /// Executes the exception handling logic for a gRPC context.
        /// </summary>
        /// <param name="context">The gRPC context.</param>
        /// <param name="exception">The exception that occurred.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>An instance of <see cref="IExceptionResponse"/>.</returns>
        public async Task<IExceptionResponse> ExecuteAsync(ServerCallContext context, Exception exception, CancellationToken cancellationToken = default)
        {
            var result = await ExecuteAsync(context.Method, context.Peer, exception);
            return result;
        }

        /// <summary>
        /// Executes the exception handling logic for a specified method and path.
        /// </summary>
        /// <param name="method">The HTTP method or gRPC method.</param>
        /// <param name="path">The path or peer address.</param>
        /// <param name="exception">The exception that occurred.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>An instance of <see cref="IExceptionResponse"/>.</returns>
        public async Task<IExceptionResponse> ExecuteAsync(string method, string path, Exception exception, CancellationToken cancellationToken = default)
        {
            var statusCode = GetStatusCode(exception);

            // Increment the exception count by method and labels.
            REQUEST_COUNT_BY_METHOD.WithLabels(
                statusCode.ToString(),
                method,
                path)
                .Inc();

            // Get the root configuration and necessary values.
            var root = AspNetCoreEnvironmentConfiguration<AspNetCoreEnvironmentRoot>.Instance.GetRoot();
            var service = $"{root.ASSEMBLY} {root.ID}";
            var timestamp = DateTime.UtcNow;
            var guid = Guid.NewGuid();
            var status = StatusServiceException.Unknown;

            // Create a log response object with exception details.
            var logResponse = new LogResponse(
                service: service,
                timestamp: timestamp,
                status: status,
                guid: guid,
                messageException: exception.Message,
                path: path,
                method: method,
                stackTrace: exception?.StackTrace ?? string.Empty);

            var textLogs = logResponse.ToString();

            // Log the exception details.
            _logger.LogError(textLogs);

            // Create an instance of ExceptionResponse with relevant information.
            var result = new ExceptionResponse(timestamp, guid, status);
            return result;
        }

        /// <summary>
        /// Executes the exception handling logic for an HTTP context.
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        /// <param name="serviceException">The custom service exception that occurred.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>An instance of <see cref="IExceptionResponse"/>.</returns>
        public async Task<IExceptionResponse> ExecuteAsync(HttpContext context, ServiceException serviceException, CancellationToken cancellationToken = default)
        {
            var result = await ExecuteAsync(context.Request.Method, context.Request.Path, serviceException);
            return result;
        }

        /// <summary>
        /// Executes the exception handling logic for a gRPC context.
        /// </summary>
        /// <param name="context">The gRPC context.</param>
        /// <param name="serviceException">The custom service exception that occurred.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>An instance of <see cref="IExceptionResponse"/>.</returns>
        public async Task<IExceptionResponse> ExecuteAsync(ServerCallContext context, ServiceException serviceException, CancellationToken cancellationToken = default)
        {
            var result = await ExecuteAsync(context.Method, context.Peer, serviceException);
            return result;
        }

        /// <summary>
        /// Executes the exception handling logic for a specified method and path.
        /// </summary>
        /// <param name="method">The HTTP method or gRPC method.</param>
        /// <param name="path">The path or peer address.</param>
        /// <param name="serviceException">The custom service exception that occurred.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>An instance of <see cref="IExceptionResponse"/>.</returns>
        public async Task<IExceptionResponse> ExecuteAsync(string method, string path, ServiceException serviceException, CancellationToken cancellationToken = default)
        {
            var statusCode = GetStatusCode(serviceException);

            // Increment the exception count by method and labels.
            REQUEST_COUNT_BY_METHOD.WithLabels(
                statusCode.ToString(),
                method,
                path)
                .Inc();

            // Get the root configuration and necessary values.
            var root = AspNetCoreEnvironmentConfiguration<AspNetCoreEnvironmentRoot>.Instance.GetRoot();
            var service = $"{root.ASSEMBLY} {root.ID}";
            var timestamp = DateTime.UtcNow;
            var guid = Guid.NewGuid();

            // Create a log response object with exception details.
            var logResponse = new LogResponse(
                service: service,
                timestamp: timestamp,
                status: serviceException.Status,
                guid: guid,
                messageException: serviceException.Message,
                path: path,
                method: method,
                stackTrace: serviceException?.StackTrace ?? string.Empty);

            var textLogs = logResponse.ToString();

            // Log the exception details.
            _logger.LogError(textLogs);

            // Create an instance of ExceptionResponse with relevant information.
            var result = new ExceptionResponse(timestamp, guid, serviceException.Status);
            return result;
        }

        /// <summary>
        /// Gets the appropriate status code from the provided custom service exception.
        /// </summary>
        /// <param name="serviceException">The custom service exception to analyze.</param>
        /// <returns>The corresponding status code.</returns>
        public virtual int GetStatusCode(Exception exception)
        {
            // Your logic to determine the status code goes here.
            // For example, you can switch on different service exception types and return suitable status codes.
            // If no specific logic is provided, you can return a default status code.
            return (int)HttpStatusCode.InternalServerError; // Default status code for internal server error.
        }
    }
}

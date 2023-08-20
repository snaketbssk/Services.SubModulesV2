using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Services.SubModules.LogicLayers.Models.Exceptions.Entities;
using Services.SubModules.LogicLayers.Models.Responses;

namespace Services.SubModules.LogicLayers.Services
{
    /// <summary>
    /// Represents a service for handling exceptions and producing exception responses.
    /// </summary>
    public interface IExceptionService
    {
        /// <summary>
        /// Executes the exception handling logic for an exception that occurred in an HTTP context.
        /// </summary>
        /// <param name="context">The HTTP context where the exception occurred.</param>
        /// <param name="exception">The exception to be handled.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. An IExceptionResponse containing the exception information.</returns>
        Task<IExceptionResponse> ExecuteAsync(HttpContext context, Exception exception, CancellationToken cancellationToken = default);

        /// <summary>
        /// Executes the exception handling logic for an exception that occurred in a gRPC server call context.
        /// </summary>
        /// <param name="context">The server call context where the exception occurred.</param>
        /// <param name="exception">The exception to be handled.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. An IExceptionResponse containing the exception information.</returns>
        Task<IExceptionResponse> ExecuteAsync(ServerCallContext context, Exception exception, CancellationToken cancellationToken = default);

        /// <summary>
        /// Executes the exception handling logic for an exception that occurred with specific method and path information.
        /// </summary>
        /// <param name="method">The HTTP method of the request where the exception occurred.</param>
        /// <param name="path">The path of the request where the exception occurred.</param>
        /// <param name="exception">The exception to be handled.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. An IExceptionResponse containing the exception information.</returns>
        Task<IExceptionResponse> ExecuteAsync(string method, string path, Exception exception, CancellationToken cancellationToken = default);

        /// <summary>
        /// Executes the exception handling logic for a ServiceException that occurred in an HTTP context.
        /// </summary>
        /// <param name="context">The HTTP context where the ServiceException occurred.</param>
        /// <param name="serviceException">The ServiceException to be handled.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. An IExceptionResponse containing the exception information.</returns>
        Task<IExceptionResponse> ExecuteAsync(HttpContext context, ServiceException serviceException, CancellationToken cancellationToken = default);

        /// <summary>
        /// Executes the exception handling logic for a ServiceException that occurred in a gRPC server call context.
        /// </summary>
        /// <param name="context">The server call context where the ServiceException occurred.</param>
        /// <param name="serviceException">The ServiceException to be handled.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. An IExceptionResponse containing the exception information.</returns>
        Task<IExceptionResponse> ExecuteAsync(ServerCallContext context, ServiceException serviceException, CancellationToken cancellationToken = default);

        /// <summary>
        /// Executes the exception handling logic for a ServiceException that occurred with specific method and path information.
        /// </summary>
        /// <param name="method">The HTTP method of the request where the ServiceException occurred.</param>
        /// <param name="path">The path of the request where the ServiceException occurred.</param>
        /// <param name="serviceException">The ServiceException to be handled.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. An IExceptionResponse containing the exception information.</returns>
        Task<IExceptionResponse> ExecuteAsync(string method, string path, ServiceException serviceException, CancellationToken cancellationToken = default);
    }
}

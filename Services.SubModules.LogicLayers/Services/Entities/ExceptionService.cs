using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Prometheus;
using Services.SubModules.Configurations.Entities;
using Services.SubModules.Configurations.Models.Roots.Entities;
using Services.SubModules.LogicLayers.Models.Exceptions;
using Services.SubModules.LogicLayers.Models.Exceptions.Entities;
using Services.SubModules.LogicLayers.Models.Responses;
using Services.SubModules.LogicLayers.Models.Responses.Entities;
using System.Net;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class ExceptionService : IExceptionService
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly Counter REQUEST_COUNT_BY_METHOD = Metrics
            .CreateCounter("exceptions_total", "Number of exceptions, by HTTP method.",
            new CounterConfiguration
            {
                // Here you specify only the names of the labels.
                LabelNames = new[] { "code", "method", "endpoint" }
            });

        /// <summary>
        /// 
        /// </summary>
        private readonly IWriterLogService _logService;

        /// <summary>
        /// 
        /// </summary>
        private readonly ILogger<ExceptionService> _logger;

        public ExceptionService(
            IWriterLogService logService,
            ILogger<ExceptionService> logger)
        {
            _logger = logger;
            _logService = logService;
        }

        public async Task<IExceptionResponse> ExecuteAsync(HttpContext context, Exception exception, CancellationToken cancellationToken = default)
        {
            var result = await ExecuteAsync(context.Request.Method, context.Request.Path, exception);
            return result;
        }

        public async Task<IExceptionResponse> ExecuteAsync(ServerCallContext context, Exception exception, CancellationToken cancellationToken = default)
        {
            var result = await ExecuteAsync(context.Method, context.Peer, exception);
            return result;
        }

        public async Task<IExceptionResponse> ExecuteAsync(string method, string path, Exception exception, CancellationToken cancellationToken = default)
        {
            var statusCode = GetStatusCode(exception);
            REQUEST_COUNT_BY_METHOD.WithLabels(
                statusCode.ToString(),
                method,
                path)
                .Inc();
            var root = SerilogConfiguration<SerilogRoot>.Instance.Root;
            var service = root.Seq.Name;
            var timestamp = DateTime.UtcNow;
            var guid = Guid.NewGuid();
            var status = StatusServiceException.Unknown;
            //
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
            _logger.LogError(textLogs);
            var result = new ExceptionResponse(timestamp, guid, status);
            return result;
        }

        public async Task<IExceptionResponse> ExecuteAsync(HttpContext context, ServiceException serviceException, CancellationToken cancellationToken = default)
        {
            var result = await ExecuteAsync(context.Request.Method, context.Request.Path, serviceException);
            return result;
        }

        public async Task<IExceptionResponse> ExecuteAsync(ServerCallContext context, ServiceException serviceException, CancellationToken cancellationToken = default)
        {
            var result = await ExecuteAsync(context.Method, context.Peer, serviceException);
            return result;
        }

        public async Task<IExceptionResponse> ExecuteAsync(string method, string path, ServiceException serviceException, CancellationToken cancellationToken = default)
        {
            var statusCode = GetStatusCode(serviceException);
            REQUEST_COUNT_BY_METHOD.WithLabels(
                statusCode.ToString(),
                method,
                path)
                .Inc();
            var root = SerilogConfiguration<SerilogRoot>.Instance.Root;
            var service = root.Seq.Name;
            var timestamp = DateTime.UtcNow;
            var guid = Guid.NewGuid();
            //
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
            _logger.LogError(textLogs);
            var result = new ExceptionResponse(timestamp, guid, serviceException.Status);
            return result;
        }

        public virtual int GetStatusCode(Exception exception)
        {
            switch (exception)
            {
                default: return (int)HttpStatusCode.InternalServerError;
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Prometheus;
using Services.SubModules.LogicLayers.Constants;
using Services.SubModules.LogicLayers.Models.Responses;
using Services.SubModules.LogicLayers.Models.Responses.Entities;
using Services.SubModules.LogicLayers.Services;
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
            var statusCode = GetStatusCode(exception);
            REQUEST_COUNT_BY_METHOD.WithLabels(
                statusCode.ToString(), 
                context.Request.Method, 
                context.Request.Path)
                .Inc();
            var timestamp = DateTime.UtcNow;
            var guid = Guid.NewGuid();
            //
            var logResponse = new LogResponse(
                timestamp: timestamp,
                guid: guid,
                messageException: exception.Message,
                path: context.Request.Path,
                method: context.Request.Method,
                stackTrace: exception?.StackTrace ?? string.Empty);
            var textLogs = logResponse.ToString();
            _logger.LogError(textLogs);
            await _logService.WriteLogFileAsync(timestamp, textLogs);
            //
            var result = new ExceptionResponse(timestamp, guid);
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

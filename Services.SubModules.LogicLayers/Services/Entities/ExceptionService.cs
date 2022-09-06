using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Services.SubModules.LogicLayers.Constants;
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

        public async Task<ExceptionResponse> ExecuteAsync(HttpContext context, Exception exception, CancellationToken cancellationToken = default)
        {
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

        
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Services.SubModules.LogicLayers.Constants;
using Services.SubModules.LogicLayers.Models.Mappings.Entities;
using Services.SubModules.LogicLayers.Models.Responses.Entities;
using Services.SubModules.LogicLayers.Services;
using System.Net;

namespace Services.SubModules.LogicLayers.Middlewares.Entities
{
    public class ExceptionMiddleware
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly RequestDelegate _requestDelegate;
        /// <summary>
        /// 
        /// </summary>
        private readonly ILogger<ExceptionMiddleware> _logger;
        /// <summary>
        /// 
        /// </summary>
        private readonly ILogService _logService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logService"></param>
        /// <param name="requestDelegate"></param>
        /// <param name="loggerFactory"></param>
        public ExceptionMiddleware(
            ILogService logService,
            RequestDelegate requestDelegate,
            ILoggerFactory loggerFactory)
        {
            _requestDelegate = requestDelegate;
            _logger = loggerFactory.CreateLogger<ExceptionMiddleware>();
            _logService = logService;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception exception)
            {
                var timestamp = DateTime.UtcNow;
                var contentType = GetContentType();
                var statusCode = GetStatusCode(exception);
                var httpResponse = GetHttpResponse(context);
                var guid = Guid.NewGuid();
                //
                var logsResponse = new LogResponse(
                    timestamp: timestamp,
                    guid: guid,
                    messageException: exception.Message,
                    path: context.Request.Path,
                    method: context.Request.Method,
                    stackTrace: exception?.StackTrace ?? string.Empty);
                var textLogs = logsResponse.ToString();
                _logger.LogError(textLogs);
                _logService.Write(timestamp, textLogs);
                //
                httpResponse.ContentType = contentType;
                httpResponse.StatusCode = statusCode;
                var exceptionResponse = new ExceptionResponse(timestamp, guid);
                var response = exceptionResponse.ToString();
                await httpResponse.WriteAsync(response);
            }
        }
        public virtual HttpResponse GetHttpResponse(HttpContext context)
        {
            var result = context.Response;
            return result;
        }
        public virtual string GetContentType()
        {
            var result = ContentTypeConstant.JSON_APPLICATION;
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

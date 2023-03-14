using Microsoft.AspNetCore.Http;
using Services.SubModules.LogicLayers.Constants;
using Services.SubModules.LogicLayers.Models.Exceptions.Entities;
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
        private readonly IExceptionService _exceptionService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logService"></param>
        /// <param name="requestDelegate"></param>
        /// <param name="loggerFactory"></param>
        public ExceptionMiddleware(
            IExceptionService exceptionService,
            RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
            _exceptionService = exceptionService;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (ServiceException serviceException)
            {
                var contentType = GetContentType();
                var statusCode = GetStatusCode(serviceException);
                var httpResponse = GetHttpResponse(context);
                var exceptionResponse = await _exceptionService.ExecuteAsync(context, serviceException);
                var response = exceptionResponse.ToString();
                //
                httpResponse.ContentType = contentType;
                httpResponse.StatusCode = statusCode;
                await httpResponse.WriteAsync(response);
            }
            catch (Exception exception)
            {
                var contentType = GetContentType();
                var statusCode = GetStatusCode(exception);
                var httpResponse = GetHttpResponse(context);
                var exceptionResponse = await _exceptionService.ExecuteAsync(context, exception);
                var response = exceptionResponse.ToString();
                //
                httpResponse.ContentType = contentType;
                httpResponse.StatusCode = statusCode;
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

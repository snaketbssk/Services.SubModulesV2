using Microsoft.AspNetCore.Http;
using Services.SubModules.LogicLayers.Constants;
using Services.SubModules.LogicLayers.Models.Exceptions.Entities;
using Services.SubModules.LogicLayers.Services;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Middlewares.Entities
{
    /// <summary>
    /// Middleware to handle exceptions and return appropriate responses.
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly IExceptionService _exceptionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionMiddleware"/> class.
        /// </summary>
        /// <param name="exceptionService">The exception service to handle exceptions.</param>
        /// <param name="requestDelegate">The next request delegate in the pipeline.</param>
        public ExceptionMiddleware(
            IExceptionService exceptionService,
            RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
            _exceptionService = exceptionService;
        }

        /// <summary>
        /// Invokes the middleware to handle exceptions and return appropriate responses.
        /// </summary>
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

                // Set response properties
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

                // Set response properties
                httpResponse.ContentType = contentType;
                httpResponse.StatusCode = statusCode;
                await httpResponse.WriteAsync(response);
            }
        }

        /// <summary>
        /// Gets the HTTP response associated with the current context.
        /// </summary>
        public virtual HttpResponse GetHttpResponse(HttpContext context)
        {
            var result = context.Response;
            return result;
        }

        /// <summary>
        /// Gets the content type for the response.
        /// </summary>
        public virtual string GetContentType()
        {
            var result = ContentTypeConstant.JSON_APPLICATION;
            return result;
        }

        /// <summary>
        /// Gets the status code for the response based on the exception type.
        /// </summary>
        public virtual int GetStatusCode(Exception exception)
        {
            switch (exception)
            {
                default: return (int)HttpStatusCode.InternalServerError;
            }
        }
    }
}

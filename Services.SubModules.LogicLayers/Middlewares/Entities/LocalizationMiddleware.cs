using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Services.SubModules.LogicLayers.Constants;
using Services.SubModules.LogicLayers.Models.Responses.Entities;
using Services.SubModules.LogicLayers.Services;
using System.Net;
using System.Globalization;

namespace Services.SubModules.LogicLayers.Middlewares.Entities
{
    public class LocalizationMiddleware
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly RequestDelegate _requestDelegate;

        /// <summary>
        /// 
        /// </summary>
        private readonly ILogger<LocalizationMiddleware> _logger;

        /// <summary>
        /// 
        /// </summary>
        private readonly IWriterLogService _logService;

        /// <summary>
        /// 
        /// </summary>
        private readonly ILocalizationService _localizationService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logService"></param>
        /// <param name="requestDelegate"></param>
        /// <param name="loggerFactory"></param>
        public LocalizationMiddleware(
            ILocalizationService localizationService,
            IWriterLogService logService,
            RequestDelegate requestDelegate,
            ILoggerFactory loggerFactory)
        {
            _requestDelegate = requestDelegate;
            _logger = loggerFactory.CreateLogger<LocalizationMiddleware>();
            _logService = logService;
            _localizationService = localizationService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var culture = context.Request.Headers["X-Culture"];
            _localizationService.SetCulture(culture);

            await _requestDelegate(context);
        }
    }
}

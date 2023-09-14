using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Services.SubModules.LogicLayers.Services;

namespace Services.SubModules.LogicLayers.Middlewares.Entities
{
    /// <summary>
    /// Middleware to handle localization for requests.
    /// </summary>
    public class LocalizationMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger<LocalizationMiddleware> _logger;
        private readonly IWriterLogService _logService;
        private readonly ILocalizationService _localizationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizationMiddleware"/> class.
        /// </summary>
        /// <param name="localizationService">The localization service for managing cultures.</param>
        /// <param name="logService">The writer log service for logging.</param>
        /// <param name="requestDelegate">The next request delegate in the pipeline.</param>
        /// <param name="loggerFactory">The logger factory for creating loggers.</param>
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

        /// <summary>
        /// Invokes the middleware to handle localization for the request.
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            // Get the culture from the request headers
            var culture = context.Request.Headers["X-Locale"];

            // Set the culture in the localization service
            _localizationService.SetCulture(culture);

            // Continue processing the request pipeline
            await _requestDelegate(context);
        }
    }
}

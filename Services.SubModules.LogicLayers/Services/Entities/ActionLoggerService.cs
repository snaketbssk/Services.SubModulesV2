using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;
using Services.SubModules.LogicLayers.Models.Responses;
using System.Collections.Generic;
using System.Text;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    /// <summary>
    /// Service responsible for logging actions and successes.
    /// </summary>
    public class ActionLoggerService : BaseService, IActionLoggerService
    {
        private readonly IUserAgentService _userAgentService;
        private IUserAgentResponse _userAgentResponse;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionLoggerService"/> class.
        /// </summary>
        /// <param name="httpContextAccessor">The HttpContextAccessor instance.</param>
        /// <param name="userAgentService">The user agent service.</param>
        public ActionLoggerService(IHttpContextAccessor httpContextAccessor, IUserAgentService userAgentService) : base(httpContextAccessor)
        {
            _userAgentService = userAgentService;
        }

        /// <summary>
        /// Retrieves the cached UserAgentResponse or fetches it from the service.
        /// </summary>
        /// <returns>The UserAgentResponse.</returns>
        public IUserAgentResponse GetUserAgentResponse()
        {
            if (_userAgentResponse is null)
                _userAgentResponse = _userAgentService.GetUserAgent();
            return _userAgentResponse;
        }

        /// <summary>
        /// Logs an action success.
        /// </summary>
        /// <typeparam name="T">The type of logger.</typeparam>
        /// <param name="logger">The logger instance.</param>
        /// <param name="subject">The subject of the action.</param>
        /// <param name="content">The content of the action.</param>
        public void ActionSuccess<T>(ILogger<T> logger, string subject, string content)
        {
            if (logger is null)
                return;
            var userAgent = GetUserAgentResponse();
            var root = AspNetCoreEnvironmentConfiguration<AspNetCoreEnvironmentRoot>.Instance.GetRoot();

            var log = new StringBuilder();
            log.Append($"assembly {root.ASSEMBLY} action success ");

            var contentLog = new List<string>()
            {
                root.ASSEMBLY ?? "",
                subject ?? "",
                content ?? "",
                HttpContext?.TraceIdentifier ?? "",
                userAgent?.RemoteIpAddress ?? "",
                userAgent?.Browser ?? "",
                userAgent?.VersionBrowser ?? "",
                userAgent?.OS ?? "",
                userAgent?.VersionOS ?? ""
            };

            foreach (var x in contentLog)
            {
                if (!string.IsNullOrWhiteSpace(x))
                    log.Append($" {x}");
            }

            logger.LogInformation(log.ToString());
        }
    }
}

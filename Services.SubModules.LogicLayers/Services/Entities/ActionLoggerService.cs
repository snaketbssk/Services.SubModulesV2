using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;
using Services.SubModules.LogicLayers.Models.Responses;
using System.Text;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class ActionLoggerService : BaseService, IActionLoggerService
    {
        private readonly IUserAgentService _userAgentService;
        private IUserAgentResponse _userAgentResponse;

        public ActionLoggerService(IHttpContextAccessor httpContextAccessor,
                                   IUserAgentService userAgentService) : base(httpContextAccessor)
        {
            _userAgentService = userAgentService;
        }

        public IUserAgentResponse GetUserAgentResponse()
        {
            if (_userAgentResponse is null)
                _userAgentResponse = _userAgentService.GetUserAgent();
            return _userAgentResponse;
        }

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

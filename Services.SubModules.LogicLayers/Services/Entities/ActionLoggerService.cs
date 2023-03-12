using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Services.SubModules.Configurations.Entities;
using Services.SubModules.Configurations.Models.Roots.Entities;
using Services.SubModules.LogicLayers.Models.Responses;

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
            logger.LogInformation($"{SerilogConfiguration<SerilogRoot>.Instance?.Root?.Seq?.Name} action success {subject} {content} {HttpContext.TraceIdentifier} {userAgent?.RemoteIpAddress} {userAgent?.Browser} {userAgent?.VersionBrowser} {userAgent?.OS} {userAgent?.VersionOS}");
        }
    }
}

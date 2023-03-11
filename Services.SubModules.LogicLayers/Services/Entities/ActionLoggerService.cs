using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Services.SubModules.Configurations.Entities;
using Services.SubModules.Configurations.Models.Roots.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class ActionLoggerService : BaseService, IActionLoggerService
    {
        private readonly IUserAgentService _userAgentService;

        public ActionLoggerService(IHttpContextAccessor httpContextAccessor,
                                   IUserAgentService userAgentService) : base(httpContextAccessor)
        {
            _userAgentService = userAgentService;
        }

        public void ActionSuccess<T>(ILogger<T> _logger, string subject, string content)
        {
            var userAgent = _userAgentService.GetUserAgent();
            _logger.LogInformation($"{SerilogConfiguration<SerilogRoot>.Instance?.Root?.Seq?.Name} action success {subject} {content} {HttpContext.TraceIdentifier} {userAgent.RemoteIpAddress} {userAgent.Browser} {userAgent.VersionBrowser} {userAgent.OS} {userAgent.VersionOS}");
        }
    }
}

using Microsoft.AspNetCore.Http;
using Services.SubModules.LogicLayers.Constants;
using Services.SubModules.LogicLayers.Models.Responses;
using Services.SubModules.LogicLayers.Models.Responses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UAParser;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class UserAgentService : BaseService, IUserAgentService
    {
        public UserAgentService(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }

        public IUserAgentResponse GetUserAgent()
        {
            var result = new UserAgentResponse();

            result.RemoteIpAddress = ParseRemoteIpAddress();

            var userAgent = ParseClientInfo();
            if (userAgent is not null)
            {
                result.Browser = userAgent.UA.Family;
                result.VersionBrowser = userAgent.UA.Major;
                result.OS = userAgent.OS.Family;
                result.VersionOS = userAgent.OS.Major;
                result.Device = userAgent.Device.Family;
                result.BrandDevice = userAgent.Device.Brand;
            }

            return result;
        }

        private ClientInfo ParseClientInfo()
        {
            var uaParser = Parser.GetDefault();

            if (!HttpRequest.Headers.TryGetValue(HeaderConstant.USER_AGENT, out var userAgent))
                return default;

            var result = uaParser.Parse(userAgent);
            return result;
        }

        private string ParseRemoteIpAddress()
        {
            if (HttpContext?.Connection?.RemoteIpAddress is null)
                return string.Empty;

            string result = HttpContext.Connection.RemoteIpAddress.ToString();

            if (HttpRequest.Headers.ContainsKey(HeaderConstant.X_FORWARDED_FOR))
            {
                var forwardedList = HttpRequest.Headers[HeaderConstant.X_FORWARDED_FOR].ToString()
                                                                          .Split(',', StringSplitOptions.RemoveEmptyEntries);
                foreach (var ip in forwardedList)
                {
                    if (ip.Trim() != result)
                    {
                        result = ip.Trim();
                        break;
                    }
                }
            }

            return result;
        }
    }
}

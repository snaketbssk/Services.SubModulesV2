using Microsoft.AspNetCore.Http;
using Services.SubModules.LogicLayers.Constants;
using Services.SubModules.LogicLayers.Models.Responses;
using Services.SubModules.LogicLayers.Models.Responses.Entities;
using UAParser;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    /// <summary>
    /// Service responsible for extracting user agent information from HTTP requests.
    /// Implements the <see cref="IUserAgentService"/> interface.
    /// </summary>
    public class UserAgentService : BaseService, IUserAgentService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserAgentService"/> class.
        /// </summary>
        /// <param name="httpContextAccessor">The HTTP context accessor.</param>
        public UserAgentService(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }

        /// <summary>
        /// Retrieves user agent information from the current HTTP request.
        /// </summary>
        /// <returns>The user agent information.</returns>
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

        /// <summary>
        /// Parses the client user agent information from the HTTP request headers.
        /// </summary>
        /// <returns>The parsed client information.</returns>
        private ClientInfo ParseClientInfo()
        {
            var uaParser = Parser.GetDefault();

            if (!HttpRequest.Headers.TryGetValue(HeaderConstant.USER_AGENT, out var userAgent))
                return default;

            var result = uaParser.Parse(userAgent);
            return result;
        }

        /// <summary>
        /// Parses the remote IP address from the HTTP context.
        /// </summary>
        /// <returns>The parsed remote IP address.</returns>
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

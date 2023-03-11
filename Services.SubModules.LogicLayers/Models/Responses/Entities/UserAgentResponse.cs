using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    public class UserAgentResponse : IUserAgentResponse
    {
        public string RemoteIpAddress { get; set; }
        public string OS { get; set; }
        public string VersionOS { get; set; }
        public string Browser { get; set; }
        public string VersionBrowser { get; set; }
        public string Device { get; set; }
        public string BrandDevice { get; set; }
    }
}

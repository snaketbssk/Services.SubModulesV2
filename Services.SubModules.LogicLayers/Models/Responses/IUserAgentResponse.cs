using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Responses
{
    public interface IUserAgentResponse
    {
        string RemoteIpAddress { get; set; }
        string OS { get; set; }
        string VersionOS { get; set; }
        string Browser { get; set; }
        string VersionBrowser { get; set; }
        string Device { get; set; }
        string BrandDevice { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Responses
{
    public interface IChartResponse
    {
        IEnumerable<string> Labels { get; set; }
        IEnumerable<decimal> Values { get; set; }
        int TotalCount { get; set; }
    }
}

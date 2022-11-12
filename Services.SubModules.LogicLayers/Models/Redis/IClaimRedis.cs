using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Redis
{
    public interface IClaimRedis
    {
        string Type { get; set; }
        string Value { get; set; }
    }
}

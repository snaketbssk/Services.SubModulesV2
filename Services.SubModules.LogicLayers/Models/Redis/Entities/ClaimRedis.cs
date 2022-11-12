using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Redis.Entities
{
    public class ClaimRedis : IClaimRedis
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }
}

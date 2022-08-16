using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    public class CreatedAtRequest : ICreatedAtRequest
    {
        public DateTime CreatedAt { get; set; }
    }
}

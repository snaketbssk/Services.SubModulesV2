using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Requests
{
    public interface ICreatedAtRequest
    {
        DateTime CreatedAt { get; set; }
    }
}

using Services.SubModules.LogicLayers.Models.Requests.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Requests
{
    public interface IIdsRequest
    {
        List<IdRequest> Ids { get; set; }
    }
}

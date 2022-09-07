using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Services.SubModules.LogicLayers.Models.Requests
{
    public interface IHttpContextRequest
    {
        HttpContext HttpContext { get; set; }
    }
}

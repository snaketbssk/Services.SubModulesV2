using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Services
{
    public interface IService
    {
        HttpContext HttpContext { get; }
        HttpResponse HttpResponse { get; }
        HttpRequest HttpRequest { get; }
    }
}

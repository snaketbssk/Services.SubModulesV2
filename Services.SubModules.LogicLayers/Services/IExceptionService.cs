using Microsoft.AspNetCore.Http;
using Services.SubModules.LogicLayers.Models.Responses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Services
{
    public interface IExceptionService
    {
        Task<ExceptionResponse> ExecuteAsync(HttpContext context, Exception exception, CancellationToken cancellationToken = default);
    }
}

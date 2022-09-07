using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Services.SubModules.LogicLayers.Models.Responses;
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
        Task<IExceptionResponse> ExecuteAsync(HttpContext context, Exception exception, CancellationToken cancellationToken = default);
        Task<IExceptionResponse> ExecuteAsync(ServerCallContext context, Exception exception, CancellationToken cancellationToken = default);
        Task<IExceptionResponse> ExecuteAsync(string method, string path, Exception exception, CancellationToken cancellationToken = default);
    }
}

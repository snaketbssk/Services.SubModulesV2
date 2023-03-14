using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Services.SubModules.LogicLayers.Models.Exceptions.Entities;
using Services.SubModules.LogicLayers.Models.Responses;

namespace Services.SubModules.LogicLayers.Services
{
    public interface IExceptionService
    {
        Task<IExceptionResponse> ExecuteAsync(HttpContext context, Exception exception, CancellationToken cancellationToken = default);
        Task<IExceptionResponse> ExecuteAsync(ServerCallContext context, Exception exception, CancellationToken cancellationToken = default);
        Task<IExceptionResponse> ExecuteAsync(string method, string path, Exception exception, CancellationToken cancellationToken = default);
        Task<IExceptionResponse> ExecuteAsync(HttpContext context, ServiceException serviceException, CancellationToken cancellationToken = default);
        Task<IExceptionResponse> ExecuteAsync(ServerCallContext context, ServiceException serviceException, CancellationToken cancellationToken = default);
        Task<IExceptionResponse> ExecuteAsync(string method, string path, ServiceException serviceException, CancellationToken cancellationToken = default);
    }
}

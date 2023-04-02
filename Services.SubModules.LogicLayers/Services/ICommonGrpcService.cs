using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services
{
    public interface ICommonGrpcService
    {
        Task<CurrencyCommonGrpcResponse> ExecuteAsync(IMapping<CurrencyCommonGrpcRequest> mapping, CancellationToken cancellationToken = default);
        Task<CurrenciesCommonGrpcResponse> ExecuteAsync(IMapping<CurrenciesCommonGrpcRequest> mapping, CancellationToken cancellationToken = default);
    }
}

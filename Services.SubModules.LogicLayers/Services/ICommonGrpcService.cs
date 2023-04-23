using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services
{
    public interface ICommonGrpcService
    {
        Task<(bool isSuccessful, CurrencyCommonGrpcResponse?)> GetCurrencyAsync(IMapping<IdGrpcModel> mapping, CancellationToken cancellationToken = default);
        Task<(bool isSuccessful, CurrenciesCommonGrpcResponse?)> GetCurrenciesAsync(CancellationToken cancellationToken = default);
    }
}

using Services.SubModules.LogicLayers.Models.Requests;
using Services.SubModules.LogicLayers.Models.Responses;

namespace Services.SubModules.LogicLayers.Services
{
    public interface ICommonService
    {
        Task<IEnumerable<ICurrencyResponse>> GetCurrenciesAsync(CancellationToken cancellationToken = default);
        Task<ICurrencyResponse> GetCurrencyAsync(IIdRequest request, CancellationToken cancellationToken = default);
    }
}

using Services.SubModules.LogicLayers.Models.Requests;
using Services.SubModules.LogicLayers.Models.Responses;

namespace Services.SubModules.LogicLayers.Models.Cache
{
    public interface IOnePaginationRepositoryCache<TValue> : IOneRepositoryCache
    {
        Task<bool> TrySetAsync(IEnumerable<TValue> values, CancellationToken cancellationToken = default);

        Task<(bool isSuccessful, IPaginationResponse<TValue> pagination)> TryGetAsync(IPaginationRequest request, CancellationToken cancellationToken = default);
        Task<(bool isSuccessful, IEnumerable<TValue> values)> TryGetAllAsync(CancellationToken cancellationToken = default);
    }
}

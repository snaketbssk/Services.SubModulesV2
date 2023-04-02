using Services.SubModules.LogicLayers.Models.Requests;
using Services.SubModules.LogicLayers.Models.Responses;

namespace Services.SubModules.LogicLayers.Models.Cache
{
    public interface IManyPaginationRepositoryCache<TKey, TValue> : IManyRepositoryCache<TKey>
    {
        Task<bool> TrySetAsync(TKey key, IEnumerable<TValue> values, CancellationToken cancellationToken = default);

        Task<(bool isSuccessful, IPaginationResponse<TValue> pagination)> TryGetAsync(TKey key, IPaginationRequest request, CancellationToken cancellationToken = default);

        Task<(bool isSuccessful, IEnumerable<TValue> values)> TryGetAllAsync(TKey key, CancellationToken cancellationToken = default);
    }
}

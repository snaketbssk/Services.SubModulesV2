using Services.SubModules.LogicLayers.Models.Requests;
using Services.SubModules.LogicLayers.Models.Responses;
using Services.SubModules.LogicLayers.Services;

namespace Services.SubModules.LogicLayers.Models.Cache.Entities
{
    public class ManyPaginationRepositoryCache<TKey, TValue> : ManyRepositoryCache<TKey>, IManyPaginationRepositoryCache<TKey, TValue>
    {
        public ManyPaginationRepositoryCache(ICacheService cacheService, string project, string container, TimeSpan? expiry)
            : base(cacheService, project, container, expiry)
        {
        }

        public async Task<bool> TrySetAsync(TKey key, IEnumerable<TValue> values, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryPaginationSetAsync(Project, Container, Expiry, key, values, cancellationToken);
            return result;
        }

        public async Task<(bool isSuccessful, IPaginationResponse<TValue> pagination)> TryGetAsync(TKey key, IPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryPaginationGetAsync<TKey, TValue>(Project, Container, key, request, cancellationToken);
            return result;
        }

        public async Task<(bool isSuccessful, IEnumerable<TValue> values)> TryGetAllAsync(TKey key, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryPaginationGetAllAsync<TKey, TValue>(Project, Container, key, cancellationToken);
            return result;
        }
    }
}

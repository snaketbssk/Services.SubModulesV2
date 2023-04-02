using Services.SubModules.LogicLayers.Models.Requests;
using Services.SubModules.LogicLayers.Models.Responses;
using Services.SubModules.LogicLayers.Services;

namespace Services.SubModules.LogicLayers.Models.Cache.Entities
{
    public class OnePaginationRepositoryCache<TValue> : OneRepositoryCache, IOnePaginationRepositoryCache<TValue>
    {
        public OnePaginationRepositoryCache(ICacheService cacheService, string project, string container, TimeSpan? expiry)
            : base(cacheService, project, container, expiry)
        {
        }

        public async Task<bool> TrySetAsync(IEnumerable<TValue> values, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryPaginationSetAsync(Project, Container, Expiry, values, cancellationToken);
            return result;
        }

        public async Task<(bool isSuccessful, IPaginationResponse<TValue> pagination)> TryGetAsync(IPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryPaginationGetAsync<TValue>(Project, Container, request, cancellationToken);
            return result;
        }

        public async Task<(bool isSuccessful, IEnumerable<TValue> values)> TryGetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryPaginationGetAllAsync<TValue>(Project, Container, cancellationToken);
            return result;
        }
    }
}

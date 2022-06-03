using Microsoft.EntityFrameworkCore;
using Services.SubModules.LogicLayers.Models.Requests;

namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    public class PaginationResponse<T> : IPaginationResponse<T>
    {
        public int TotalCount { get; set; }
        public List<T> Values { get; set; }
        public PaginationResponse()
        {
            Values = new List<T>();
        }
        public static async Task<PaginationResponse<T>> CreateAsync(IQueryable<T> queryable, int skip, int take, CancellationToken cancellationToken = default)
        {
            var result = new PaginationResponse<T>();
            result.TotalCount = await queryable.CountAsync(cancellationToken);
            result.Values.AddRange(await queryable
                .Skip(skip)
                .Take(take)
                .ToListAsync(cancellationToken));
            return result;
        }
        public static async Task<PaginationResponse<T>> CreateAsync(IQueryable<T> queryable, IPaginationRequest paginationRequest, CancellationToken cancellationToken = default)
        {
            var take = paginationRequest.Take();
            var result = await CreateAsync(queryable, paginationRequest.From, take, cancellationToken);
            return result;
        }
        public static PaginationResponse<T> Create(IEnumerable<T> values, int skip, int take)
        {
            var result = new PaginationResponse<T>();
            result.TotalCount = values.Count();
            result.Values.AddRange(values
                .Skip(skip)
                .Take(take));
            return result;
        }
        public static PaginationResponse<T> Create(IEnumerable<T> values, IPaginationRequest paginationRequest)
        {
            var take = paginationRequest.Take();
            var result = Create(values, paginationRequest.From, take);
            return result;
        }
    }
}

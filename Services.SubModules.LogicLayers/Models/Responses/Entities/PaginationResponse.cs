using Microsoft.EntityFrameworkCore;
using Services.SubModules.LogicLayers.Models.Requests;
using System.Linq.Expressions;

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
        public static async Task<PaginationResponse<T>> CreateAsync(IQueryable<T> queryable,
                                                                    int skip,
                                                                    int take,
                                                                    bool? firstRequest,
                                                                    string? propertyOrderBy,
                                                                    bool? orderByDescending,
                                                                    CancellationToken cancellationToken = default)
        {
            var result = new PaginationResponse<T>();
            if (!string.IsNullOrWhiteSpace(propertyOrderBy))
            {
                queryable = OrderBy(queryable, 
                                    propertyOrderBy, 
                                    !orderByDescending.HasValue ? false : orderByDescending.Value);
            }
            if (!firstRequest.HasValue || firstRequest.Value)
                result.TotalCount = await queryable.CountAsync(cancellationToken);

            result.Values.AddRange(await queryable
                         .Skip(skip)
                         .Take(take)
                         .ToListAsync(cancellationToken));
            return result;
        }
        public static async Task<PaginationResponse<T>> CreateAsync(IQueryable<T> queryable, IPaginationRequest paginationRequest, CancellationToken cancellationToken = default)
        {
            var skip = paginationRequest.Skip();
            var result = await CreateAsync(queryable,
                                           skip,
                                           paginationRequest.SizePage,
                                           paginationRequest.FirstRequest,
                                           paginationRequest.PropertyOrderBy,
                                           paginationRequest.OrderByDescending,
                                           cancellationToken);
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
            var skip = paginationRequest.Skip();
            var result = Create(values, skip, paginationRequest.SizePage);
            return result;
        }

        public static IQueryable<T> OrderBy<T>(IQueryable<T> queryable, string propertyOrderBy, bool orderByDescending)
        {
            var parameter = Expression.Parameter(typeof(T));
            var source = propertyOrderBy.Split('.').Aggregate((Expression)parameter, Expression.Property);
            if (source.Type.IsEnum)
            {
                source = Expression.Call(source, typeof(object).GetMethod(nameof(object.ToString)));
            }
            var lambda = Expression.Lambda(typeof(Func<,>).MakeGenericType(typeof(T), source.Type), source, parameter);
            var result = typeof(Queryable).GetMethods().Single(
                method => method.Name == (orderByDescending ? "OrderByDescending" : "OrderBy") &&
                          method.IsGenericMethodDefinition &&
                          method.GetGenericArguments().Length == 2 &&
                          method.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(T), source.Type)
                .Invoke(null, new object[] { queryable, lambda }) as IQueryable<T>;

            return result;
        }
    }
}

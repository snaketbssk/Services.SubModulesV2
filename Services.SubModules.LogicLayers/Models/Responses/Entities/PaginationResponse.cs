using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Services.SubModules.LogicLayers.Models.Requests;
using System.Linq.Expressions;

namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    /// <summary>
    /// Represents a response containing paginated data.
    /// </summary>
    /// <typeparam name="T">The type of data in the pagination response.</typeparam>
    public class PaginationResponse<T> : IPaginationResponse<T>
    {
        /// <summary>
        /// Total count of records available.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// List of values in the pagination response.
        /// </summary>
        public List<T> Values { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public PaginationResponse()
        {
            Values = new List<T>();
        }

        /// <summary>
        /// Creates a pagination response asynchronously.
        /// </summary>
        public static async Task<PaginationResponse<T>> CreateAsync(
            IQueryable<T> queryable,
            int skip,
            int take,
            bool? firstRequest,
            string? propertyOrderBy,
            bool? orderByDescending,
            bool? randomOrderBy,
            CancellationToken cancellationToken = default)
        {
            var result = new PaginationResponse<T>();

            // Apply random ordering if requested
            if (randomOrderBy.HasValue && randomOrderBy.Value)
            {
                queryable = queryable.OrderBy(x => Guid.NewGuid());
            }
            // Apply custom ordering if requested
            else if (!string.IsNullOrWhiteSpace(propertyOrderBy))
            {
                queryable = OrderBy(queryable,
                                    propertyOrderBy,
                                    !orderByDescending.HasValue ? false : orderByDescending.Value);
            }

            // Count total records if it's the first request or requested
            if (!firstRequest.HasValue || firstRequest.Value)
                result.TotalCount = await queryable.CountAsync(cancellationToken);

            // Load paginated values
            result.Values.AddRange(await queryable
                         .Skip(skip)
                         .Take(take)
                         .ToListAsync(cancellationToken));
            return result;
        }

        /// <summary>
        /// Creates a pagination response asynchronously using an IPaginationRequest.
        /// </summary>
        public static async Task<PaginationResponse<T>> CreateAsync(
            IQueryable<T> queryable,
            IPaginationRequest paginationRequest,
            CancellationToken cancellationToken = default)
        {
            var skip = paginationRequest.Skip();
            var result = await CreateAsync(queryable,
                                           skip,
                                           paginationRequest.SizePage,
                                           paginationRequest.FirstRequest,
                                           paginationRequest.PropertyOrderBy,
                                           paginationRequest.OrderByDescending,
                                           paginationRequest.RandomOrderBy,
                                           cancellationToken);
            return result;
        }

        /// <summary>
        /// Creates a pagination response from IEnumerable.
        /// </summary>
        public static PaginationResponse<T> Create(
            IEnumerable<T> values,
            int skip,
            int take)
        {
            var result = new PaginationResponse<T>();
            result.TotalCount = values.Count();
            result.Values.AddRange(values
                .Skip(skip)
                .Take(take));
            return result;
        }

        /// <summary>
        /// Creates a pagination response from IEnumerable using an IPaginationRequest.
        /// </summary>
        public static PaginationResponse<T> Create(
            IEnumerable<T> values,
            IPaginationRequest paginationRequest)
        {
            var skip = paginationRequest.Skip();
            var result = Create(values, skip, paginationRequest.SizePage);
            return result;
        }

        /// <summary>
        /// Applies dynamic ordering to an IQueryable.
        /// </summary>
        public static IQueryable<T> OrderBy<T>(
            IQueryable<T> queryable,
            string propertyOrderBy,
            bool orderByDescending)
        {
            var parameter = Expression.Parameter(typeof(T));
            var source = propertyOrderBy.Split('.').Aggregate((Expression)parameter, Expression.Property);

            // If the property is of enum type, convert it to string
            if (source.Type.IsEnum)
                source = Expression.Call(source, typeof(object).GetMethod(nameof(object.ToString)));

            // Create sorting expression
            var lambda = Expression.Lambda(typeof(Func<,>).MakeGenericType(typeof(T), source.Type), source, parameter);

            // Invoke the appropriate OrderBy or OrderByDescending method using reflection
            var result = typeof(Queryable).GetMethods().Single(method =>
                method.Name == (orderByDescending ? "OrderByDescending" : "OrderBy") &&
                method.IsGenericMethodDefinition &&
                method.GetGenericArguments().Length == 2 &&
                method.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(T), source.Type)
                .Invoke(null, new object[] { queryable, lambda }) as IQueryable<T>;

            return result;
        }

        /// <summary>
        /// Converts the pagination response to a different class using AutoMapper.
        /// </summary>
        public IPaginationResponse<TClass> Convert<TClass>(IMapper mapper)
        {
            var result = new PaginationResponse<TClass>();
            result.TotalCount = TotalCount;
            result.Values = mapper.Map<List<TClass>>(Values);
            return result;
        }
    }
}

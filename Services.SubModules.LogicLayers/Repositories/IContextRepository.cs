using EFCore.BulkExtensions;
using Services.SubModules.DataLayers.Models.Requests;
using Services.SubModules.LogicLayers.Models.Requests;
using Services.SubModules.LogicLayers.Models.Responses;

namespace Services.SubModules.LogicLayers.Repositories
{
    /// <summary>
    /// Interface for a generic context repository that manages entities within a context.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity managed by the repository.</typeparam>
    public interface IContextRepository<TEntity> : IDisposable where TEntity : class
    {
        /// <summary>
        /// Retrieves the first entity that matches the specified SQL request asynchronously.
        /// </summary>
        Task<TEntity> FirstOrDefaultAsync(ISqlRequest sqlRequest, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a list of entities that match the specified SQL request asynchronously.
        /// </summary>
        Task<List<TEntity>> ToListAsync(ISqlRequest sqlRequest, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new entity to the repository asynchronously.
        /// </summary>
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a collection of entities to the repository asynchronously.
        /// </summary>
        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an entity in the repository.
        /// </summary>
        TEntity Update(TEntity entity);

        /// <summary>
        /// Removes an entity from the repository.
        /// </summary>
        void Remove(TEntity entity);

        /// <summary>
        /// Removes a range of entities from the repository.
        /// </summary>
        void RemoveRange(params TEntity[] entities);

        /// <summary>
        /// Checks if the repository contains a specific entity asynchronously.
        /// </summary>
        Task<bool> ContainsAsync(TEntity entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a list of all entities from the repository asynchronously.
        /// </summary>
        Task<List<TEntity>> ToListAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a filtered list of entities from the repository asynchronously.
        /// </summary>
        Task<List<TEntity>> ToListAsync(IFilterRequest<TEntity> filterRequest, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a paginated response of entities from the repository asynchronously.
        /// </summary>
        Task<IPaginationResponse<TEntity>> ToPaginationAsync(IPaginationRequest paginationRequest,
                                                             IFilterRequest<TEntity> filterRequest,
                                                             CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously saves changes made in the repository's context to the database.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>The number of affected entries in the database.</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a range of entities in the repository.
        /// </summary>
        /// <param name="entities">The entities to be updated.</param>
        void UpdateRange(params TEntity[] entities);

        /// <summary>
        /// Updates a range of entities in the repository.
        /// </summary>
        /// <param name="entities">The entities to be updated.</param>
        void UpdateRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Asynchronously retrieves the first entity that satisfies the given filter.
        /// </summary>
        /// <param name="filterRequest">The filter criteria.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>The first entity that matches the filter, or null if not found.</returns>
        Task<TEntity?> FirstOrDefaultAsync(IFilterRequest<TEntity> filterRequest, CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously performs a bulk insert of entities into the repository.
        /// </summary>
        /// <param name="entities">The entities to be inserted.</param>
        /// <param name="bulkConfig">Bulk insert configuration options.</param>
        /// <param name="progress">An action to report the progress of the bulk insert.</param>
        /// <param name="type">The type of entity to be inserted.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        Task BulkInsertAsync(IEnumerable<TEntity> entities,
                             BulkConfig? bulkConfig = null,
                             Action<decimal>? progress = null,
                             Type? type = null,
                             CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously checks if any entity satisfies the given filter.
        /// </summary>
        /// <param name="filterRequest">The filter criteria.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>True if any entity matches the filter, otherwise false.</returns>
        Task<bool> AnyAsync(IFilterRequest<TEntity> filterRequest, CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously counts the number of entities that satisfy the given filter.
        /// </summary>
        /// <param name="filterRequest">The filter criteria.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>The count of entities matching the filter.</returns>
        Task<int> CountAsync(IFilterRequest<TEntity> filterRequest, CancellationToken cancellationToken = default);

        /// <summary>
        /// Removes entities from the repository based on the given filter.
        /// </summary>
        /// <param name="filterRequest">The filter criteria.</param>
        void Remove(IFilterRequest<TEntity> filterRequest);
    }
}

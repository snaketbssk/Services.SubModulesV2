using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Services.SubModules.DataLayers.Models.Requests;
using Services.SubModules.LogicLayers.Models.Requests;
using Services.SubModules.LogicLayers.Models.Responses;
using Services.SubModules.LogicLayers.Models.Responses.Entities;

namespace Services.SubModules.LogicLayers.Repositories.Entities
{
    /// <summary>
    /// Base repository class with context operations.
    /// </summary>
    /// <typeparam name="T">DbContext type.</typeparam>
    /// <typeparam name="TEntity">Entity type.</typeparam>
    public abstract class ContextRepository<T, TEntity> : IContextRepository<TEntity>
        where T : DbContext where TEntity : class
    {
        protected readonly T _context;
        protected readonly DbSet<TEntity> _repository;
        private bool _disposable;

        /// <summary>
        /// Constructor for the ContextRepository class.
        /// </summary>
        /// <param name="context">The DbContext instance.</param>
        /// <param name="repository">The DbSet of the entity type.</param>
        public ContextRepository(T context, DbSet<TEntity> repository)
        {
            _disposable = false;
            _context = context;
            _repository = repository;
        }

        /// <summary>
        /// Retrieves the first entity matching the provided criteria asynchronously.
        /// </summary>
        /// <param name="request">The SQL request parameters.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The first entity or null if not found.</returns>
        public virtual async Task<TEntity> FirstOrDefaultAsync(ISqlRequest request, CancellationToken cancellationToken = default)
        {
            var result = (await ToListAsync(request, cancellationToken)).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Retrieves a list of entities based on the provided SQL request asynchronously.
        /// </summary>
        /// <param name="request">The SQL request parameters.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A list of entities.</returns>
        public virtual async Task<List<TEntity>> ToListAsync(ISqlRequest request, CancellationToken cancellationToken = default)
        {
            var parameters = request.GetParameters();
            var result = await _repository.FromSqlRaw(request.Sql, parameters).ToListAsync(cancellationToken);
            return result;
        }

        /// <summary>
        /// Performs a bulk insert operation for the specified entities asynchronously.
        /// </summary>
        /// <param name="entities">Entities to insert.</param>
        /// <param name="bulkConfig">Bulk configuration options.</param>
        /// <param name="progress">Progress reporting action.</param>
        /// <param name="type">Type information.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Task representing the asynchronous operation.</returns>
        public virtual async Task BulkInsertAsync(IEnumerable<TEntity> entities,
                                                  BulkConfig? bulkConfig = null,
                                                  Action<decimal>? progress = null,
                                                  Type? type = null,
                                                  CancellationToken cancellationToken = default)
        {
            await _context.BulkInsertAsync(entities, bulkConfig, progress, type, cancellationToken);
        }

        /// <summary>
        /// Adds an entity to the repository asynchronously.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The added entity.</returns>
        public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var result = await _repository.AddAsync(entity, cancellationToken);
            return result.Entity;
        }

        /// <summary>
        /// Adds a range of entities to the repository asynchronously.
        /// </summary>
        /// <param name="entities">The entities to add.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await _repository.AddRangeAsync(entities, cancellationToken);
        }

        /// <summary>
        /// Updates the specified entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>The updated entity.</returns>
        public virtual TEntity Update(TEntity entity)
        {
            var result = _repository.Update(entity);
            return result.Entity;
        }

        /// <summary>
        /// Updates a range of entities in the repository.
        /// </summary>
        /// <param name="entities">The entities to update.</param>
        public virtual void UpdateRange(params TEntity[] entities)
        {
            _repository.UpdateRange(entities);
        }

        /// <summary>
        /// Updates a range of entities in the repository.
        /// </summary>
        /// <param name="entities">The entities to update.</param>
        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            _repository.UpdateRange(entities);
        }

        /// <summary>
        /// Removes the specified entity from the repository.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
        public virtual void Remove(TEntity entity)
        {
            _repository.Remove(entity);
        }

        /// <summary>
        /// Removes a range of entities from the repository.
        /// </summary>
        /// <param name="entities">The entities to remove.</param>
        public virtual void RemoveRange(params TEntity[] entities)
        {
            _repository.RemoveRange(entities);
        }

        /// <summary>
        /// Checks if the repository contains a specific entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity to check for.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>True if the entity exists in the repository, otherwise false.</returns>
        public virtual async Task<bool> ContainsAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var result = await _repository.ContainsAsync(entity, cancellationToken);
            return result;
        }

        /// <summary>
        /// Retrieves all entities from the repository asynchronously.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A list of retrieved entities.</returns>
        public virtual async Task<List<TEntity>> ToListAsync(CancellationToken cancellationToken = default)
        {
            var result = await GetQueryable().ToListAsync(cancellationToken);
            return result;
        }

        /// <summary>
        /// Checks if any entity satisfies the given filter asynchronously.
        /// </summary>
        /// <param name="filterRequest">The filter criteria.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>True if any entity matches the filter, otherwise false.</returns>
        public virtual async Task<bool> AnyAsync(IFilterRequest<TEntity> filterRequest, CancellationToken cancellationToken = default)
        {
            var queryable = GetQueryable();
            var filterQueryable = filterRequest.Find(queryable);
            var result = await filterQueryable.AnyAsync(cancellationToken);

            return result;
        }

        /// <summary>
        /// Counts the number of entities that satisfy the given filter asynchronously.
        /// </summary>
        /// <param name="filterRequest">The filter criteria.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>The count of entities matching the filter.</returns>
        public virtual async Task<int> CountAsync(IFilterRequest<TEntity> filterRequest, CancellationToken cancellationToken = default)
        {
            var queryable = GetQueryable();
            var filterQueryable = filterRequest.Find(queryable);
            var result = await filterQueryable.CountAsync(cancellationToken);

            return result;
        }

        /// <summary>
        /// Retrieves the first entity that satisfies the given filter asynchronously.
        /// </summary>
        /// <param name="filterRequest">The filter criteria.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>The first entity that matches the filter, or null if not found.</returns>
        public virtual async Task<TEntity?> FirstOrDefaultAsync(IFilterRequest<TEntity> filterRequest, CancellationToken cancellationToken = default)
        {
            var queryable = GetQueryable();
            var filterQueryable = filterRequest.Find(queryable);
            var result = await filterQueryable.FirstOrDefaultAsync(cancellationToken);

            return result;
        }

        /// <summary>
        /// Retrieves a list of entities from the repository asynchronously.
        /// </summary>
        /// <param name="filterRequest">The filter criteria.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A list of retrieved entities.</returns>
        public virtual async Task<List<TEntity>> ToListAsync(IFilterRequest<TEntity> filterRequest, CancellationToken cancellationToken = default)
        {
            var queryable = GetQueryable();
            var filterQueryable = filterRequest.Find(queryable);
            var result = await filterQueryable.ToListAsync(cancellationToken);

            return result;
        }

        /// <summary>
        /// Removes entities from the repository based on the given filter asynchronously.
        /// </summary>
        /// <param name="filterRequest">The filter criteria.</param>
        public virtual void Remove(IFilterRequest<TEntity> filterRequest)
        {
            var queryable = GetQueryable();
            var filterQueryable = filterRequest.Find(queryable);
            _repository.RemoveRange(filterQueryable);
        }

        /// <summary>
        /// Retrieves a paginated response of entities from the repository asynchronously.
        /// </summary>
        /// <param name="paginationRequest">The pagination criteria.</param>
        /// <param name="filterRequest">The filter criteria.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A paginated response of retrieved entities.</returns>
        public virtual async Task<IPaginationResponse<TEntity>> ToPaginationAsync(IPaginationRequest paginationRequest,
                                                                                  IFilterRequest<TEntity> filterRequest,
                                                                                  CancellationToken cancellationToken = default)
        {
            var queryable = GetQueryable();
            var filterQueryable = filterRequest.Find(queryable);
            var result = await PaginationResponse<TEntity>.CreateAsync(
                filterQueryable, paginationRequest, cancellationToken);

            return result;
        }

        /// <summary>
        /// Retrieves an IQueryable for the repository's DbSet.
        /// </summary>
        /// <returns>An IQueryable representing the repository's data.</returns>
        public virtual IQueryable<TEntity> GetQueryable()
        {
            var result = _repository.AsQueryable();
            return result;
        }

        /// <summary>
        /// Saves changes made in the DbContext to the database asynchronously.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>The number of affected entries in the database.</returns>
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result;
        }

        /// <summary>
        /// Disposes the repository and releases resources.
        /// </summary>
        public void Dispose()
        {
            if (!_disposable)
            {
                _disposable = true;
                _context.Dispose();
            }
        }
    }
}

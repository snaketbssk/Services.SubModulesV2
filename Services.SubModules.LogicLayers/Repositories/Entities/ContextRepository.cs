using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Services.SubModules.DataLayers.Models.Requests;
using Services.SubModules.LogicLayers.Models.Requests;
using Services.SubModules.LogicLayers.Models.Responses;
using Services.SubModules.LogicLayers.Models.Responses.Entities;

namespace Services.SubModules.LogicLayers.Repositories.Entities
{
    public abstract class ContextRepository<T, TEntity> : IContextRepository<TEntity>
        where T : DbContext where TEntity : class
    {
        private readonly T _context;
        protected readonly DbSet<TEntity> _repository;
        private bool _disposable;

        public ContextRepository(T context, DbSet<TEntity> repository)
        {
            _disposable = false;
            _context = context;
            _repository = repository;
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(ISqlRequest sqlRequest, CancellationToken cancellationToken = default)
        {
            var result = (await ToListAsync(sqlRequest, cancellationToken)).FirstOrDefault();
            return result;
        }

        public virtual async Task<List<TEntity>> ToListAsync(ISqlRequest sqlRequest, CancellationToken cancellationToken = default)
        {
            var parameters = sqlRequest.GetParameters();
            var result = await _repository.FromSqlRaw(sqlRequest.Sql, parameters).ToListAsync(cancellationToken);
            return result;
        }

        public virtual async Task BulkInsertAsync(IEnumerable<TEntity> entities, BulkConfig? bulkConfig = null, Action<decimal>? progress = null, Type? type = null, CancellationToken cancellationToken = default)
        {
            await _context.BulkInsertAsync(entities, bulkConfig, progress, type, cancellationToken);
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var result = await _repository.AddAsync(entity, cancellationToken);
            return result.Entity;
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await _repository.AddRangeAsync(entities, cancellationToken);
        }

        public virtual TEntity Update(TEntity entity)
        {
            var result = _repository.Update(entity);
            return result.Entity;
        }

        public virtual void UpdateRange(params TEntity[] entities)
        {
            _repository.UpdateRange(entities);
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            _repository.UpdateRange(entities);
        }

        public virtual void Remove(TEntity entity)
        {
            _repository.Remove(entity);
        }

        public virtual void RemoveRange(params TEntity[] entities)
        {
            _repository.RemoveRange(entities);
        }

        public abstract Task<TEntity> FindByIdAsync(IIdRequest idRequest, CancellationToken cancellationToken = default);
        public abstract Task<List<TEntity>> FindByIdsAsync(IEnumerable<IIdRequest> idsRequest, CancellationToken cancellationToken = default);

        public virtual async Task<bool> ContainsAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var result = await _repository.ContainsAsync(entity, cancellationToken);
            return result;
        }

        public virtual async Task<List<TEntity>> ToListAsync(CancellationToken cancellationToken = default)
        {
            var result = await GetQueryable().ToListAsync(cancellationToken);
            return result;
        }

        public virtual async Task<TEntity?> FirstOrDefaultAsync(IFilterRequest<TEntity> filterRequest, CancellationToken cancellationToken = default)
        {
            var queryable = GetQueryable();
            var filterQueryable = filterRequest.Find(queryable);
            var result = await filterQueryable.FirstOrDefaultAsync(cancellationToken);

            return result;
        }

        public virtual async Task<List<TEntity>> ToListAsync(IFilterRequest<TEntity> filterRequest, CancellationToken cancellationToken = default)
        {
            var queryable = GetQueryable();
            var filterQueryable = filterRequest.Find(queryable);
            var result = await filterQueryable.ToListAsync(cancellationToken);

            return result;
        }

        public virtual async Task<IPaginationResponse<TEntity>> ToPaginationAsync(IPaginationRequest paginationRequest,
                                                                                  IFilterRequest<TEntity> filterRequest,
                                                                                  CancellationToken cancellationToken = default)
        {
            var queryable = GetQueryable();
            var filterQueryable = filterRequest.Find(queryable);
            var result = await PaginationResponse<TEntity>.CreateAsync(filterQueryable,
                                                                       paginationRequest,
                                                                       cancellationToken);
            return result;
        }

        public virtual IQueryable<TEntity> GetQueryable()
        {
            var result = _repository.AsQueryable();
            return result;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result;
        }

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

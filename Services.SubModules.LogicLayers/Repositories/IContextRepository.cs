﻿using EFCore.BulkExtensions;
using Services.SubModules.DataLayers.Models.Requests;
using Services.SubModules.LogicLayers.Models.Requests;
using Services.SubModules.LogicLayers.Models.Responses;

namespace Services.SubModules.LogicLayers.Repositories
{
    public interface IContextRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> FirstOrDefaultAsync(ISqlRequest sqlRequest, CancellationToken cancellationToken = default);
        Task<List<TEntity>> ToListAsync(ISqlRequest sqlRequest, CancellationToken cancellationToken = default);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
        TEntity Update(TEntity entity);
        Task<TEntity> FindByIdAsync(IIdRequest idRequest, CancellationToken cancellationToken = default);
        void Remove(TEntity entity);
        void RemoveRange(params TEntity[] entities);
        Task<bool> ContainsAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<List<TEntity>> ToListAsync(CancellationToken cancellationToken = default);
        Task<List<TEntity>> ToListAsync(IFilterRequest<TEntity> filterRequest, CancellationToken cancellationToken = default);
        Task<IPaginationResponse<TEntity>> ToPaginationAsync(IPaginationRequest paginationRequest, IFilterRequest<TEntity> filterRequest, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        void UpdateRange(params TEntity[] entities);
        void UpdateRange(IEnumerable<TEntity> entities);
        Task<List<TEntity>> FindByIdsAsync(IEnumerable<IIdRequest> idsRequest, CancellationToken cancellationToken = default);
        Task<TEntity?> FirstOrDefaultAsync(IFilterRequest<TEntity> filterRequest, CancellationToken cancellationToken = default);
        Task BulkInsertAsync(IEnumerable<TEntity> entities, BulkConfig? bulkConfig = null, Action<decimal>? progress = null, Type? type = null, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(IFilterRequest<TEntity> filterRequest, CancellationToken cancellationToken = default);
        Task<int> CountAsync(IFilterRequest<TEntity> filterRequest, CancellationToken cancellationToken = default);
        void Remove(IFilterRequest<TEntity> filterRequest);
    }
}

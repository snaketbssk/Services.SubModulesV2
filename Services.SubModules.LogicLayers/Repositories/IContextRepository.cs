using Services.SubModules.LogicLayers.Models.Requests;
using Services.SubModules.LogicLayers.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Repositories
{
    public interface IContextRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));
        TEntity Update(TEntity entity);
        Task<TEntity> FindByIdAsync(IIdRequest idRequest, CancellationToken cancellationToken = default(CancellationToken));
        void Remove(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
        Task RemoveAsync(IIdRequest idRequest, CancellationToken cancellationToken = default(CancellationToken));
        Task<bool> ContainsAsync(IIdRequest idRequest, CancellationToken cancellationToken = default(CancellationToken));
        Task<List<TEntity>> ToListAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<IPaginationResponse<TEntity>> FindByFilterAsync(IPaginationRequest paginationRequest, IFilterRequest<TEntity> filterRequest, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}

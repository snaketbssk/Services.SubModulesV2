using Microsoft.EntityFrameworkCore;
using Services.SubModules.LogicLayers.Models.Requests;
using Services.SubModules.LogicLayers.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Repositories.Entities
{
    public abstract class ContextRepository<T, TEntity> : IContextRepository<TEntity> where T : DbContext where TEntity : class
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
        public abstract Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
        public abstract Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));
        public abstract TEntity Update(TEntity entity);
        public abstract Task<TEntity> FindByIdAsync(IIdRequest idRequest, CancellationToken cancellationToken = default(CancellationToken));
        public abstract void Remove(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
        public abstract Task RemoveAsync(IIdRequest idRequest, CancellationToken cancellationToken = default(CancellationToken));
        public abstract Task<bool> ContainsAsync(IIdRequest idRequest, CancellationToken cancellationToken = default(CancellationToken));
        public abstract Task<List<TEntity>> ToListAsync(CancellationToken cancellationToken = default(CancellationToken));
        public abstract Task<IPaginationResponse<TEntity>> FindByFilterAsync(IPaginationRequest paginationRequest,IFilterRequest<TEntity> filterRequest, CancellationToken cancellationToken = default);
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
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

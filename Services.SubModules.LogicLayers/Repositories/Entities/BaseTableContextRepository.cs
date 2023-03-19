using Microsoft.EntityFrameworkCore;
using Services.SubModules.DataLayers.Models.Tables.Entities;
using Services.SubModules.LogicLayers.Models.Requests;

namespace Services.SubModules.LogicLayers.Repositories.Entities
{
    public abstract class BaseTableContextRepository<T, TEntity> : ContextRepository<T, TEntity>
        where T : DbContext where TEntity : BaseTable<Guid>
    {
        public BaseTableContextRepository(T context, DbSet<TEntity> repository) : base(context, repository)
        {
        }

        public override async Task<TEntity> FindByIdAsync(IIdRequest idRequest, CancellationToken cancellationToken = default)
        {
            var result = await GetQueryable().FirstOrDefaultAsync(x => x.Id == idRequest.Id, cancellationToken);
            return result;
        }
    }
}

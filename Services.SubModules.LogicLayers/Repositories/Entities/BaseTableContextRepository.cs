using Microsoft.EntityFrameworkCore;
using Services.SubModules.DataLayers.Models.Tables.Entities;
using Services.SubModules.LogicLayers.Models.Requests;

namespace Services.SubModules.LogicLayers.Repositories.Entities
{
    /// <summary>
    /// Base repository class for tables with context.
    /// </summary>
    /// <typeparam name="T">DbContext type.</typeparam>
    /// <typeparam name="TEntity">Entity type derived from BaseTable with Guid ID.</typeparam>
    public abstract class BaseTableContextRepository<T, TEntity> : ContextRepository<T, TEntity>
        where T : DbContext where TEntity : BaseTable<Guid>
    {
        /// <summary>
        /// Constructor for the BaseTableContextRepository class.
        /// </summary>
        /// <param name="context">The DbContext instance.</param>
        /// <param name="repository">The DbSet of the entity type.</param>
        public BaseTableContextRepository(T context, DbSet<TEntity> repository) : base(context, repository)
        {
        }

        /// <summary>
        /// Find an entity by ID asynchronously.
        /// </summary>
        /// <param name="idRequest">The request containing the ID.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The entity with the specified ID.</returns>
        public override async Task<TEntity> FindByIdAsync(IIdRequest idRequest, CancellationToken cancellationToken = default)
        {
            var result = await GetQueryable().FirstOrDefaultAsync(x => x.Id == idRequest.Id, cancellationToken);
            return result;
        }

        /// <summary>
        /// Find entities by a list of IDs asynchronously.
        /// </summary>
        /// <param name="idsRequest">The requests containing the IDs.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>List of entities with the specified IDs.</returns>
        public override async Task<List<TEntity>> FindByIdsAsync(IEnumerable<IIdRequest> idsRequest, CancellationToken cancellationToken = default)
        {
            var ids = idsRequest.Select(x => x.Id).ToList();
            var result = await GetQueryable().Where(x => ids.Contains(x.Id)).ToListAsync(cancellationToken);
            return result;
        }
    }
}

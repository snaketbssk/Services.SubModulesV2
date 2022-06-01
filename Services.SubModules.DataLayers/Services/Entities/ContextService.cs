using Microsoft.EntityFrameworkCore;

namespace Services.SubModules.DataLayers.Services.Entities
{
    public abstract class ContextService<T> where T : DbContext
    {
        public readonly T Context;
        public ContextService(T context)
        {
            Context = context;
        }
    }
}

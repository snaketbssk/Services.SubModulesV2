using Microsoft.EntityFrameworkCore;

namespace Services.SubModules.DataLayers.Services.Entities
{
    public abstract class ContextService<T> where T : DbContext
    {
        protected readonly T _context;
        public ContextService(T context)
        {
            _context = context;
        }
    }
}

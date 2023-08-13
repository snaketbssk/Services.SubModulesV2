using Microsoft.EntityFrameworkCore;

namespace Services.SubModules.DataLayers.Services.Entities
{
    /// <summary>
    /// Represents an abstract base class for context services.
    /// </summary>
    /// <typeparam name="T">The type of the DbContext.</typeparam>
    public abstract class ContextService<T> where T : DbContext
    {
        /// <summary>
        /// The instance of the DbContext.
        /// </summary>
        protected readonly T _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContextService{T}"/> class with the specified DbContext.
        /// </summary>
        /// <param name="context">The instance of the DbContext.</param>
        public ContextService(T context)
        {
            _context = context;
        }
    }
}

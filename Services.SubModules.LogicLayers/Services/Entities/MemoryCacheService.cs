using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Services.SubModules.DataLayers.Services.Entities;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public abstract class MemoryCacheService<TValue, TContext> : ContextService<TContext> where TContext : DbContext
    {
        private readonly string _nameCache;
        private readonly IMemoryCache _memoryCache;
        private readonly MemoryCacheEntryOptions _memoryCacheEntryOptions;
        protected MemoryCacheService(
            IMemoryCache memoryCache,
            string nameCache,
            MemoryCacheEntryOptions memoryCacheEntryOptions,
            TContext context) : base(context)
        {
            _nameCache = nameCache;
            _memoryCache = memoryCache;
            _memoryCacheEntryOptions = memoryCacheEntryOptions;
        }
        private string GetHash(string key)
        {
            var result = $"{_nameCache}={key}";
            return result;
        }
        public virtual TValue Get(string key)
        {
            var hash = GetHash(key);
            var result = _memoryCache.Get<TValue>(hash);
            return result;
        }
        public virtual void Set(string key, TValue value)
        {
            var hash = GetHash(key);
            _memoryCache.Set(hash, value, _memoryCacheEntryOptions);
        }
        public virtual void Remove(string key)
        {
            var hash = GetHash(key);
            _memoryCache.Remove(hash);
        }
    }
}

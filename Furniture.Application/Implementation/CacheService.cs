using Furniture.Application.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Furniture.Application.Implementation
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public CacheService(
            IMemoryCache memoryCache
        )
        {
            _memoryCache = memoryCache;
        }

        public void AddCache<T>(string key, T data)
        {
            var dataCache = _memoryCache.Get<T>(key);
            if (dataCache != null)
            {
                _memoryCache.Remove(key);
            }

            _memoryCache.Set(key, data);
        }

        public T GetCache<T>(string key)
        {
            var dataCache = _memoryCache.Get<T>(key);
            return dataCache;
        }

    }
}

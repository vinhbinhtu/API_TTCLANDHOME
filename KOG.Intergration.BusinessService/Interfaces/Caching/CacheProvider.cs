using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace KOG.Intergration.BusinessService.Interfaces.Caching
{
    public interface ICacheProvider
    {
        Task<T> GetFromCache<T>(string key) where T : class;
        Task SetCache<T>(string key, T value) where T : class;
        Task SetCache<T>(string key, T value, DateTimeOffset duration) where T : class;
        Task ClearCache(string key);
    }
    public class CacheProvider : ICacheProvider
    {
        private const int CacheSeconds = 120000000; // 10 Seconds

        private static IMemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        public CacheProvider()
        {
            //_cache = cache;
        }

        public async Task<T> GetFromCache<T>(string key) where T : class
        {
            var cachedResponse =   _cache.Get(key);
            return cachedResponse as T;
        }

        public async Task SetCache<T>(string key, T value) where T : class
        {
          await  SetCache(key, value, DateTimeOffset.Now.AddSeconds(CacheSeconds));
        }

        public async Task SetCache<T>(string key, T value, DateTimeOffset duration) where T : class
        {

            _cache.Set(key, value, duration);
        }
        public async Task ClearCache(string key)
        {
            _cache.Remove(key);
        }
    }
}

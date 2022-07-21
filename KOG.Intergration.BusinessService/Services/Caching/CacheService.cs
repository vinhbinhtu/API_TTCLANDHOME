using KOG.Intergration.BusinessService.Interfaces.Caching;
using KOG.Intergration.Common;
using KOG.Intergration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOG.Intergration.BusinessService.Services.Caching
{
    public class CacheService : ICacheService
    {
        private readonly ICacheProvider _cacheProvider;

        public CacheService(ICacheProvider cacheProvider)
        {
            _cacheProvider = cacheProvider;
        }

        public async  Task<UserModel> GetCachedUser(string key)
        {
            return await  _cacheProvider.GetFromCache<UserModel>(key);
        }
        public async Task SetCacheUser(string key, UserModel value)
        {
           await  _cacheProvider.SetCache(key, value);
        }

        public async Task ClearCache(string key)
        {
            await _cacheProvider.ClearCache(key);
        }
    }
}

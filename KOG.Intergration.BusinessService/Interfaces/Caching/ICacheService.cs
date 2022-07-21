using KOG.Intergration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOG.Intergration.BusinessService.Interfaces.Caching
{
    public interface ICacheService
    {
        Task<UserModel> GetCachedUser(string key);
        Task SetCacheUser(string key, UserModel data);
        Task ClearCache(string key);
    }
}

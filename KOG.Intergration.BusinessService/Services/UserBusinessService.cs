using KOG.Intergration.BusinessService.Interfaces;
using KOG.Intergration.DataService.Interfaces;
using KOG.Intergration.Models;
using KOG.Intergration.Models.Auth;
using KOG.Intergration.Models.Users;
using KOG.Intergration.Common.Utils;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using KOG.Intergration.Models.UsersConfig;
using KOG.Intergration.Common;
using KOG.Intergration.BusinessService.Interfaces.Caching;
using Microsoft.Extensions.Caching.Memory;

namespace KOG.Intergration.BusinessService.Services
{
    public class UserBusinessService : IUserBusinessService
    {
        private readonly IJwtUtils _jwtUtils;
        private readonly IUserDataService _userDataService;
        private readonly ICacheService _cacheService;
        private readonly IOptions<AdminLogin> _adminLogin;
        private readonly IOptions<UserLogin> _userLogin;
        private static IMemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        public UserBusinessService(IUserDataService _userDataService, ICacheService _cacheService,
            IJwtUtils _jwtUtils,
            IOptions<UserLogin> _userLogin,
            IOptions<AdminLogin> _adminLogin)
        {
            this._jwtUtils = _jwtUtils;
            this._userDataService = _userDataService;
            this._cacheService = _cacheService;
            this._adminLogin = _adminLogin;
            this._userLogin = _userLogin;
            // _cache = cache;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var userConfig = _userLogin.Value;
            var adminConfig = _adminLogin.Value;

            int userAuth = userConfig.Email == model.Email ? Constants.USER_ROLE_KEY : adminConfig.Email == model.Email ? Constants.ADMIN_ROLE_KEY : 0;
            bool isPasswordAuth = BCrypt.Net.BCrypt.Verify(model.Password, userConfig.Password) ? true :
                BCrypt.Net.BCrypt.Verify(model.Password, adminConfig.Password) ? true : false;

            // validate
            if (userAuth == 0 || !isPasswordAuth)
                throw new AppException("Email or password is incorrect");

            // get user config
            UserModel user = await GetUserById(userAuth);

            // authentication successful so generate jwt token
            var jwtToken = _jwtUtils.GenerateJwtToken(user);

            return new AuthenticateResponse(user, jwtToken);
        }

        public async Task<UserModel> GetUserById(int userId)
        {
            // Check cache
            string key = userId + Constants.Users;
            var userModel = await _cacheService.GetCachedUser(key);
            if (userModel != null)
            {
                return userModel;
            }
            var adminConfig = _adminLogin.Value;
            var userConfig = _userLogin.Value;

            userModel = new UserModel();
            if (userId == Constants.ADMIN_ROLE_KEY)
            {
                userModel.Id = 1;
                userModel.Email = adminConfig.Email;
                userModel.RoleId = adminConfig.Role;
                userModel.FullName = "le huu vinh";
            }
            else
            {
                userModel.Id = 2;
                userModel.Email = userConfig.Email;
                userModel.RoleId = userConfig.Role;
                userModel.FullName = "le huu vinh 01";
            };
             _cacheService.SetCacheUser(key, userModel);

            return userModel;
        }

        public async Task<UserModel> GetCacheUser(string key)
        {
            // Check cache
            var userModel = await _cacheService.GetCachedUser(key + Constants.Users);
            if (userModel != null)
            {
                return userModel;
            }
            return null;
        }
    }
}


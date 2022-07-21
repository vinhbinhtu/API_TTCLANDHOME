using KOG.Intergration.Models;
using KOG.Intergration.Models.Auth;
using KOG.Intergration.Models.Users;

namespace KOG.Intergration.BusinessService.Interfaces
{
    public interface IUserBusinessService
    {
        Task<UserModel> GetUserById(int userId);
        Task<UserModel> GetCacheUser(string key);

        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
    }
}

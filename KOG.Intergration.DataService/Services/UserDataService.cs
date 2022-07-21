using KOG.Intergration.Models;
using KOG.Intergration.DataService.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace KOG.Intergration.DataService.Services
{
    public class UserDataService : BaseDataService, IUserDataService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public UserDataService(IRepository repository, IMapperService mapperService, IServiceScopeFactory _serviceScopeFactory) : base(repository, mapperService)
        {
            this._serviceScopeFactory = _serviceScopeFactory;
        }

        public UserModel GetUserById(int userId)
        {
            return new UserModel();
        }

        public UserModel GetUserByEmail(string email)
        {
            return new UserModel();
        }
    }
}

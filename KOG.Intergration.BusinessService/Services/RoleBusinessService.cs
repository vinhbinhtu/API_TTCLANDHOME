using KOG.Intergration.BusinessService.Interfaces;
using KOG.Intergration.DataService.Interfaces;
using KOG.Intergration.Models;

namespace KOG.Intergration.BusinessService.Services
{
    public class RoleBusinessService : IRoleBusinessService
    {
        private readonly IRoleDataService _roleDataService;

        public RoleBusinessService(IRoleDataService _roleDataService)
        {
            this._roleDataService = _roleDataService;
        }

        public RoleModel GetRoleById(int userId)
        {
            return _roleDataService.GetRoleById(userId);
        }
    }
}

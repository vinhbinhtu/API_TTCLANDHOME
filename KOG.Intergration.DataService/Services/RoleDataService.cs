using KOG.Intergration.Models;
using Microsoft.EntityFrameworkCore;
using KOG.Intergration.DataService.Interfaces;
using KOG.Intergration.Entity.Models;

namespace KOG.Intergration.DataService.Services
{
    public class RoleDataService : BaseDataService, IRoleDataService
    {
        public RoleDataService(IRepository repository, IMapperService mapperService) : base(repository, mapperService)
        {
        }

        public RoleModel GetRoleById(int roleId)
        {
            return new RoleModel();
        }
    }
}

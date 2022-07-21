using KOG.Intergration.Models;

namespace KOG.Intergration.DataService.Interfaces
{
    public interface IRoleDataService
    {
        RoleModel GetRoleById(int roleId);
    }
}

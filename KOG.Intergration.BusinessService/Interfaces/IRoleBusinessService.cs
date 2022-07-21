using KOG.Intergration.Models;

namespace KOG.Intergration.BusinessService.Interfaces
{
    public interface IRoleBusinessService
    {
        RoleModel GetRoleById(int userId);
    }
}

using KOG.Intergration.Models;

namespace KOG.Intergration.DataService.Interfaces
{
    public interface IUserDataService
    {
        UserModel GetUserById(int userId);

        UserModel GetUserByEmail(string email);
    }
}

using KOG.Intergration.Models;

namespace KOG.Intergration.DataService.Interfaces
{
    public interface IRepository
    {
        KOGIntergrationDBContext IntergrationDbContext { get; }
    }
}

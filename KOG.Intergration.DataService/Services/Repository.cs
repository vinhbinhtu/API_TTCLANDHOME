using KOG.Intergration.DataService.Interfaces;
using KOG.Intergration.Models;

namespace KOG.Intergration.DataService.Services
{
    public class Repository : IRepository
    {
        private readonly KOGIntergrationDBContext IContext;

        public Repository(KOGIntergrationDBContext IContext)
        {
            this.IContext = IContext;
        }

        public KOGIntergrationDBContext IntergrationDbContext
        {
            get
            {
                return IContext;
            }
        }
    }
}
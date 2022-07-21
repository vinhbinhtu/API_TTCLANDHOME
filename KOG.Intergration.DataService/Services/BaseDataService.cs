using KOG.Intergration.DataService.Interfaces;
using KOG.Intergration.Models;

namespace KOG.Intergration.DataService.Services
{
    public abstract class BaseDataService
    {
        protected readonly KOGIntergrationDBContext _IContext;
        protected readonly IMapperService MapperService;

        protected BaseDataService(IRepository repository, IMapperService mapperService)
        {
            _IContext = repository.IntergrationDbContext;

            this.MapperService = mapperService;
        }
    }
}

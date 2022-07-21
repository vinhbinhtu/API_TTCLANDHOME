using KOG.Intergration.BusinessService.Interfaces;
using KOG.Intergration.DataService.Interfaces;
using KOG.Intergration.Models.R81DMDT_BoPhan;

namespace KOG.Intergration.BusinessService.Services
{
    public class BoPhanBusinessService : IBoPhanBusinessService
    {
        private readonly IBoPhanDataService _boPhanDataService;

        public BoPhanBusinessService(IBoPhanDataService _boPhanDataService)
        {
            this._boPhanDataService = _boPhanDataService;
        }

        public List<R81DMDT_BoPhanResponseModel> GetAllBoPhan(int PageNumber, int RowsPage)
        {

            var result = _boPhanDataService.GetAllBoPhan(PageNumber, RowsPage);
            return result;
        }
    }
}

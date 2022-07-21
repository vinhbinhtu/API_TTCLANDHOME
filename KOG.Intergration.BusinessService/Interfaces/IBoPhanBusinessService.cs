using KOG.Intergration.Models.R81DMDT_BoPhan;

namespace KOG.Intergration.BusinessService.Interfaces
{
    public interface IBoPhanBusinessService
    {
        List<R81DMDT_BoPhanResponseModel> GetAllBoPhan(int PageNumber, int RowsPage);
    }
}

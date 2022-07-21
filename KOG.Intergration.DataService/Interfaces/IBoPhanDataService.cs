using KOG.Intergration.Models.R81DMDT_BoPhan;

namespace KOG.Intergration.DataService.Interfaces
{
    public interface IBoPhanDataService
    {
        List<R81DMDT_BoPhanResponseModel> GetAllBoPhan(int PageNumber, int RowsPage);
    }
}

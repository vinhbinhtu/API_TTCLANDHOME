using KOG.Intergration.Models.R81DMDT_NhanVien;

namespace KOG.Intergration.DataService.Interfaces
{
    public interface INhanVienDataService
    {
       Task<List<R81DMDT_NhanVienResponseModel>> GetAllNhanVien(int PageNumber, int RowsPage,CancellationToken cancellationToken);
    }
}

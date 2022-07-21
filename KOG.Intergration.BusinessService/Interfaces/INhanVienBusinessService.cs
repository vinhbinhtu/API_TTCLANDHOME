using KOG.Intergration.Models.R81DMDT_NhanVien;

namespace KOG.Intergration.BusinessService.Interfaces
{
    public interface INhanVienBusinessService
    {
        Task<List<R81DMDT_NhanVienResponseModel>> GetAllNhanVien(int PageNumber, int RowsPage, CancellationToken cancellationToken);
    }
}

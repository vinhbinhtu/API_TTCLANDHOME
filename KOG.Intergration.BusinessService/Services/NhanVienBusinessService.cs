using KOG.Intergration.BusinessService.Interfaces;
using KOG.Intergration.DataService.Interfaces;
using KOG.Intergration.Models.R81DMDT_NhanVien;

namespace KOG.Intergration.BusinessService.Services
{
    public class NhanVienBusinessService : INhanVienBusinessService
    {
        private readonly INhanVienDataService _nhanVienDataService;

        public NhanVienBusinessService(INhanVienDataService _nhanVienDataService)
        {
            this._nhanVienDataService = _nhanVienDataService;
        }

        public async Task<List<R81DMDT_NhanVienResponseModel>> GetAllNhanVien(int PageNumber, int RowsPage, CancellationToken cancellationToken)
        {
            var result = await _nhanVienDataService.GetAllNhanVien(PageNumber, RowsPage, cancellationToken);
            return result;
        }
    }
}

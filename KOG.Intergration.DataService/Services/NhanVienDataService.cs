using KOG.Intergration.Models.R81DMDT_NhanVien;
using Microsoft.EntityFrameworkCore;
using KOG.Intergration.DataService.Interfaces;
using KOG.Intergration.Entity.Models;
using KOG.Intergration.Common;

namespace KOG.Intergration.DataService.Services
{
    public class NhanVienDataService : BaseDataService, INhanVienDataService
    {
        public NhanVienDataService(IRepository repository, IMapperService mapperService) : base(repository, mapperService)
        {
        }

        public async Task<List<R81DMDT_NhanVienResponseModel>> GetAllNhanVien(int PageNumber, int RowsPage, CancellationToken cancellationToken)
        {
            var result = _IContext
                            .R81DMDT
                            .FromSqlRaw($"{StoredProcedure.NhanVien.MST002_NHAN_VIEN_GET} @PageNumber = {PageNumber}, @RowsPage = {RowsPage}")
                            .ToList();
            return MapperService.ConvertTo<List<DAO_R81DMDT>, List<R81DMDT_NhanVienResponseModel>>(result);
        }
    }
}

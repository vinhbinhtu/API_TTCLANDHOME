using KOG.Intergration.Models;
using Microsoft.EntityFrameworkCore;
using KOG.Intergration.DataService.Interfaces;
using KOG.Intergration.Entity.Models;
using KOG.Intergration.Common;
using KOG.Intergration.Models.R81DMDT_BoPhan;
using System.Data.SqlClient;

namespace KOG.Intergration.DataService.Services
{
    public class BoPhanDataService : BaseDataService, IBoPhanDataService
    {
        public BoPhanDataService(IRepository repository, IMapperService mapperService) : base(repository, mapperService)
        {
        }

        public List<R81DMDT_BoPhanResponseModel> GetAllBoPhan(int PageNumber, int RowsPage)
        {
            var result = _IContext
                            .R81DMDT
                            .FromSqlRaw($"{StoredProcedure.BoPhan.MST001_BO_PHAN_GET} @PageNumber = {PageNumber}, @RowsPage = {RowsPage}")
                            .ToList();
            return MapperService.ConvertTo<List<DAO_R81DMDT>, List<R81DMDT_BoPhanResponseModel>>(result);
        }

        //public bool CreateBoPhan(R81DMDT_BoPhanRequestModel boPhanRequestModel)
        //{
        //    var parameters = new[] {
        //        new SqlParameter("@PageNumber", department.DepartmentName),
        //        new SqlParameter("@RowsPage", department.DepartmentLocation)
        //    };

        //    var result = _IContext
        //                    .R81DMDT
        //                    .FromSqlRaw($"{StoredProcedure.BoPhan.MST001_BO_PHAN_POST} @PageNumber, @RowsPage", parameters);
        //    return true;
        //}
    }
}

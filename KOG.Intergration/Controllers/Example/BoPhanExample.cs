using KOG.Intergration.Models;
using KOG.Intergration.Models.Common;
using KOG.Intergration.Models.R81DMDT_BoPhan;
using Swashbuckle.AspNetCore.Filters;

namespace KOG.Intergration.Controllers.Example
{
    public class BoPhanExample: IExamplesProvider<ResponseModel<R81DMDT_BoPhanResponseModel>>
    {
        public ResponseModel<R81DMDT_BoPhanResponseModel> GetExamples()
        {
            return new ResponseModel<R81DMDT_BoPhanResponseModel>()
            {
                IsSuccess = true,
                Data = new R81DMDT_BoPhanResponseModel(),
                Message = "",
                ErrorDetails = new Dictionary<string, string>(),
                HttpStatusCode = 200
            };
        }
    }
}
using KOG.Intergration.Auth;
using KOG.Intergration.BusinessService.Interfaces;
using KOG.Intergration.Controllers.Example;
using KOG.Intergration.Models;
using KOG.Intergration.Models.Common;
using KOG.Intergration.Models.R81DMDT_BoPhan;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace KOG.Intergration.Controllers
{
    [Authorize]
    [ApiController]
    [Route("rest/v1/bophan")]
    public class BoPhanController : BaseController
    {
        private readonly ILogger<BoPhanController> _logger;
        private readonly IBoPhanBusinessService _boPhanBusinessService;

        public BoPhanController(ILogger<BoPhanController> logger
            , IBoPhanBusinessService boPhanBusinessService) : base(logger)
        {
            _logger = logger;
            _boPhanBusinessService = boPhanBusinessService;
        }

        /// <summary>
        /// 
        /// </summary>
        [Authorize("Admin, User")]
        [Route("getBoPhan")]
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ResponseModel<IEnumerable<R81DMDT_BoPhanResponseModel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllBoPhan([FromQuery, BindRequired] int PageNumber,[FromQuery, BindRequired] int RowsPage)
        {
            try
            {
                var result = _boPhanBusinessService.GetAllBoPhan(PageNumber, RowsPage);
                return CreateSuccessResponse(result);
            } catch (CustomException ex)
            {
                _logger.LogError(ex.Details.ToString());
                return await CreateErrorResponse(ex.Message, StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return await CreateErrorResponse(ex.Message);
            }
        }
    }
}

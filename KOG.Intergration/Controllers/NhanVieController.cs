using KOG.Intergration.Auth;
using KOG.Intergration.BusinessService.Interfaces;
using KOG.Intergration.Models.R81DMDT_NhanVien;
using KOG.Intergration.Models.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;

namespace KOG.Intergration.Controllers
{
    [Authorize]
    [ApiController]
    [Route("rest/v1/nhanvien")]
    public class NhanVienController : BaseController
    {
        private readonly ILogger<NhanVienController> _logger;
        private readonly IHttpContextAccessor _context;
        private readonly INhanVienBusinessService _nhanVienBusinessService;

        public NhanVienController(ILogger<NhanVienController> logger
            , IHttpContextAccessor context
            , INhanVienBusinessService nhanVienBusinessService) : base(logger)
        {
            _logger = logger;
            _context = context;
            _nhanVienBusinessService = nhanVienBusinessService;
        }

        /// <summary>
        /// 
        /// </summary>
        [Authorize("Admin, User")]
        [Route("getNhanVien")]
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ResponseModel<IEnumerable<R81DMDT_NhanVienResponseModel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllNhanVien([FromQuery, BindRequired] int PageNumber, [FromQuery, BindRequired] int RowsPage, CancellationToken cancellationToken)
        {
            try
            {
                var user = _context?.HttpContext?.User;
                string Email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value.ToString();
                var result = await _nhanVienBusinessService.GetAllNhanVien(PageNumber, RowsPage, cancellationToken);
                return CreateSuccessResponse(result);
            }
            catch (CustomException ex)
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

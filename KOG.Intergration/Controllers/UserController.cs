using KOG.Intergration.Auth;
using KOG.Intergration.BusinessService.Interfaces;
using KOG.Intergration.Models.Auth;
using KOG.Intergration.Models.Common;
using Microsoft.AspNetCore.Mvc;

namespace KOG.Intergration.Controllers
{
    [Authorize]
    [ApiController]
    [Route("rest/v1")]
    public class UserController : BaseController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserBusinessService _userBusinessService;

        public UserController(ILogger<UserController> logger
            , IUserBusinessService _userBusinessService) : base(logger)
        {
            _logger = logger;
            this._userBusinessService = _userBusinessService;
        }

        /// <summary>
        /// 
        /// </summary>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest model)
        {
            try
            {
                var response = await _userBusinessService.Authenticate(model);
                return Ok(response);
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
        [AllowAnonymous]
        [HttpPost("get_cache")]
        public async Task<IActionResult> getCache(string key)
        {
            var response = await _userBusinessService.GetCacheUser(key);
            return Ok(response);
        }
    }
}

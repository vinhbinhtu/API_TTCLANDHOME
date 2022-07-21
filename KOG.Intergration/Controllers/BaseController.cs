using KOG.Intergration.Models.Common;
using Microsoft.AspNetCore.Mvc;

namespace KOG.Intergration.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly ILogger Log;

        public BaseController(ILogger<BaseController> logger)
        {
            this.Log = logger;
        }

        protected IActionResult CreateSuccessResponse<T>(T data, string? message = null, int statusCode = StatusCodes.Status200OK)
        {
            var response = new ResponseModel<T>
            {
                Data = data,
                IsSuccess = true,
                Message = message ?? "Your request has been successfully completed",
                ErrorDetails = null,
                HttpStatusCode = statusCode
            };

            return Ok(response);
        }

        protected IActionResult CreateSuccessResponse<T>(T data, CustomException exception, string? message = null, int statusCode = StatusCodes.Status200OK)
        {
            var response = new ResponseModel<T>
            {
                Data = data,
                IsSuccess = true,
                Message = message ?? "Your request has been successfully completed",
                ErrorDetails = exception.Details,
                HttpStatusCode = statusCode
            };

            return Ok(response);
        }

        protected async Task<IActionResult> CreateErrorResponse(string errorMessage, int statusCode = StatusCodes.Status500InternalServerError)
        {
            var response = new ResponseModel<object>
            {
                Data = null,
                IsSuccess = false,
                Message = errorMessage,
                ErrorDetails = null,
                HttpStatusCode = statusCode
            };

            return BadRequest(response);
        }

        protected IActionResult CreateErrorResponse(CustomException exception, int statusCode = StatusCodes.Status500InternalServerError)
        {
            var response = new ResponseModel<object>
            {
                Data = null,
                IsSuccess = false,
                Message = string.IsNullOrEmpty(exception.Message) ? "Your request failed to complete" : exception.Message,
                ErrorDetails = exception.Details,
                HttpStatusCode = statusCode
            };

            return BadRequest(response);
        }

        protected IActionResult CreateErrorResponse(string message, CustomException exception, int statusCode = StatusCodes.Status500InternalServerError)
        {
            var response = new ResponseModel<object>
            {
                Data = null,
                IsSuccess = false,
                Message = message.Length > 0 ? message : exception.Message,
                ErrorDetails = exception.Details,
                HttpStatusCode = statusCode
            };

            return BadRequest(response);
        }

        protected IActionResult CreateErrorResponse(int statusCode = StatusCodes.Status500InternalServerError)
        {
            var response = new ResponseModel<object>
            {
                Data = null,
                IsSuccess = false,
                Message = "Your request failed to complete",
                ErrorDetails = new Dictionary<string, string> { { "error", "Internal server error" } },
                HttpStatusCode = statusCode
            };

            return BadRequest(response);
        }
    }
}

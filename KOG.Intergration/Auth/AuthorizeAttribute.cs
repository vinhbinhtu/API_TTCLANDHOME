namespace KOG.Intergration.Auth;

using KOG.Intergration.Common;
using KOG.Intergration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    private readonly string _roles;

    public AuthorizeAttribute(string roles = "")
    {
        _roles = roles;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // skip authorization if action is decorated with [AllowAnonymous] attribute
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        if (allowAnonymous)
            return;

        // authorization
        var user = (UserModel)context.HttpContext.Items["User"];
        var roleName = user?.RoleId == 1 ? Constants.ADMIN_AUTH : Constants.USER_AUTH;
        if (user == null || (_roles.Any() && !_roles.Contains(roleName)))
        {
            // not logged in or role not authorized
            context.Result = new JsonResult(new { message = "Unauthorized, You don't have permission to perform this action!" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}
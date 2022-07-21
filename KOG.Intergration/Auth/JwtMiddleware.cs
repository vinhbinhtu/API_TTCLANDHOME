namespace KOG.Intergration.Auth;

using KOG.Intergration.BusinessService.Interfaces;
using KOG.Intergration.Models;
using System.Security.Claims;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IUserBusinessService _userBusinessService, IJwtUtils jwtUtils)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var user = jwtUtils.ValidateJwtToken(token);

        if (user != null)
        {

            UserModel user_infor = await _userBusinessService.GetUserById(user.Id);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,  user.Email),
                new Claim(ClaimTypes.Name, user.FullName)
            };
            var userIdentity = new ClaimsIdentity(user.Id.ToString());
            userIdentity.AddClaims(claims);
            context.User.AddIdentity(userIdentity);
            // attach user to context on successful jwt validation
            context.Items["User"] = user;

        }

        await _next(context);
    }
}
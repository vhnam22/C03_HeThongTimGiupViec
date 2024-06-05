using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

[AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
public class CustomAuthorizeAttribute : ActionFilterAttribute
{
    private readonly string[] _roles;

    public CustomAuthorizeAttribute(params string[] roles)
    {
        _roles = roles;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var token = context.HttpContext.Session.GetString("JwtToken");
        if (string.IsNullOrEmpty(token))
        {
            context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
            {
                controller = "Account",
                action = "Login"
            }));
            return;
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes("HeThongTimGiupViec@123123!@#$%^&*()_+"); // Replace this with your actual key from settings

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero // Optional: Eliminate clock skew if needed
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var roleClaims = jwtToken.Claims.Where(x => x.Type == "role").Select(x => x.Value).ToList();

            if (!_roles.Any(role => roleClaims.Contains(role, StringComparer.InvariantCultureIgnoreCase)))
            {
                context.Result = new RedirectToActionResult("NotAccess", "Error", null);
                return;
            }
        }
        catch (Exception ex)
        {
            var logger = context.HttpContext.RequestServices.GetService<ILogger<CustomAuthorizeAttribute>>();
            logger?.LogError(ex, "Token validation failed");

            context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
            {
                controller = "Account",
                action = "Login"
            }));
            return;
        }

        base.OnActionExecuting(context);
    }
}

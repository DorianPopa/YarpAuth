using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace YarpAuth.Gateway.Middleware;

public static class GatewayEndpoints
{
    public static void UseGatewayEndpoints(this WebApplication app)
    {
        app.UseLoginEndpoint();
        app.UseLogoutEndpoint();
    }

    private static void UseLoginEndpoint(this WebApplication app)
    {
        app.MapGet(GatewayConstants.Routes.LoginRoute, (string? redirectUrl, HttpContext ctx) =>
        {

            if (string.IsNullOrEmpty(redirectUrl))
            {
                redirectUrl = GatewayConstants.Routes.DefaultRedirectRoute;
            }

            ctx.ChallengeAsync(OpenIdConnectDefaults.AuthenticationScheme, new AuthenticationProperties
            {
                RedirectUri = redirectUrl
            });
        });
    }

    private static void UseLogoutEndpoint(this WebApplication app)
    {
        app.MapGet(GatewayConstants.Routes.LogoutRoute, (string? redirectUrl, HttpContext ctx) =>
        {
            if (string.IsNullOrEmpty(redirectUrl))
            {
                redirectUrl = GatewayConstants.Routes.DefaultRedirectRoute;
            }

            var authProps = new AuthenticationProperties
            {
                RedirectUri = redirectUrl
            };

            var authSchemes = new string[] {
                CookieAuthenticationDefaults.AuthenticationScheme,
                OpenIdConnectDefaults.AuthenticationScheme
            };

            return Results.SignOut(authProps, authSchemes);
        });
    }
}

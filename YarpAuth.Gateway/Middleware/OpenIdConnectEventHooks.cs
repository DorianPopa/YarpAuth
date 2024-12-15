using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using System.Security.Claims;

namespace YarpAuth.Gateway.Middleware;

public static class OpenIdConnectEventHooks
{
    public static void AddOpenIdConnectEventHooks(this OpenIdConnectEvents events)
    {
        events.OnRedirectToIdentityProvider = OnRedirectToIdentityProvider;
        events.OnRedirectToIdentityProviderForSignOut = OnRedirectToIdentityProviderForSignOut;
        events.OnAuthorizationCodeReceived = OnAuthorizationCodeReceived;
        events.OnTokenResponseReceived = OnTokenResponseReceived;
        events.OnTokenValidated = OnTokenValidated;
        events.OnAuthenticationFailed = OnAuthenticationFailed;
    }

    private static Task OnAuthenticationFailed(AuthenticationFailedContext context)
    {
        return Task.CompletedTask;
    }

    private static Task OnTokenValidated(TokenValidatedContext context)
    {
        return Task.CompletedTask;
    }

    private static Task OnTokenResponseReceived(TokenResponseReceivedContext context)
    {
        return Task.CompletedTask;
    }

    private static Task OnAuthorizationCodeReceived(AuthorizationCodeReceivedContext context)
    {
        return Task.CompletedTask;
    }

    private static Task OnRedirectToIdentityProviderForSignOut(RedirectContext context)
    {
        //var identity = context.HttpContext.User.Identity as ClaimsIdentity;
        //var sid = identity?.FindFirst("sid")?.Value;
        //if (!string.IsNullOrEmpty(sid))
        //{
        //    context.ProtocolMessage.Parameters.Add("logout_hint", sid);
        //}
        context.ProtocolMessage.Parameters.Add("client_id", context.Options.ClientId);

        return Task.CompletedTask;
    }

    private static Task OnRedirectToIdentityProvider(RedirectContext context)
    {
        return Task.CompletedTask;
    }
}

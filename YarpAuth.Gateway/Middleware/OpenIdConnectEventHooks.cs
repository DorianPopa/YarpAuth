using Microsoft.AspNetCore.Authentication.OpenIdConnect;

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
        return Task.CompletedTask;
    }

    private static Task OnRedirectToIdentityProvider(RedirectContext context)
    {
        return Task.CompletedTask;
    }
}

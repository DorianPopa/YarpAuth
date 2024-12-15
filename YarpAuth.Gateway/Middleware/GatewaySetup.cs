using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using YarpAuth.Gateway.Configuration;

namespace YarpAuth.Gateway.Middleware;

public static class GatewaySetup
{
    public static WebApplicationBuilder AddGateway(this WebApplicationBuilder builder, GatewayConfiguration configuration)
    {
        builder.AddYarp();

        builder.AddAuthentication(configuration);
        builder.AddAuthorization();

        return builder;
    }

    private static WebApplicationBuilder AddYarp(this WebApplicationBuilder builder)
    {
        builder.Services.AddReverseProxy()
            .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
        return builder;
    }

    private static WebApplicationBuilder AddAuthentication(this WebApplicationBuilder builder, GatewayConfiguration configuration)
    {
        builder.Services
            .AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddOpenIdConnect(options =>
            {
                options.CallbackPath = configuration.CallbackUrl;
                options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.Authority = configuration.Authority;
                options.ClientId = configuration.ClientId;
                options.ClientSecret = configuration.ClientSecret;

                options.ResponseType = OpenIdConnectResponseType.Code;
                options.ResponseMode = OpenIdConnectResponseMode.FormPost;
                options.Scope.Add(OpenIdConnectScope.OpenIdProfile);

                options.UsePkce = true;

                options.Events.AddOpenIdConnectEventHooks();
            });

        return builder;
    }

    private static WebApplicationBuilder AddAuthorization(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy(GatewayConstants.ValidClaimsPolicy, policy =>
            {
                policy.RequireAuthenticatedUser();
                      //.RequireClaim(GatewayConstants.Claims.UserIdClaim)
                      //.RequireClaim(GatewayConstants.Claims.AccountIdClaim)
                      //.RequireClaim(GatewayConstants.Claims.AccountTypeClaim);
            });
        });

        return builder;
    }

    public static WebApplication UseGateway(this WebApplication app)
    {
        app.UseRouting();
        //app.UseSession();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseCookiePolicy();

        //app.UseXsrfCookie();
        app.UseGatewayEndpoints();
        app.UseYarp();

        return app;
    }

    private static void UseYarp(this WebApplication app)
    {
        app.MapReverseProxy(pipeline =>
        {
            //pipeline.UseGatewayPipeline();
        });
    }
}

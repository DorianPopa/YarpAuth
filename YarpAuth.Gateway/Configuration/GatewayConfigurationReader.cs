namespace YarpAuth.Gateway.Configuration;

public static class GatewayConfigurationReader
{
    public static GatewayConfiguration GetGatewayConfiguration(this ConfigurationManager configurationManager)
    {
        return new GatewayConfiguration
        {
            CallbackUrl = configurationManager.GetValue<string>("Gateway:CallbackUrl"),
            Authority = configurationManager.GetValue<string>("OpenIdConnect:Authority"),
            ClientId = configurationManager.GetValue<string>("OpenIdConnect:ClientId"),
            ClientSecret = configurationManager.GetValue<string>("OpenIdConnect:ClientSecret")
        };
    }
}

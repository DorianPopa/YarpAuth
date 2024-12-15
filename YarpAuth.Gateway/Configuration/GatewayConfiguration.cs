namespace YarpAuth.Gateway.Configuration;

public class GatewayConfiguration
{
    public string? CallbackUrl { get; internal set; } = string.Empty;
    public string? Authority { get; internal set; } = string.Empty;
    public string? ClientId { get; internal set; } = string.Empty;
    public string? ClientSecret { get; internal set; } = string.Empty;
}

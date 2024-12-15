namespace YarpAuth.Gateway.Middleware;

public static class GatewayConstants
{
    public const string ValidClaimsPolicy = "hasValidClaims";

    public static class Routes
    {
        public const string LoginRoute = "/login";
        public const string LogoutRoute = "/logout";
        public const string DefaultRedirectRoute = "/";

    }
    public static class Claims
    {
        public const string UserIdClaim = "customUserId";
        public const string AccountIdClaim = "customAccountId";
        public const string AccountTypeClaim = "customAccountType";
    }
}

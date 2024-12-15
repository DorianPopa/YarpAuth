using YarpAuth.Gateway.Configuration;
using YarpAuth.Gateway.Middleware;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration.GetGatewayConfiguration();

builder.AddGateway(configuration);

var app = builder.Build();

app.UseGateway();

app.Run();

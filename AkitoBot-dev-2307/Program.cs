using Microsoft.Extensions.Hosting;
using NetCord.Hosting.Gateway;

var builder = Host.CreateApplicationBuilder(args);

// Adds the Discord gateway service to your application host
builder.Services.AddDiscordGateway();

var host = builder.Build();

await host.RunAsync();

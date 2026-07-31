using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetCord;
using NetCord.Gateway;
using NetCord.Hosting;
using NetCord.Hosting.Gateway;
using NetCord.Hosting.Services;

var builder = Host.CreateApplicationBuilder(args);

// netcord + asp net
builder.Services
    .AddDiscordGateway(options =>
    {
        options.Token = Environment.GetEnvironmentVariable("DISCORD_TOKEN");
        
        options.Intents = GatewayIntents.Guilds 
                        | GatewayIntents.GuildMessages 
                        | GatewayIntents.MessageContent;
    })

var host = builder.Build();

host.AddModules(typeof(Program).Assembly); 
await host.RunAsync();

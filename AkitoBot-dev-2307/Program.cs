using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetCord;
using NetCord.Gateway;
using NetCord.Hosting;
using NetCord.Hosting.Gateway;

var builder = Host.CreateApplicationBuilder(args);

// Add NetCord Gateway and Hosting services
builder.Services
    .AddDiscordGateway(options =>
    {
        // Automatically reads the token from environment variables or configuration if set up,
        // or you can pull it directly from an environment variable like Back4App uses:
        options.Token = Environment.GetEnvironmentVariable("DISCORD_TOKEN");
        
        // Configure gateway intents required for your bot
        options.Intents = GatewayIntents.Guilds 
                        | GatewayIntents.GuildMessages 
                        | GatewayIntents.MessageContent;
    })
    // If you are using NetCord command/interaction services, add them here:
    .AddDiscordGatewayServices();

var host = builder.Build();

// Register an event listener or startup logic if needed
host.AddModules(typeof(Program).Assembly); // If you have command modules

// Run the host so the bot stays connected via WebSocket
await host.RunAsync();

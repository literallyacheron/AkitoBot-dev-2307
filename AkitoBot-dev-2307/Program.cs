using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NetCord;
using NetCord.Gateway;

// asp.net for container depl
var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://0.0.0.0:8080");

var app = builder.Build();

app.MapGet("/", () => "Bot is running!");
_ = app.RunAsync();

// netcord
string token = Environment.GetEnvironmentVariable("DISCORD_TOKEN");

if (string.IsNullOrEmpty(token))
{
    Console.WriteLine("Error: DISCORD_TOKEN environment variable is missing.");
    return;
}

GatewayClient client = new(new BotToken(token), new GatewayClientConfiguration()
{
    Intents = GatewayIntents.All,
    Logger = new ConsoleLogger()
});

client.Log += message =>
{
    Console.WriteLine(message);
    return default;
};

await client.StartAsync();
await Task.Delay(-1);

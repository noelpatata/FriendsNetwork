using FriendsNetwork.Infrastructure.IoC;
using FriendsNetwork.PosgreSqlRepository;
using FriendsNetwork.WebSocket.Helpers;
using FriendsNetwork.WebSocket.Managers;
using Microsoft.AspNetCore.WebSockets;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using FriendsNetwork.WebSocket.BackgroundServices;

var builder = WebApplication.CreateBuilder(args);
//FriendsNetwork root directory (from websocket project)
var envPath = Path.GetFullPath(Path.Combine(builder.Environment.ContentRootPath, "..", ".env"));
Env.Load(envPath);

//clearn architecture services
builder.Services.AddServices()
    .AddRepositories()
    .AddHandlers()
    .AddUseCases()
    .AddValidators()
    .AddPresenters()
    .AddMappers();

//reading .env variables
var dbHost = Environment.GetEnvironmentVariable("POSTGRESQL_HOST");
var dbName = Environment.GetEnvironmentVariable("POSTGRESQL_DATABASE");
var dbUser = Environment.GetEnvironmentVariable("POSTGRESQL_USER");
var dbPassword = Environment.GetEnvironmentVariable("POSTGRESQL_PASSWORD");
var wsAddress = Environment.GetEnvironmentVariable("WS_ADDRESS") ;
var wsPortString = Environment.GetEnvironmentVariable("WS_PORT");
var wsPort = int.TryParse(wsPortString, out var port) ? port : 5000;
var connectionString = $"Host={dbHost};Database={dbName};Username={dbUser};Password={dbPassword}";

// PostgreSQL DbContext
builder.Services.AddDbContext<FriendsNetworkDbContext>(options =>
    options.UseNpgsql(connectionString));

//websocket services
builder.Services.AddSingleton<JwtHelper>();
builder.Services.AddSingleton<IWebSocketConnectionManager, WebSocketConnectionManager>();

//background services
builder.Services.AddHostedService<NotificationQueueCheckerService>();


builder.Services.AddWebSockets(options =>
{
    options.KeepAliveInterval = TimeSpan.FromSeconds(30);
});

//websocket ssl cofniguration
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    var certPath = Environment.GetEnvironmentVariable("WS_SSL_CERT_PATH");
    var certPassword = Environment.GetEnvironmentVariable("WS_SSL_CERT_PASSWORD");

    serverOptions.Listen(System.Net.IPAddress.Parse(wsAddress ?? "0.0.0.0"), wsPort, listenOptions =>
    {
        listenOptions.UseHttps(Path.GetFullPath(Path.Combine(builder.Environment.ContentRootPath, "..", certPath)), certPassword);
    });
});

var app = builder.Build();

app.UseWebSockets();

//websocket endpoint and jwt authentication
app.Map("/ws", async context =>
{
    if (!context.WebSockets.IsWebSocketRequest)
    {
        context.Response.StatusCode = 400;
        return;
    }

    var token = context.Request.Query["token"].FirstOrDefault();

    if (string.IsNullOrEmpty(token))
    {
        context.Response.StatusCode = 401;
        await context.Response.WriteAsync("Missing token.");
        return;
    }

    var jwtHelper = context.RequestServices.GetRequiredService<JwtHelper>();
    var principal = jwtHelper.ValidateToken(token);

    if (principal == null)
    {
        context.Response.StatusCode = 401;
        await context.Response.WriteAsync("Invalid token.");
        return;
    }

    var userIdClaim = principal.FindFirst("userId")?.Value;

    if (userIdClaim == null || !long.TryParse(userIdClaim, out var userId))
    {
        context.Response.StatusCode = 401;
        await context.Response.WriteAsync("Invalid user.");
        return;
    }

    var connectionManager = context.RequestServices.GetRequiredService<IWebSocketConnectionManager>();
    var socket = await context.WebSockets.AcceptWebSocketAsync();

    connectionManager.AddSocket(userId, socket);

    await connectionManager.ReceiveLoopAsync(userId, socket);
});


app.Run();
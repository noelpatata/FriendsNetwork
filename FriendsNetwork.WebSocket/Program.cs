using FriendsNetwork.Infrastructure.IoC;
using FriendsNetwork.PosgreSqlRepository;
using FriendsNetwork.WebSocket.Managers;
using FriendsNetwork.WebSocket.Services;
using Microsoft.AspNetCore.WebSockets;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register shared Clean Architecture services
builder.Services.AddServices()
    .AddRepositories()
    .AddHandlers()
    .AddUseCases()
    .AddValidators()
    .AddPresenters()
    .AddMappers();

// Add EF DbContext (adjust connection string and provider accordingly)
builder.Services.AddDbContext<FriendsNetworkDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// WebSocket Connection Manager
builder.Services.AddSingleton<IWebSocketConnectionManager, WebSocketConnectionManager>();

// Background service to dispatch notifications
builder.Services.AddHostedService<NotificationDispatcherService>();

// Enable WebSocket support
builder.Services.AddWebSockets(options =>
{
    options.KeepAliveInterval = TimeSpan.FromSeconds(30);
});

var app = builder.Build();

app.UseWebSockets();

app.Map("/ws", async context =>
{
    if (context.WebSockets.IsWebSocketRequest)
    {
        var connectionManager = context.RequestServices.GetRequiredService<IWebSocketConnectionManager>();
        var socket = await context.WebSockets.AcceptWebSocketAsync();

        // Example: You might extract userId from query or token
        var userId = long.Parse(context.Request.Query["userId"]);

        connectionManager.AddSocket(userId, socket);

        await connectionManager.ReceiveLoopAsync(userId, socket);
    }
    else
    {
        context.Response.StatusCode = 400;
    }
});

app.Run();
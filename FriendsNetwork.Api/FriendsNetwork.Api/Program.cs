using FriendsNetwork.Infrastructure.IoC;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DotNetEnv;
using FriendsNetwork.PosgreSqlRepository;


var builder = WebApplication.CreateBuilder(args);

//FriendsNetwork root directory
var envPath = Path.GetFullPath(Path.Combine(builder.Environment.ContentRootPath, "..", "..", ".env"));
Env.Load(envPath);

//set host address for the api
var apiHost = Environment.GetEnvironmentVariable("API_HOST") ?? "https://localhost:5041";
builder.WebHost.UseUrls(apiHost);

// CORS
var allowedOrigin = Environment.GetEnvironmentVariable("REACT_APP_ORIGIN") ?? "http://localhost:3000";
Console.WriteLine($"Allowed origin: {allowedOrigin}");
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins(allowedOrigin)
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

//read .env for building connection string
var dbHost = Environment.GetEnvironmentVariable("POSTGRESQL_HOST");
var dbName = Environment.GetEnvironmentVariable("POSTGRESQL_DATABASE");
var dbUser = Environment.GetEnvironmentVariable("POSTGRESQL_USER");
var dbPassword = Environment.GetEnvironmentVariable("POSTGRESQL_PASSWORD");
var connectionString = $"Host={dbHost};Database={dbName};Username={dbUser};Password={dbPassword}";

// PostgreSQL DbContext
builder.Services.AddDbContext<FriendsNetworkDbContext>(options =>
    options.UseNpgsql(connectionString));
    
// Register Clean Architecture services
builder.Services.AddServices()
                .AddRepositories()
                .AddHandlers()
                .AddUseCases()
                .AddValidators()
                .AddPresenters()
                .AddMappers();

// Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    var config = builder.Configuration;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = config["JwtSettings:Issuer"],
        ValidAudience = config["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"] ?? "")),
        TokenDecryptionKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:EncryptKey"] ?? ""))
    };
});

builder.Services.AddAuthorization();
builder.Services.AddControllers();

var app = builder.Build();
app.UseHttpsRedirection();

app.UseRouting();
app.UseCors("AllowReactApp");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

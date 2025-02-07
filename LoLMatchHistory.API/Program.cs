using LoLMatchHistory.API.Auth;
using LoLMatchHistory.Infrastructure;
using LoLMatchHistory.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

string logFileName = @"LoLMatchHistory-" + Guid.NewGuid().ToString() + ".log";
StreamWriter _logStream = new(logFileName, append: true);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });
builder.Services.AddProblemDetails();

builder.Services.AddAuthentication(BasicAuthenticationDefaults.AuthenticationScheme)
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(BasicAuthenticationDefaults.AuthenticationScheme, null);

builder.Services.AddDbContext<LoLMatchHistoryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LoLMatchHistoryConnection"))
        .LogTo(_logStream.WriteLine, LogLevel.Debug)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors();
});
builder.Services.AddScoped<MatchInfoRepository>();
builder.Services.AddScoped<KillsRepository>();
builder.Services.AddScoped<BansRepository>();
builder.Services.AddScoped<GoldRepository>();
builder.Services.AddScoped<MonstersRepository>();
builder.Services.AddScoped<StructuresRepository>();

var app = builder.Build();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers()
    .RequireAuthorization();

app.Run();

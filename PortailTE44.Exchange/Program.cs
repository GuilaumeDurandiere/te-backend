using app.Context;
using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using PortailTE44.Business.Extensions;
using PortailTE44.Common.CustomMiddleware;
using PortailTE44.Common.Models;
using PortailTE44.DAL.Configurations;
using PortailTE44.DAL.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
            .MinimumLevel.Warning()
            .WriteTo.Console()
            .WriteTo.File("../Logs/log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

builder.Logging.AddSerilog(logger);
// Add services to the container.

ConfigurationManager configuration = builder.Configuration;
configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.Docker.json", true, true)
    .AddJsonFile($"appsettings.user.{Environment.UserName}.json", true, true)
    .AddEnvironmentVariables();

string origin = configuration.GetSection("OriginConfiguration").GetSection("Origins").Value!;
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowCORS", builder =>
    {
        builder.WithOrigins(origin)
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.ConfigureDatabase(configuration);
builder.Services.ConfigureFluentMigrator(configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbPortailTE44")!));

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.ConfigureServices();
builder.Services.ConfigureRepositories();
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection(nameof(MailSettings)));
builder.Services.Configure<MailTemplates>(builder.Configuration.GetSection(nameof(MailTemplates)));

var app = builder.Build();

app.UseCors("AllowCORS");

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Migration
using var scope = app.Services.CreateScope();
var migrator = scope.ServiceProvider.GetService<IMigrationRunner>();
migrator!.MigrateUp();

app.Run();
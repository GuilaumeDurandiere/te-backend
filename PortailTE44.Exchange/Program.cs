using app.Context;
using Microsoft.EntityFrameworkCore;
using FluentMigrator.Runner;
using PortailTE44.Business.Extensions;
using PortailTE44.DAL.Configurations;
using PortailTE44.DAL.Extensions;
using Serilog;
using Serilog.Events;
using PortailTE44.Common.Models;
using PortailTE44.Exchange.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("../Logs/log.txt", restrictedToMinimumLevel: LogEventLevel.Warning, rollingInterval: RollingInterval.Day)
            .CreateLogger();

builder.Logging.AddSerilog(logger);
// Add services to the container.

ConfigurationManager configuration = builder.Configuration;
configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.Docker.json", true, true)
    .AddJsonFile($"appsettings.user.{Environment.UserName}.json", true, true)
    .AddEnvironmentVariables();

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

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(builder => builder
.AllowAnyHeader()
.AllowAnyMethod()
.SetIsOriginAllowed((host) => true)
.AllowCredentials());

//Migration
using var scope = app.Services.CreateScope();
var migrator = scope.ServiceProvider.GetService<IMigrationRunner>();
migrator!.MigrateUp();

app.Run();
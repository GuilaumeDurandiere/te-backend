using FluentMigrator.Runner;
using PortailTE44.Business.Extensions;
using PortailTE44.DAL.Extensions;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("../Logs/log.txt", restrictedToMinimumLevel: LogEventLevel.Warning, rollingInterval: RollingInterval.Day)
            .CreateLogger();

builder.Logging.AddSerilog(logger);
// Add services to the container.

ConfigurationManager configuration = builder.Configuration;
builder.Services.ConfigureDatabase(configuration);
builder.Services.ConfigureFluentMigrator(configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.ConfigureServices();
builder.Services.ConfigureRepositories();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Migration
using var scope = app.Services.CreateScope();
var migrator = scope.ServiceProvider.GetService<IMigrationRunner>();
migrator!.MigrateUp();

app.Run();

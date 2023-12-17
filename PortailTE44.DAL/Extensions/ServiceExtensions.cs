using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PortailTE44.DAL.Repositories.Interfaces;
using PortailTE44.DAL.Repositories;
using System.Reflection;

namespace PortailTE44.DAL.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration Configuration)
        {
            string? connectionString = Configuration.GetConnectionString("dbPortailTE44");
            services.AddDbContextPool<PortailTE44Context>(options => options.UseSqlServer(connectionString!));
            services.AddScoped(provider => new PortailTE44Context(connectionString!));
        }

        public static void ConfigureFluentMigrator(this IServiceCollection services, IConfiguration configuration)
        {
            Assembly dataAssembly = Assembly.Load("PortailTE44.DAL");
            services.AddFluentMigratorCore()
                .ConfigureRunner(config =>
                    config.AddSqlServer()
                    .WithGlobalConnectionString(configuration.GetConnectionString("dbPortailTE44"))
                    .ScanIn(dataAssembly).For.All())
                .AddLogging(config => config.AddFluentMigratorConsole());
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IWorkflowRepository, WorkflowRepository>();
            services.AddScoped<IEtapeRepository, EtapeRepository>();
        }
    }
}

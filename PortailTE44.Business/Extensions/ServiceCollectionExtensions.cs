using Microsoft.Extensions.DependencyInjection;
using PortailTE44.Business.Services;
using PortailTE44.Business.Services.Interfaces;

namespace PortailTE44.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddScoped<IWorkflowService, WorkflowService>();
            services.AddScoped<IEtapeService, EtapeService>();
            services.AddScoped<ISousEtapeService, SousEtapeService>();
            services.AddScoped<IThemeService, ThemeService>();
            services.AddScoped<ISousThemeService, SousThemeService>();
            services.AddScoped<IMailService, MailService>();
        }
    }
}

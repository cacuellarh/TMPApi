
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TMP.infraestructure.persistence;
using TMP.aplication.contracts.repository;
using TMP.infraestructure.Repositories;
using TMP.infraestructure.webScraping;
using System.Reflection;
using MediatR;
using TPM.domain.contracts.webScraping.takeScreen;
using TPM.domain.contracts.webScraping.chatGpt;
using TMP.infraestructure.webScraping.chatGpt;
using TMP.domain.contracts.api;
using TMP.infraestructure.api;
using TMP.domain.commons.response.api;

namespace TMP.infraestructure
{
    public static class InfraestructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddDbContext<DbContextTMP>(options =>
            options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version(8, 0, 26))));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IImageTrackRepository, ImageTrackRepository>();

            services.AddTransient<ILoadRequestChatGpt, LoadChatGptConfig>();
            services.AddScoped<ISaveImageFromUrl, CaptureUrl>();
            services.AddTransient<IApiCrud<ApiResponse>, ApiCrudBase>();

            return services;
        }
    }
}

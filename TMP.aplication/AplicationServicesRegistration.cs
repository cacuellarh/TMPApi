
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;
using System.Reflection;
using TMP.aplication.builderServices.useCases;
using TMP.domain.contracts.useCase;
using TMP.domain.contracts.useCase.facades;
using TMP.domain.contracts.useCase.imageTrack;
using TMP.domain.contracts.useCase.product;
using TMP.domain.contracts.useCase.puppeteerSharp;
using TMP.aplication.mappings;
using TMP.aplication.response.db;
using TMP.aplication.useCases.imageTrack.basic;
using TMP.aplication.useCases.product.basic;
using TMP.aplication.useCases.screenShot;
using TMP.domain.contracts.map;
using TMP.domain.dto;
using TPM.domain.entities;

namespace TMP.aplication
{
    public static class AplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Registro de servicios
            BuilderServicesUseCaseImageTrack.AddImageTrackServices(services);
            BuilderServicesUseCaseProduct.AddProductServices(services);

            services.AddScoped<IUseCase<Expression<Func<ImageTrack, bool>>, DbResponse>, UseCaseGetImageTrack>();
            services.AddScoped<IUseCaseVoid<DbResponse>, UseCaseGetAllImageTrack>();

            services.AddTransient<ISaveScreenShotUseCase, SaveScreenShotUseCase>();

            return services;
        }
    }
}


using Microsoft.Extensions.DependencyInjection;
using TMP.domain.contracts.useCase.facades;
using TMP.domain.contracts.useCase.imageTrack;
using TMP.aplication.useCases.imageTrack.basic;
using TMP.aplication.useCases.imageTrack.facade;


namespace TMP.aplication.builderServices.useCases
{
    public static class BuilderServicesUseCaseImageTrack
    {
        public static void AddImageTrackServices(IServiceCollection services)
        {
            services.AddScoped<IUseCaseCreateImageTrack, UseCaseCreateImageTrack>();
            services.AddScoped<IUseCaseDeleteImageTrack, UseCaseDeleteImageTrack>();
            services.AddScoped<IUseCaseUpdateImageTrack, UseCaseUpdateImageTrack>();

            services.AddScoped<IImageTrackFacade, FacadeUseCasesImageTrack>();
        }
    }
}

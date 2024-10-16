using Microsoft.Extensions.DependencyInjection;
using TMP.domain.contracts.useCase;
using TMP.domain.contracts.useCase.product;
using TMP.aplication.mappings;
using TMP.aplication.useCases.product.basic;
using TMP.domain.commons.response.result;
using TMP.domain.contracts.map;
using TMP.domain.dto;
using TPM.domain.entities;

namespace TMP.aplication.builderServices.useCases
{
    public static class BuilderServicesUseCaseProduct
    {
        public static void AddProductServices(IServiceCollection services)
        {
            services.AddScoped<IMap<string, Result<ProductDto>>, ProductDtoMap>();
            services.AddScoped<IMap<ProductDto, Result<Product>>, ProductMap>();
            services.AddScoped<IUseCaseCreateProduct, UseCaseCreateProduct>();
            services.AddScoped<IUseCaseGetProduct, UseCaseGetProduct>();
        }
    }
}

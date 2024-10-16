using TMP.domain.commons.response.result;
using TMP.domain.dto;
using TPM.domain.entities;

namespace TMP.domain.contracts.useCase.product
{
    public interface IUseCaseCreateProduct : IUseCase<ProductDto, Result<Product>> { }
    
    
}
